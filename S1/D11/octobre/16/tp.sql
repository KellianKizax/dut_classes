--1.
--age, en définissant toute la structure et les contraintes d'intégrité. Pensez aux contraintes applicatives,
--telles que le fait que le sexe est soit F, soit M, soit NULL.
--(Rappel : pour connaître les types des colonnes et si elles doivent être spécifiées NOT NULL,
--vous pouvez utiliser la commande SQL*Plus desc nom_table)
Create Table Village (
    vilno Number(2) Not Null,
    nom Varchar2(20) Not Null,
    nbhutte Number(3) Not Null,
    chef Number(3),
    CONSTRAINT pk_village PRIMARY KEY (vilno)
);
Create Table Gaulois (
    gauno Number(3) Not Null,
    nom Varchar2(15) Not Null,
    sex char(1),
    metier Varchar2(15),
    vilno Number(2),
    CONSTRAINT pk_gaulois PRIMARY KEY (gauno),
    CONSTRAINT fk_gaulois_vilno FOREIGN KEY (vilno)
        REFERENCES Village,
    CONSTRAINT c_gaulois_sex CHECK(upper(sex) in ('M','F') or sex is NULL)
);
Alter Table Village
ADD (CONSTRAINT fk_village_chef FOREIGN KEY (chef)
        REFERENCES Gaulois);

--2
--Insérez dans la base le gaulois pascalix, qui est un homme forgeron et habite le village 14. Il a pour numéro 114.
--Le village 14 est Strasbourgia, il comporte 100 huttes et a pour chef un homme appelé Frederix de numéro 112.
INSERT INTO Gaulois (gauno,nom,sex,metier,vilno)
	VALUES (112,'Frederix','M','Chef',NULL);
INSERT INTO Village (vilno,nom,nbhutte,chef)
    VALUES (14,'Strasbourgia',100,112);
UPDATE Gaulois
    Set vilno=14
    Where gauno=112;
INSERT INTO Gaulois (gauno,nom,sex,metier,vilno)
    VALUES (114,'Pascalix','M','Forgeron',14);

--3
--Compléter les tables précédentes avec le contenu des tables agnes_braud.gaulois, agnes_braud.village... 
ALTER TABLE gaulois DISABLE CONSTRAINT fk_gaulois_vilno;
INSERT INTO Gaulois SELECT * FROM agnes_braud.gaulois;
INSERT INTO Village SELECT * FROM agnes_braud.village;
ALTER TABLE gaulois ENABLE CONSTRAINT fk_gaulois_vilno;

--4
--Exécutez ce script. Eventuellement modifiez-le pour que les types correspondent à ceux
--que vous avez utilisés pour les tables gaulois et village. 

--5
--Créez la table trophee. 
Create Table Trophee (
    gauno Number(3) Not Null,
    batno Number(2) Not Null,
    grade VarChar2(15),
    nbcasque Number(3),
    CONSTRAINT pk_trophee PRIMARY KEY (gauno,batno,grade)
);
Alter Table Trophee
ADD (CONSTRAINT fk_trophee_gauno FOREIGN KEY (gauno)
        REFERENCES Gaulois);
Alter Table Trophee
ADD (CONSTRAINT fk_trophee_batno FOREIGN KEY (batno)
        REFERENCES ma_bataille);

--6
--Ajoutez une colonne nom_chef à la table mon_camp. 
ALTER TABLE mon_camp ADD(nom_chef varchar2(15));

--7
--Augmentez la taille de la colonne nom dans la table ma_bataille à 25 caractères. 
ALTER TABLE ma_bataille MODIFY (nom varchar2(25));

--8
--Ajouter à la table ma_bataille une contrainte qui vérifie que
--la date de la bataille est antérieure à la date du jour.
--IMPOSSIBLE ELEMENTS NON DETERMINISTES BLABLABLA 'sysdate'
--ALTER TABLE ma_bataille ADD (CONSTRAINT c_bataille_date CHECK(To_Date(datebat)<sysdate));

--9
--Tentez de réduire la taille de la colonne nom de la table mon_camp à 10 caractères. Que se passe-t-il ?
ALTER TABLE mon_camp MODIFY (nom varchar2(10));
--CA PASSE

--10
--Tentez maintenant de réduire la taille de la colonne nom de la table mon_camp à 8 caractères. Que se passe-t-il ?
ALTER TABLE mon_camp MODIFY (nom varchar2(8));
--CA CASSE

--11
--Supprimez la colonne nom_chef de la table mon_camp.
ALTER TABLE mon_camp DROP COLUMN nom_chef;

--12
--Désactivez la clé primaire.
ALTER TABLE mon_camp DISABLE CONSTRAINT pk_mon_camp;
--DES DEPENDANCES EXISTENT
