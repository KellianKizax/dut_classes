--2.Insérer la première ligne du tableau ci-dessus dans la table emp sans préciser les noms de colonnes.
INSERT INTO emp VALUES (1, 'GORE', 'VICE_PRESIDENT', 3, to_date('5/11/1992'), 10000, NULL, 10);

--3.Insérer la deuxième ligne en précisant les noms de colonnes.
INSERT INTO emp (empno, ename, job, mgr, hiredate, sal, comm, deptno)
VALUES (2, 'HILARY', 'SENATOR', 3, to_date('7/11/2000'), 10000, NULL, 20);

--4. Enregistrer les modifications
COMMIT;

--5.Insérer la troisième ligne et la quatrième ligne.
INSERT INTO emp VALUES (3, 'CLINTON', 'PRESIDENT', NULL, to_date('5/11/1992'), 20000, NULL, 10);
INSERT INTO emp VALUES (4, 'BUSH', 'CANDIDATE', NULL, NULL, 800, NULL, NULL);

--6. Enregistrer les modifications
COMMIT;

--7. voir script7.sql

--8.Ajouter deux lignes à l'aide de ce script.
--ok

--9.Vérifier l'ajout.
select * from emp;

--10.Affecter ces employés au département 30.
UPDATE emp SET deptno = 30
    WHERE hiredate = to_date('11/10/2019');

--11.Verifier la mise a jour.
Select * from emp;

--12.Enregistrer les modifications.
commit;

--13. Effacer tous les employés.
DELETE FROM emp;

--14. Annuler l'effacement.
ROLLBACK;

--15. Augmenter de 20% les salaires des employés embauchés avant le 31 décembre 1999.
UPDATE emp Set sal = sal *1.20
    WHERE hiredate < to_date('31/12/1999');

--16. Enregistrer les modifications.
commit;

--17. Vous décides de fermer le departement 20.
--Tous les employes de ce departement sont licencies.
DELETE FROM dept
    WHERE deptno = 20;
DELETE FROM emp
    WHERE deptno = 20;

--19.
CREATE TABLE manager AS (SELECT empno, ename, dname FROM emp JOIN dept on emp.deptno=dept.deptno); 

--20.
DELETE FROM manager WHERE manager.empno=(select mgr FROM emp WHERE emp.empno='7782');

--21.
ROLLBACK;
UPDATE emp SET sal = sal*1.10
    WHERE empno = (select mgr from emp where empno=7782);
UPDATE emp SET mgr = (select mgr from emp where empno=7782)
    WHERE mgr = 7782;
DELETE FROM emp WHERE empno=7782;
DELETE FROM manager WHERE empno=7782;

--22.
INSERT INTO dept VALUES (50, 'COMMUNICATION', NULL);
INSERT INTO emp VALUES (51, 'JEANPIERRE', 'CLERK', NULL, to_date('11/10/2019'), 800, NULL, 50);
INSERT INTO emp VALUES (52, 'FRANCOISXAVIER', 'CLERK', NULL, to_date('11/10/2019'), 800, NULL, 50);
INSERT INTO emp VALUES (53, 'GEORGES', 'CLERK', NULL, to_date('11/10/2019'), 800, NULL, 50);
INSERT INTO emp VALUES (54, 'JULIEN', 'CLERK', NULL, to_date('11/10/2019'), 800, NULL, 50);

--23.
--UPDATE emp SET deptno=50
--    WHERE hiredate = (select (hiredate) from emp where empno
--        in (select mgr from emp) );