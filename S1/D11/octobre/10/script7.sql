--7.Dans une requête, il est possible de demander à l'utilisateur la saisie d'une 
--valeur. Pour faire cela, on préfixe un nom (qui servira de nom de variable) par 
--un &. Si la valeur attendue est une chaîne de caractères, le tout sera entre '. 
--Par exemple '&bidon'. Sachant cela, écrire un script permettant d'ajouter une 
--ligne en demandant à l'utilisateur le numéro, nom, job et salaire de l'employé, et 
--lui affectant la date courante comme date d'embauche.

INSERT INTO emp VALUES (&empno, '&ename', '&job', &mgr, to_date('&hiredate'), &sal, NULL, NULL);