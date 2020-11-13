--2. Ecrire une procédure stockée augmentMontant(employe, montant) qui permet d'augmenter l'employé
--    de montant.

CREATE OR REPLACE PROCEDURE augmentMontant(employe NUMBER, montant NUMBER) AS sal REAL;
  BEGIN
    UPDATE emp SET sal = sal + montant WHERE empno = employe;
  END augmentMontant;
/

--3. Utilisez cette procédure stockée pour augmenter un employé de 100 et vérifiez.
--    La mise à jour est-elle validée automatiquement dans une procédure stockée ?

EXEC augmentMontant(9999, 100);

-- Vérification :
SELECT sal FROM emp WHERE empno=9999;

--4. Demandez à un autre étudiant d'executer votre procédure stockée. Que se passe t il ?

EXEC goffic.augmentMontant(9999,100);
COMMIT;

--    Privilège insuffisant

--5. Donnez-lui le droit execute sur cette procédure stockée et vérifiez. Testez ce qui se
--    passe quand la procédure stockée est définie avec AUTHID CURRENT_USER ou DEFINER.

GRANT execute ON augmentMontant TO duvernay;

-- Vérification :

SELECT sal FROM emp WHERE empno=9999;

-- 6. Ecrire une procédure stockée afficheSalEmp(employe) qui permet d'afficher
--  à l'écran le salaire d'un employé. Testez.


SET SERVEROUTPUT ON;
CREATE OR REPLACE PROCEDURE afficheSalEmp(employe NUMBER) AS res NUMBER;
    BEGIN
        SELECT sal INTO res FROM emp WHERE empno=employe;
    END afficheSalEmp;
/

EXEC afficheSalEmp(9999);

--7. Ecrire une procédure stockée annuaire qui affiche tous les employés :
--    nom, fonction et département. Testez.

SET SERVEROUTPUT ON;
CREATE OR REPLACE PROCEDURE annuaire AS
  CURSOR curs IS SELECT ename, job, deptno FROM emp;
  info_emp curs%ROWTYPE;
  BEGIN
    OPEN curs;
    LOOP
      FETCH curs INTO info_emp;
      EXIT WHEN curs%NOTFOUND;
      DBMS_OUTPUT.PUT_LINE(info_emp.ename || ' ' || info_emp.job || ' ' || info_emp.deptno);
    END LOOP;
    CLOSE CURS;
  END annuaire;
/

--8. Ecrire une procédure stockée augmentPourcent(employe, pourcent, nouvSal) qui permet d'augmenter
--    l'employé de pourcent% et affecte au dernier paramètre la nouvelle valeur. Syntaxe : nomparam mode type.

CREATE OR REPLACE PROCEDURE augmentPourcent(
  employe IN INTEGER, pourcent IN INTEGER, nouvSal OUT INTEGER) IS
  BEGIN
    UPDATE emp
      SET sal = sal + (sal * (pourcent/100))
      WHERE empno = employe;
    SELECT sal INTO nouvSal
      FROM emp
      WHERE empno = employe;
  END augmentPourcent;
/


--9. Utilisez cette procédure stockée pour augmenter un employé de 5% et vérifiez.

EXEC augmentPourcent(9999, 5);

SELECT sal FROM emp WHERE empno = 9999;

--10. Ecrire une fonction stockée revenuAnnuel(employe) qui retourne le revenu annuel de l'employé.

SET SERVEROUTPUT ON;
CREATE OR REPLACE PROCEDURE revenuAnnuel(id NUMBER) AS salaire INTEGER;
  BEGIN
    SELECT sal INTO salaire
      FROM emp
      WHERE empno = id;
    salaire:=salaire*12;
    DBMS_OUTPUT.PUT_LINE(salaire || ' salaire annuel');
  END revennuAnuel;
/

--11. Utilisez cette fonction stockée pour connaître le revenu annuel d'un des employés.

EXEC revenuAnnuel(9999);

--12. Ecrire une fonction stockée revenuAnnuelPromoAnc(employe) qui retourne le revenu annuel
--    de l'employé, en lui ajoutant un 13e mois égal au salaire quand son ancienneté est
--    inférieure à 10 ans, égal au 13e mois augmenté d'un pourcentage égal à son ancienneté
--    quand celle-ci est supérieure ou égale à 10 ans. Testez.

SET SERVEROUTPUT ON;
CREATE OR REPLACE PROCEDURE revenuAnnuelPromoAnc(id NUMBER) AS salaireSpe INTEGER;
  BEGIN
    SELECT (sysdate() - hiredate) INTO salaireSpe
      FROM emp
      WHERE empno = id;

    IF salaireSpe/365 < 10 THEN
      SELECT sal*13 INTO salaireSpe
        FROM emp
        WHERE empno = id;
    ELSE
      SELECT (sal*13) + (sal*((salaireSpe/365)/100))  INTO salaireSpe
        FROM emp
        WHERE empno = id;
    END IF;
    DBMS_OUTPUT.PUT_LINE(salaireSpe || ' salaire annuel');
  END revenuAnnuel;
/

--13. Mettre ces sous-programmes dans un package GestionFinanciere.

CREATE OR REPLACE PACKAGE GestionFinanciere IS
  PROCEDURE revenuAnnuel(id NUMBER) AS salaire INTEGER;
END GestionFinanciere;
/

CREATE OR REPLACE PACKAGE BODY GestionFinanciere IS
  PROCEDURE revenuAnnuel(id NUMBER) AS salaire INTEGER;
  BEGIN
    SELECT sal INTO salaire
      FROM emp
      WHERE empno = id;
    salaire:=salaire*12;
    DBMS_OUTPUT.PUT_LINE(salaire || ' salaire annuel');
  END revenuAnnuel;
END GestionFinanciere;
/

--14. Testez l'exécution d'une procédure stockée de ce package.

EXEC GestionFinanciere.revenuAnnuel(9999);

--15. Donnez à un autre étudiant le droit d'exécuter le package et vérifiez qu'il peut exécuter une procédure.

GRANT execute ON GestionFinanciere TO someone;

--16. Créez la table mes_augmentations(empno : number(5), date_aug : date, montant_aug : number(6,2))
--    qui permettra de garder un historique des augmentations.

CREATE TABLE mes_augmentations(
  empno number(5),
  date_aug date,
  montant_aug number(6,2)
);

--17. Ecrire un déclencheur qui permet de d'alimenter la table mes_augmentations en cas d'augmentation d'un employé.

CREATE OR REPLACE TRIGGER trigger_augmen
BEFORE UPDATE ON emp
FOR EACH ROW WHEN (NEW.EMPNO > 0)
DECLARE
 sal_diff number;
BEGIN
sal_diff := :NEW.SAL - :OLD.SAL;
INSERT INTO mes_augmentations VALUES(:NEW.empno,sysdate(),sal_diff);
END;
/
