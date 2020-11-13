-- Benoit DUVERNAY
-- Kellian GOFFIC
-- Projet D31

-- =====================================================================
-- Partie 1 : Index et optimisation

-- 1.
-- CREATE INDEX index_name ON table_name(column_name1,[...]);

-- 2.
SELECT index_name FROM all_indexes
WHERE lower(table_name)='testoptim';

SELECT index_name FROM all_indexes
WHERE lower(table_name)='testoptim2';

-- 3. Analyse de requêtes
-- 3.a)
EXPLAIN plan FOR
SELECT c1 FROM testOptim WHERE c2<300;
SELECT * FROM table(dbms_xplan.display);

-- 3.b)
EXPLAIN plan FOR
SELECT c1 FROM testOptim WHERE c2<300 ORDER BY c1;
SELECT * FROM table(dbms_xplan.display);

-- 3.c)
EXPLAIN plan FOR
SELECT c2, c1 FROM testOptim WHERE c1>300000 ORDER BY c1;
SELECT * FROM table(dbms_xplan.display);

-- 3.d)
EXPLAIN plan FOR
SELECT c2, c1 FROM testOptim WHERE c1<300000 ORDER BY c1;
SELECT * FROM table(dbms_xplan.display);

-- 3.e)
EXPLAIN plan FOR
SELECT sqrt(c1) FROM testOptim WHERE c1<300000 ORDER BY c1;
SELECT * FROM table(dbms_xplan.display);

-- 3.f)
EXPLAIN plan FOR
SELECT c1 FROM testOptim WHERE sqrt(c1)<300000 ORDER BY c1;
SELECT * FROM table(dbms_xplan.display);

-- 3.g)
EXPLAIN plan FOR
SELECT c1 FROM testOptim WHERE c1<300000 ORDER BY sqrt(c1);
SELECT * FROM table(dbms_xplan.display);

-- 3.h)
EXPLAIN plan FOR
SELECT to2.c21, to1.c2 FROM testOptim to1 JOIN testOptim2 to2 ON to2.c22=to1.c1 WHERE to1.c1<250000;
SELECT * FROM table(dbms_xplan.display);

-- 3.i)
EXPLAIN plan FOR
SELECT to2.c21, to1.c2 FROM testOptim to1 JOIN testOptim2 to2 ON to2.c22=to1.c1 WHERE to1.c1>250000;
SELECT * FROM table(dbms_xplan.display);

-- 3.j)
EXPLAIN plan FOR
SELECT to2.c21, to1.c2 FROM testOptim to1 JOIN testOptim2 to2 ON to2.c22=to1.c1 WHERE to2.c21<300;
SELECT * FROM table(dbms_xplan.display);

-- 3.k)
EXPLAIN plan FOR
SELECT to2.c21, to1.c2 FROM testOptim to1 JOIN testOptim2 to2 ON to2.c22=to1.c1 WHERE to2.c21>300;
SELECT * FROM table(dbms_xplan.display);


-- =================================================================================
-- Partie 2 : PL/SQL


-- Package Gestion Carte :

SET SERVEROUTPUT ON;



CREATE OR REPLACE PACKAGE GestionCarte IS

	PROCEDURE PizzasSansIng( nomIng VARCHAR );

	PROCEDURE PizzasSansCat( libCat VARCHAR );

	PROCEDURE AfficheCarte;

	PROCEDURE ModifTarif( numpiz NUMBER, taille NUMBER, montant NUMBER);

END GestionCarte;
/



