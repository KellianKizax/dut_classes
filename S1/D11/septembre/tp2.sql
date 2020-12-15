SET linesize 300
SET echo ON


--Expressions et fonctions


--1. Pour chaque vol, nom de la ville de départ et 3 premieres lettres de cette ville
SELECT depart, SUBSTR(depart,1,3) FROM vols;

--2. Pour chaque vol, nom de la ville de départ et 3 premieres lettres de cette ville en majuscules
SELECT depart, UPPER(SUBSTR(depart,1,3)) FROM vols;

--3 Code des vols ( 3 premieres lettre de la ville de depart + numero de vol)
-- ville de départ ordre croissant, numero de vol decroissant
SELECT UPPER(SUBSTR(depart,1,3)) || nvol as "Codes des Vols" FROM vols;

--4 Trajets distincts sous la forme "Vols de ... à ..." avec comme intitulé trajets
SELECT DISTINCT 'Vols de '|| depart ||' à '|| arrivee as Trajets FROM vols;

--5 Nom, salaire, commission, revenu (sal+comm) mensuel et revenu annuel (mensuel*12) Les salaires et comm seront exprimés en euros (1$=0.853479€) arrondis à l'euro supp pour le revenu annuel et tronqués à la deuxieme decimale pour le revenu mensuel.
SELECT ename, TRUNC(sal*0.853479, 0), TRUNC(NVL(comm,0)*0.853479, 0), ROUND((sal+NVL(comm,0))*0.853479, 2), TRUNC((sal+NVL(comm,0))*12*0.853479, 0) FROM emp;

--6 Liste des noms, metiers et abreviations correspondates des gaulois où l'abreviation est composée des 5 premieres lettres du nom du gaulois puis de son metiern ordonnée par sexe et abbréviation
SELECT nom, metier, SUBSTR(nom,1,5)||metier "Abbreviations" FROM gaulois ORDER BY sexe;


--Fonctions sur les dates


--1 Liste des employés (nom, date d'embauche, salaire, job) ainsi que le nombre de jours depuis leur embauche, classés par dates d'embauches croissantes
SELECT ename, hiredate, sal, job, EXTRACT(YEAR FROM hiredate)*365+EXTRACT(MONTH FROM hiredate)*30+EXTRACT(DAY FROM hiredate) "Temps d'embauche (jours)" FROM emp ORDER BY hiredate;

--2 Afficher la date du lundi après la date d'ajourd'hui
SELECT NEXT_DAY(SYSDATE, 'Lundi') FROM dual;

--3 Afficher la date du vendredi suivant votre date de naissance
SELECT DISTINCT NEXT_DAY(TO_DATE('11032001'), 'Vendredi') FROM dual;

--4 Quelles sont les batailles (numero, nom, date de bataille, duree en jours) ayant eu lieu au mois de mai

--5 Afficher les batailles, classées par durée decroissanten sous la forme(numeron nom, du <date debut>, au <date fin>)

--6 Afficher le nombre de mois depuis votre date de naissance
SELECT MONTHS_BETWEEN(SYSDATE, TO_DATE('11032001')) FROM dual;

--7 Afficher la date et l'heure courante
SELECT SYSDATE FROM dual;    --????

--8 Afficher le dernier jour du mois dans 3 mois
SELECT LAST_DAY(ADD_MONTHS(SYSDATE, 3)) FROM dual;

--9 Afficher le premier jour du mois suivant
