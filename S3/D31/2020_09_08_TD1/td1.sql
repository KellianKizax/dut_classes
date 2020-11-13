-- 1 Clients habitant une ville dont le nom commence par "t" : numéro du client, nom,
-- prenom et ville
SELECT noclient, nom, prenom, ville FROM clients WHERE LOWER(LEFT(ville, 1)) = 't';
-- 													LOWER(ville) like 't%'

-- 2 Toutes les infos sur les commandes passées en mai 2009, par date decroissante et
-- numero de client croissant
SELECT * FROM cmd WHERE TO_DATE('MM/YYYY', datecommande) = '05/2009' ORDER BY datecommande DESC, noclient;

-- 3 Nombre de clients de Paris ayant commandé après le 12 octobre 2008
SELECT COUNT(noclient)
FROM cmd INNER JOIN clients cli ON cmd.noclient = cli.noclient 
WHERE LOWER(cli.ville) = 'paris' AND TO_DATE('JJ/MM/YYYY', cmd.datecommande) > '12/10/2008';

-- 4 Pour tous les achats du livre Le seigneur des anneaux, numéro de commande, numéro
-- et nom du client et quantité commandée, triés par numéro de commande et numéro de client
SELECT cmdl.nocmd, cmdl.noclient, cli.nom, cmdl.quantite
FROM clients cli INNER JOIN cmd cmd ON cli.noclient = cmd.noclient
INNER JOIN cmd_lignes cmdl ON cmd.nocmd = cmdl.nocmd
INNER JOIN livres li ON cmdl.nolivre = li.nolivre
WHERE LOWER(li.titre) = 'le seigneur des anneaux'
ORDER BY cmdl.nocmd, cmdl.noclient;

-- 5 Nombre total de livres commandés en 2007 par pays
SELECT  SUM(cmdl.quantite), cli.pays
FROM clients cli INNER JOIN cmd ON cli.noclient = cmd.noclient
INNER JOIN cmd_lignes cmdl ON cmd.nocmd = cmdl.nocmd
WHERE EXTRACT(YEAR FROM cmd.datecommande) = '2007'
GROUP BY cli.pays
ORDER BY cli.pays;

-- 6 Numéros des clients ayant commandé plus de 3000 ouvrages en tout (toutes leurs commandes
-- confondues), et la quantité effectivement commandée
SELECT cmd.noclient, sum(cmdl.quantite)
FROM cmd INNER JOIN cmd_lignes cmdl ON cmd.nocmd = cmdl.nocmd
HAVING SUM(cmdl.quantite)>3000
GROUP BY cmd.noclient
ORDER BY cmd.noclient;

-- 7 Noms des auteurs qui ne sont édités que chez Pearson
-- (de deux facon, une corrélée et l'autre non. Vérifiez avec les outils
-- vus en cours si une requete est plus efficace que l'autre).
-- Attention, pour certains livres, l'éditeur n'est pas renseigné.
SELECT DISTINCT li.auteur
FROM livres li
WHERE INITCAP(li.editeur) = 'Pearson'
AND NOT EXISTS(
    SELECT * FROM livres li2
    WHERE INITCAP(li.auteur)=INITCAP(li2.auteur)
    AND INITCAP(li2.editeur)!='Pearson'
);

SELECT DISTINCT auteur
FROM livres
WHERE INITCAP(auteur) NOT IN (
    SELECT INITCAP(auteur) FROM livres WHERE editeur is NULL OR INITCAP(editeur)!='Pearson'
);