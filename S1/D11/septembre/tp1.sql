SET ECHO ON;
SET LINESIZE 300;

-- 1. Tous les departements
-- AR : res = proj(dept, dname)
SELECT dname FROM dept ;

-- 2. Les departements de No>10
	-- AR : res = proj(restrict(dept, deptno>10), dname)
SELECT dname FROM dept WHERE deptno>10 ;

-- 3. Tous les départements par ordre alphabétique des localisations
	-- AR :
SELECT dname, loc FROM dept ORDER BY loc ;

-- 4. Nom des employés et le numéro de leur chef
-- AR : res = proj(emp, {ename,mgr})
SELECT ename,mgr FROM emp ;

-- 5. Employés dont le travail est SALESMAN
-- AR : res = proj(restrict(emp, job='SALESMAN'), ename)
SELECT ename FROM emp WHERE job='SALESMAN' ;

-- 6. Noms, jobs et salaires annuels des ANALYST et des MANAGER
-- AR : res = proj(restrict(emp, job={'ANALYST','MANAGER'}), {ename,job,'sal'*12})
SELECT ename,job,sal*12 FROM emp WHERE job='ANALYST' OR job='MANAGER';

-- 7. Numeros et noms des employes qui n'ont pas de chef
-- AR : res = proj(restrict(emp, mgr is null), {empno,ename})
SELECT empno,ename FROM emp WHERE mgr IS NULL ;

-- 8. Numéros et noms des employes qui ont un numero entre 7800 et 7899
-- AR : res = proj(restrict(emp, empno>7800 V empno<7899), {empno,ename})
SELECT empno,ename FROM emp WHERE empno>7800 AND empno<7899 ;

-- 9. Employés dont le nom commence par A
-- AR : res = proj(restrict(emp, ename='A%'), ename)
--SELECT ename FROM emp WHERE ename='A%';?????

-- 10. Noms, fonctions et salaires chargés arrondis à 2 chiffres après la virgule (les charges = 82% du salaire) des employes
-- AR : res = proj(emp, {ename,job,sal*0.82})
SELECT ename,job,sal*0.82 FROM emp ;

-- 11. Differents job des employes
-- AR : res = proj(emp, job)
SELECT DISTINCT job FROM emp ;

-- 12. employes dont la commission est superieur au salaire
-- AR : res = proj(restrict(emp, comm>sal), ename)
SELECT ename FROM emp WHERE comm>sal ;

-- 13. Departement dont le numero est superieur a 20
-- AR : res = proj(restrict(dept, deptno>20), dname)
SELECT dname FROM dept WHERE deptno>20 ;

-- 14. Employes qui sont CLERK ou ANALYST
-- AR : res = proj(restrict(emp, job={'ANALYST','CLERK'}), ename)
SELECT ename FROM emp WHERE job='ANALYST' OR job='CLERK' ;

-- 15. Employes dont le nom comporte un L en deuxieme position
-- AR :
--

-- 16. Employes n'ayant pas de commission
-- AR : res = proj(restrict(emp, comm is null), ename)
SELECT ename FROM emp WHERE COMM IS NULL ;

-- 17. Employes dans l'ordre alphabetique des fonctions et pour chaque fonction l'ordre decroissant des salaires
--
SELECT ename FROM emp ORDER BY job ASC, sal DESC ;

-- 18. Employes qui sont CLERK ou MANAGER dans le departement 10
-- AR : res = proj(restrict(emp, (job='CLERK' or job='MANAGER') and deptno=10), ename)
SELECT ename FROM emp WHERE deptno=10 AND (job='CLERK' OR job='MANAGER');

-- 19. Noms et salaires des employes ayant un salaire superieur a 3000
-- AR : res = proj(restrict(emp, sal>3000), {ename,sal})
SELECT ename,sal FROM emp WHERE sal>3000 ;

-- 20. Noms et salaires des employes affichés sous les colonnes "Nom" et "Salaire"
--
SELECT ename AS Nom,sal AS Salaire FROM emp ;

-- 21. Pour les commerciaux, nom et valeur la plus élevée entre salaire et commission
--