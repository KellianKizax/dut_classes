-- Base vols
--1. Nombre d'Airbus et nombre maximum de places parmi ces avions.
SELECT COUNT(type) as , MAX(capacite) FROM avions WHERE upper(type)='AIRBUS';


--Base employés

--1. Quels employés du departement 20 a (ont) le salaire le plus elevé
SELECT ename FROM emp WHERE sal in (SELECT MAX(sal) FROM emp WHERE deptno=20) and deptno=20;

--2. Moyenne des commissions des commerciaux.
SELECT AVG(comm) FROM emp WHERE upper(job)='SALESMAN';

--3. Moyenne des commissions des employés.
SELECT AVG(nvl(comm, 0)) FROM emp;

--4. Gain minimum des employés.
SELECT MIN(sal + nvl(comm, 0)) as "Gain" FROM emp;

--5.Nombre d'employés sans commission ou dont la commission est inférieure à 1000.
SELECT COUNT(ename) FROM emp WHERE comm is NULL or comm<1000;

--6.Employés qui ne sont pas manager.
SELECT ename FROM emp WHERE upper(job)!='MANAGER';

--7. Quels sont les noms, numéros de département et salaires des employés qui sont les 'CLERK' les mieux payés ?
SELECT ename, deptno, sal FROM emp WHERE upper(job)='CLERK' and sal > (SELECT AVG(sal) FROM emp WHERE upper(job)='CLERK');

--8.Quelle est la moyenne des salaires des employés dirigés par 'BLAKE' ?
SELECT AVG(sal) FROM emp WHERE mgr = (SELECT empno FROM emp WHERE upper(ename)='BLAKE');

--9.Liste des employés (numéro, nom) dont le salaire est supérieur à la moyenne des salaires des analystes.
SELECT ename, empno FROM emp WHERE sal > (SELECT AVG(sal) FROM emp WHERE upper(job)='ANALYST');

--10.Nom, job et salaire de la personne ayant le plus de revenus.
SELECT ename, job, sal FROM emp WHERE (nvl(comm,0)+sal)= (SELECT MAX(nvl(comm,0)+sal) FROM emp);

--11.Nom et nombre de lettres du nom de la personne ayant le nom le plus long.
SELECT ename, Length(ename) FROM emp WHERE Length(ename)=(SELECT MAX(Length(ename)) FROM emp);

--12. Nombre de personnes touchant une commission.
SELECT COUNT(ename) FROM emp WHERE comm is not NULL;
SELECT COUNT(comm) FROM emp;

--13.Revenus moyens des employés.
SELECT AVG(nvl(comm,0)+sal) FROM emp;
