--1.Trajets (ville de départ et d'arrivée), numéro d'avion et capacité. (AR, SQL 1, SQL2)
-- AR : r1 = proj(vols, {navion, depart, arrivee})
--      r2 = proj(avions,{navion, capacite})
--      res = join(r1,r2, r1.navion=r2.navion)
-- SQL2
SELECT vols.depart, vols.arrivee, vols.navion, avions.capacite
FROM vols JOIN avions ON vols.navion = avions.navion;
-- SQL1
SELECT v.depart, v.arrivee, v.navion, a.capacite
FROM vols v, avions a WHERE v.navion=a.navion;

--2.Nom des pilotes (principaux) de l'avion 8 (une solution avec jointure et une solution sans). (AR, SQL 1, SQL2)
-- AR : r1 = restrict(vols, navion=8)
--      r2 = join(r1, pilotes, r1.pilote=pilotes.pilote)
--      res = proj(r2,{nom})
-- SQL1
SELECT DISTINCT p.nom FROM pilotes p, vols v WHERE p.npilote=v.pilote AND v.navion=8;

SELECT DISTINCT nom FROM pilotes WHERE npilote in (SELECT pilote from vols where navion=8);
-- SQL2
SELECT DISTINCT p.nom FROM pilotes p JOIN vols v ON p.npilote=v.pilote
WHERE v.navion=8;

--3.Noms de tous les pilotes, et trajets qu'ils sont amenés à faire (ville de départ et ville d'arrivée)
--en tant que pilote principal, sans redondance et classés par ordre alphabétique du nom du pilote,
--de la ville de départ puis de la ville d'arrivée. (AR, SQL 1, SQL2)
--AR :  r1 = proj(pilotes, {npilote,nom})
--      r2 = proj(vols, {pilote, depart, arrivee})
--      res = join(r1, r2, r1.npilote=r2.pilote)
--SQL1
SELECT DISTINCT p.nom, v.depart, v.arrivee FROM vols v, pilotes p
WHERE v.pilote=p.npilote
ORDER BY p.nom, v.depart, v.arrivee;
--SQL2
select distinct p.nom, v.depart, v.arrivee from vols v right join pilotes p on v.pilote=p.npilote
order by p.nom, v.depart, v.arrivee;

--4.Nom des pilotes et copilotes qui font ensemble un vol entre Paris et Nice (sans redondance) (de deux façons). (AR, SQL 1, SQL2)
--AR: r1 = proj(vols, {pilote, copilote, depart, arrivee})
--    r2 = proj(pilotes, {npilote, nom})
--    r3 = restrict(r1, depart='paris' vatouslesmotardsdefranceetdenavarre arrivee='nice')
--    r4 = join(r2, r3, r2.npilote=r3.pilote)
--    r5 = join(r2, r4, r2.npilote=r4.copilote)
--SQL1
select distinct p.nom as "pilotes", p2.nom as "copilotes" from pilotes p, pilotes p2, vols v
where v.pilote=p.npilote and v.copilote=p2.npilote and lower(depart)='paris' and lower(arrivee)='nice';
--SQL2
SELECT DISTINCT p.nom as "pilotes", p2.nom as "copilotes"
FROM pilotes p JOIN vols v on p.npilote=v.pilote JOIN pilotes p2 on p2.npilote=v.copilote
WHERE lower(depart)='paris' and lower(arrivee)='nice';

--EMPLOYES
--1.Noms, jobs et noms de département des employés travaillant à DALLAS. (AR, SQL 1, SQL2)
--AR: r1 = restrict(dept, loc='dallas')
--    r2 = proj(r1, {loc, dname, deptno})
--    r3 = proj(emp, {ename, job, deptno})
--    r4 = join(r2, r3, r2.deptno=r3.deptno)
--SQL1
select ename, job, dname from emp, dept where emp.deptno=dept.deptno and lower(loc)='dallas';
--SQL2
select ename, job, dname from emp join dept on emp.deptno=dept.deptno
where lower(loc)='dallas';

--2.Noms des départements et de leurs employés, classés dans l'ordre alphabétique des noms de départements et des noms d'employés. (AR, SQL 1, SQL2)
--AR: r1 = proj(dept, {deptno, dname})
--    r2 = proj(emp, {ename, deptno})
--    r3 = join(r1, r2, r1.deptno=r2.deptno)
--SQL1
select dname, ename from emp, dept where emp.deptno=dept.deptno order by dname, ename;
--SQL2
select dname, ename from emp join dept on emp.deptno=dept.deptno order by dname, ename;

--3.Noms, salaires et noms de département des employés et de leurs managers, classés par noms de département des employés.
--AR: r1 =

--GAULOIS
--1.Noms, métiers et noms des potions que des gaulois savent préparer.
select g.nom, g.metier, p.nom from gaulois g, potion p, druide_potion d where g.gauno=d.gauno and d.potno=p.potno;
select g.nom, g.metier, p.nom from gaulois g join druide_potion d on g.gauno=d.gauno join potion p on d.potno=p.potno;

--2.Noms et noms du village des gaulois dont le métier est 'femme du chef'.
select g.nom, v.nom as "VILLAGE" from gaulois g, village v where v.vilno=g.vilno and lower(metier)='femme du chef';
select g.nom, v.nom as "VILLAGE" from gaulois g join village v on v.vilno=g.vilno where lower(metier)='femme du chef';

--3.Noms du ou des chefs et du ou des villages les plus grands dont le chef est connu.
select g.nom, v.nom from gaulois g, village v where v.chef=g.gauno and v.nbhutte > (select avg(nbhutte))