CREATE OR REPLACE PACKAGE BODY GestionCarte IS

    -- a)
    PROCEDURE PizzasSansIng( nomIng VARCHAR ) IS
	
    CURSOR curseur IS
	    SELECT nompiz FROM pizza
        WHERE numpiz NOT IN
            ( SELECT pizza FROM composition
	            WHERE ing IN
	                ( SELECT numing FROM ingredient
	                    WHERE lower( libelle )=lower( nomIng ) ) );

    BEGIN

	    FOR pizza IN curseur LOOP
		    DBMS_OUTPUT.PUT_LINE( ' => ' || pizza.nompiz );
	    END LOOP;

    END PizzasSansIng;



    -- b)
    PROCEDURE PizzasSansCat( libCat VARCHAR ) AS
	
    CURSOR curseur IS
	    SELECT nompiz FROM pizza WHERE numpiz NOT IN
	        ( SELECT pizza FROM composition WHERE ing IN
	                ( SELECT numing FROM ingredient WHERE categorie IN
	                        ( SELECT numcat FROM categorie_ing
	                            WHERE lower( libelle )=lower( libCat ) ) ) );

    BEGIN
	    FOR pizza IN curseur LOOP
		    DBMS_OUTPUT.PUT_LINE( ' => ' || pizza.nompiz );
	    END LOOP;

    END PizzasSansCat;



    -- c)
    PROCEDURE AfficheCarte AS
	
    CURSOR curseur_pizza IS
	    SELECT piz.numpiz, INITCAP( piz.nompiz ) nom_pizza, LISTAGG( ing.libelle, ', ' ) WITHIN GROUP( ORDER BY ing.libelle ) liste_ing
	        FROM pizza piz JOIN composition co
	            ON piz.numpiz = co.pizza
	        JOIN ingredient ing
                ON co.ing = ing.numing
	        GROUP BY piz.numpiz, INITCAP( piz.nompiz );

	CURSOR curseur_tp( numpiz NUMBER ) IS
	    SELECT taille, prix FROM tarif WHERE pizza = numpiz ORDER BY taille;

    BEGIN
	    FOR pizza IN curseur_pizza LOOP
		    DBMS_OUTPUT.PUT_LINE( '=> ' || pizza.nomPizza || ' : ' || pizza.listeIng );

		    FOR taille_prix IN curseur_tp( pizza.numpiz ) LOOP
			    DBMS_OUTPUT.PUT_LINE('   - ' || taille_prix.taille || ' personnes : ' || taille_prix.prix || ' euros');
		    END LOOP;

	    END LOOP;

    END AfficheCarte;



    -- d)
    PROCEDURE ModifTarif( numpiz NUMBER, taille NUMBER, montant NUMBER ) AS
	
    CURSOR curseur_prix_petite IS
	    SELECT prix FROM tarif WHERE pizza = numpiz AND tarif.taille<ModifTarif.taille;
	
	CURSOR curseur_prix_grande IS
	    SELECT prix FROM tarif WHERE pizza = numpiz AND tarif.taille>ModifTarif.taille;

    DECLARE
        NEGATIVE_PRICE EXCEPTION;
        TOO_HIGH_PRICE EXCEPTION;
        TOO_LOW_PRICE EXCEPTION;



    BEGIN
	    IF ( montant<0 ) THEN
		    RAISE NEGATIVE_NUMBER;
	    END IF;

	    FOR prix IN curseur_prix_petite LOOP
		    IF ( montant<prix.prix ) THEN
			    RAISE TOO_LOW_PRICE;
		    END IF;
	    END LOOP;

	    FOR prix IN curseur_prix_grande LOOP
		    IF ( montant>prix.prix ) THEN
			    RAISE TOO_HIGH_PRICE;
		    END IF;
	    END LOOP;

	    UPDATE tarif SET prix = montant WHERE pizza=numpiz AND tarif.taille=ModifTarif.taille;
    
    END ModifTarif;



END;
/

-- ---------------------------------------------------------------------------------
-- Package GestionCommandes
SET SERVEROUTPUT ON;

CREATE OR REPLACE PACKAGE GestionCommandes IS
	PROCEDURE AfficheProchainesCommandes;
	 FUNCTION CoutLigneCommande(numcom NUMBER, numtarif NUMBER)
	   RETURN NUMBER;
	 FUNCTION CoutCommande(numcom NUMBER)
	   RETURN NUMBER;
	 FUNCTION GainJour(jour DATE)
	   RETURN NUMBER;
	 FUNCTION GainMois(annee NUMBER, mois NUMBER)
	   RETURN NUMBER;
	PROCEDURE Facture(numcom NUMBER);
	PROCEDURE MeilleureCommandeMoisCourant;
