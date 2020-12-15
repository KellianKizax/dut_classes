--1. Noms des employés du département 10 ayant même job que quel'qun du departement sales
select ename from emp where deptno=10 and job in (select upper(job) from emp where deptno=(select deptno from dept where upper(dname)='SALES'));

--2. Noms des employés travaillant dans un département de chicago et ayant même job que allen
select ename from emp where deptno in (select deptno from dept where loc='CHICAGO') and job in (select job from emp where ename='ALLEN');

--3. Noms et mois d'embauche (au format 'MM/YYYY') des managers d'employés des départements de CHICAGO.
select ename, to_char(hiredate, 'MM/YYYY') as "Mois d'embauche" from emp where upper(job)='MANAGER' and deptno in (select deptno from dept where upper(loc)='CHICAGO');

--4. Liste des employés des départements de CHICAGO et qui sont managers.
select ename from emp where upper(job)='MANAGER' and deptno in (select deptno from dept where upper(loc)='CHICAGO');

--5. Liste des employés qui ont le même travail que JAMES et qui travaillent dans son département.
select ename from emp where job in (select job from emp where upper(ename)='JAMES') and deptno in (select deptno from emp where upper(ename)='JAMES');

--6. Quels sont les employés qui ont le même responsable que TURNER (à part lui !) ?
select ename from emp where mgr in (select mgr from emp where upper(ename)='TURNER') and upper(ename)!='TURNER';

--7. Dans quelle localité y a-t-il des employés embauchés avant KING ?
select loc from dept where deptno in (select deptno from emp where hiredate < any (select hiredate from emp where upper(ename)='KING'));

--8. Quels sont les départements où il n'y a pas d'employés ?
select loc, deptno from dept where deptno not in (select deptno from emp);

--9. Numéros des managers qui ont sous leur responsabilité des employés embauchés après le 10 octobre 1984.
select mgr from emp where hiredate > '10/10/84';

--10. Numéros, noms et départements des employés qui dépendent de KING, et des ANALYST, triés par département et par nom.
select empno, ename, deptno from emp where upper(job)='ANALYST' or mgr in (select empno from emp where upper(ename)='KING');

--11. Noms des départements où des employés ont été embauchés en 1981.
select dname from dept where deptno in (select deptno from emp where to_char(extract(year from hiredate))='1981');

-- BASE VOLS

--1. Trajets (villes de départ et d'arrivée) distincts pour lesquels on peut voyager sur un Airbus d'au moins 300 places.
select distinct depart, arrivee from vols where navion in (select navion from avions where capacite>=300 and upper(type)='AIRBUS');

--2. Avions de même capacité que l'avion numéro 4.
select navion from avions where capacite in (select capacite from avions where navion=4);

--3. Numéro des pilotes (pilote principal) volant sur des avions de capacité inférieure à 200 places.
select pilote from vols where navion in (select navion from avions where capacite<200);

--4. Vols pour lesquels le pilote principal ne part pas de la ville où il habite.
select nvol from vols where depart not in (select habite from pilotes);

--5. Nom des pilotes qui ne sont jamais copilote.
select nom from pilotes where npilote not in (select copilote from vols);

--6. Nom des pilotes décollant de Nice (en tant que pilote principal) dans des avions d'une capacité supérieure à 300.
select nom from pilotes where npilote in (select npilote from vols where upper(depart)='NICE' and navion in (select navion from avions where capacite<300));

--7. Nom des pilotes n’atterrissant jamais à Nice en tant que pilote principal.
select nom from pilotes where npilote in (select pilote from vols where upper(arrivee)!='NICE');

--8. Nom et code (2 premières lettres en majuscules et dernière lettre en majuscule) des villes où aucun Airbus n'atterrit.
--select arrivee, upper(substr(arrivee, 1, 2) + substr(arrivee, to_number(length(arrivee))-1,1) ) as "code" from vols where navion in (select navion from avions where upper(type)='AIRBUS');

--9. Noms des pilotes qui sont toujours copilotes (jamais pilotes principaux - s'assurer qu'il leur arrive effectivement de participer à des vols).
select nom from pilotes where npilote in (select copilote from vols where copilote not in (select pilote from vols));

--10. Vols s'effectuant sur un avion pour lequel un Dupont est pilote principal pour certains de ses vols partant de Lyon.
select nvol from vols where navion in (select navion from vols where pilote in (select npilote from pilotes where lower(nom)='dupont') and lower(depart)='lyon');

--11. Pilotes qui n'effectuent jamais de vols sur Lyon (en tant que pilote ou copilote, pour des vols arrivant ou partant de Lyon).
select nom from pilotes where npilote not in (select pilote from vols where lower(depart)='lyon' or lower(arrivee)='lyon') and npilote not in (select copilote from vols where lower(depart)='lyon' or lower(arrivee)='lyon');

--12. Numéro des vols s'effectuant sur un avion du même modèle que l'avion numéro 4 (même modèle signifiant même type et même capacité).
select nvol from vols where navion in (select navion from avions where type in (select type from avions where navion=4) and capacite in (select capacite from avions where navion=4));

--13. Trajets (ville de départ et ville d'arrivée), pour lesquels il existe un vol retour.
select distinct depart, arrivee from vols where depart in (select arrivee from vols) and arrivee in (select depart from vols);

--14. Trajets (ville de départ et ville d'arrivée), pour lesquels il existe un vol retour avec les mêmes pilotes et copilotes.
select depart, arrivee from vols where 