END GestionCommandes;
/


/*Creation du package GestionCommandes : */
CREATE OR REPLACE PACKAGE BODY GestionCommandes IS

/*Création de la procedure AfficheProchainesCommandes qui affiche pour chaque commande
* à livrer la prochaine heure , son numéro et la quantité de pizza commandées
*en fonction du type , de la ville , de l'adresse et l'heure de livraison*/

PROCEDURE AfficheProchainesCommandes AS
	CURSOR curseurProCommandes IS
	SELECT com.numc, dateheure_cmd, adresse1, adresse2, codepostal, ville,
	       SUM(lcmd.quantite) qtPiz
	  FROM commande com JOIN ligne_cmd lcmd ON com.numc = lcmd.numc
	 WHERE dateheure_cmd >= SYSDATE
	   AND dateheure_cmd <= SYSDATE + INTERVAL '1' HOUR
	   AND etat IS NULL
	 GROUP BY com.numc, dateheure_cmd,adresse1, adresse2, codepostal, ville
	 ORDER BY dateheure_cmd;
BEGIN
	FOR cmd IN curseurProCommandes LOOP
		DBMS_OUTPUT.PUT_LINE('Numéro de la commande : '|| cmd.numc);
		DBMS_OUTPUT.PUT_LINE('Quantité de pizzas dans la commande : '|| cmd.qtPiz);
		DBMS_OUTPUT.PUT_LINE('Ville : '|| cmd.ville);
		DBMS_OUTPUT.PUT_LINE('Adresse : '||cmd.adresse1);
		IF cmd.adresse2 IS NOT NULL THEN
			DBMS_OUTPUT.PUT_LINE('Complément d''adresse : '|| cmd.adresse2);
		END IF;
		DBMS_OUTPUT.PUT_LINE('Code postal : '|| cmd.codepostal);
	END LOOP;
END AfficheProchainesCommandes;

/*Creation de la fonction CoutLigneCommande(numcom,numtarif) qui retourne le coût de la ligne de la commande avec remises*/
FUNCTION CoutLigneCommande(numcom NUMBER, numtarif NUMBER) RETURN NUMBER AS
	cout NUMBER;
BEGIN
	SELECT ((100 - NVL(lcmd.remise, 0)) / 100) * lcmd.quantite * t.prix
	  INTO cout
	  FROM ligne_cmd lcmd JOIN tarif t ON lcmd.tarif = t.numt
	 WHERE lcmd.numc = numcom
	   AND lcmd.tarif = numtarif;
	RETURN cout;
END CoutLigneCommande;

/* Creation de la fonction CoutCommande(numcom) qui retourne le cout total de la commande avec remises*/
FUNCTION CoutCommande(numcom NUMBER) RETURN NUMBER AS cout NUMBER;

CURSOR curseurLigneCommande IS
    SELECT numc, tarif FROM ligne_cmd WHERE numc = numcom;

BEGIN
	    cout := 0;
	    FOR recLigneCmd IN curseurLigneCommande LOOP
		    cout := cout + CoutLigneCommande(recLigneCmd.numc, recLigneCmd.tarif);
	    END LOOP;
	    
        RETURN cout;

END CoutCommande;

/*Creation d'une fonction GainJour(date) qui renvoie le montant gagné le jour passé en paramètre*/
FUNCTION GainJour(jour DATE) RETURN NUMBER AS
    montant NUMBER;
	CURSOR curseurCmdJour IS
	    SELECT numc FROM commande
	    WHERE TO_CHAR(dateheure_cmd, 'DD/MM/YYYY') = TO_CHAR(jour, 'DD/MM/YYYY');
BEGIN
	montant := 0;
	FOR CmdJour IN curseurCmdJour LOOP
	    montant := montant + CoutCommande(CmdJour.numc);
	END LOOP;
	RETURN montant;
END GainJour;

/* Creation d'une fonction GainMois(annee, mois) qui retourne le montant gagné sur un mois donné*/
FUNCTION GainMois(annee NUMBER, mois NUMBER) RETURN NUMBER AS
	montant NUMBER;
	CURSOR curseurcommandesDuMois IS
	    SELECT numc FROM commande WHERE EXTRACT(YEAR FROM dateheure_cmd) = annee AND EXTRACT(MONTH FROM dateheure_cmd) = mois;
BEGIN
	montant := 0;
	FOR cmd IN curseurcommandesDuMois LOOP
		montant := montant + CoutCommande(cmd.numc);
	END LOOP;
	RETURN montant;
END GainMois;

/*Creation d'une fonction Facture(numcom) qui affiche le détail d'une commande (le nom de
*la pizzeria, date de la commande, noms des pizzas et tailles, quantité commandée, prix à
*l'unité, total de la ligne de commande sans remise, total de la remise, total de la ligne avec
*remise, montant de la commande avec remise, montant total de la remise)*/

PROCEDURE Facture(numcom NUMBER) AS
    datec DATE;
    total NUMBER;

	CURSOR curseurLigFac IS
	    SELECT UPPER(p.nompiz) pizza, t.taille taille, lcmd.quantite qte,
	        t.prix pu, lcmd.quantite * t.prix total_pre_r, (NVL(remise, 0) / 100) * lcmd.quantite * t.prix remise, CoutLigneCommande(lcmd.numc, t.numt) total
            FROM ligne_cmd lcmd JOIN tarif t ON lcmd.tarif = t.numt JOIN pizza p ON t.pizza = p.numpiz
	    WHERE lcmd.numc = numcom;

BEGIN
	
    SELECT dateheure_cmd INTO datec FROM commande WHERE numc = numcom;
	
	SELECT SUM(lcmd.quantite * t.prix) INTO total
        FROM ligne_cmd lcmd JOIN tarif t ON lcmd.tarif = t.numt
        WHERE lcmd.numc = numcom;

	DBMS_OUTPUT.PUT_LINE('PIZZERIA PRONTO:');
	DBMS_OUTPUT.PUT_LINE('Commande n°' || numcom);
    DBMS_OUTPUT.PUT_LINE('Date : ' || TO_CHAR(datec, 'DD/MM/YYYY'));

	FOR lig IN curseurligFac LOOP

		DBMS_OUTPUT.PUT_LINE(lig.pizza || lig.taille || lig.qte ||' '|| lig.pu || ' ' || lig.total_pre_r || ' ' || lig.remise || ' ' || lig.total);
	
    END LOOP;

	DBMS_OUTPUT.PUT_LINE('Total : ' || CoutCommande(numcom));
	DBMS_OUTPUT.PUT_LINE('Remise : ' || (CoutCommande(numcom) - total));

END Facture;

/* Création d'une fonction MeilleureCommandeMoisCourant qui affiche le numéro et le coût de
* la commande de coût le plus élevé pour le mois en cours, jusqu’à présent*/
PROCEDURE MeilleureCommandeMoisCourant
AS
	CURSOR curseurMeilleuresCmd IS
	SELECT numc, CoutCommande(numc) cout
	  FROM commande
	 WHERE TO_CHAR(SYSDATE, 'MM/YYYY') = TO_CHAR(dateheure_cmd, 'MM/YYYY')
	   AND CoutCommande(numc) =
	       (SELECT MAX(CoutCommande(numc))
	          FROM commande
	         WHERE TO_CHAR(SYSDATE, 'MM/YYYY') = TO_CHAR(dateheure_cmd, 'MM/YYYY'));
BEGIN
	FOR Cmd IN curseurMeilleuresCmd LOOP
		DBMS_OUTPUT.PUT_LINE('Meilleure commande: ' || Cmd.numc);
		DBMS_OUTPUT.PUT_LINE('cout : ' || Cmd.cout);
	END LOOP;
END MeilleureCommandeMoisCourant;

END;
/
