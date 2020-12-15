/*==============================================================*/
/* Nom de SGBD :  ORACLE Version 8                              */
/* Date de création :  07/11/2019 16:17:15                      */
/*==============================================================*/

/*==============================================================*/
/* Table : AGENCE                                               */
/*==============================================================*/
create table AGENCE  (
   NUMAGENCE            INTEGER                          not null,
   NOMAGENCE            LONG,
   constraint PK_AGENCE primary key (NUMAGENCE)
);

/*==============================================================*/
/* Table : CLIENT                                               */
/*==============================================================*/
create table CLIENT  (
   NUMCLIENT            INTEGER                          not null,
   NOMCLIENT            LONG,
   ADRESSECLIENT        LONG,
   CPCLIENT             INTEGER,
   LIBELLECLIENT        LONG,
   constraint PK_CLIENT primary key (NUMCLIENT)
);

/*==============================================================*/
/* Table : CONCERNE_QUANTITE_LOUEE                              */
/*==============================================================*/
create table CONCERNE_QUANTITE_LOUEE  (
   NUMCONTRAT           INTEGER                          not null,
   REFPRODUIT           INTEGER                          not null,
   constraint PK_CONCERNE_QUANTITE_LOUEE primary key (NUMCONTRAT, REFPRODUIT)
);

/*==============================================================*/
/* Table : CONTRAT                                              */
/*==============================================================*/
create table CONTRAT  (
   NUMCONTRAT           INTEGER                          not null,
   NUMCLIENT            INTEGER                          not null,
   DATEDEBUT            DATE,
   DUREELOC             INTEGER,
   constraint PK_CONTRAT primary key (NUMCONTRAT)
);

/*==============================================================*/
/* Table : POSSEDE_QUANTITE_DISPO                               */
/*==============================================================*/
create table POSSEDE_QUANTITE_DISPO  (
   NUMAGENCE            INTEGER                          not null,
   REFPRODUIT           INTEGER                          not null,
   constraint PK_POSSEDE_QUANTITE_DISPO primary key (NUMAGENCE, REFPRODUIT)
);

/*==============================================================*/
/* Table : PRODUIT                                              */
/*==============================================================*/
create table PRODUIT  (
   REFPRODUIT           INTEGER                          not null,
   DESIGNATION          LONG,
   PRIX                 FLOAT,
   constraint PK_PRODUIT primary key (REFPRODUIT)
);

/*==============================================================*/
/* Table : SIGNE_DANS                                           */
/*==============================================================*/
create table SIGNE_DANS  (
   NUMAGENCE            INTEGER                          not null,
   NUMCONTRAT           INTEGER                          not null,
   constraint PK_SIGNE_DANS primary key (NUMAGENCE, NUMCONTRAT)
);

alter table CONCERNE_QUANTITE_LOUEE
   add constraint FK_CONCERNE_CONCERNE__CONTRAT foreign key (NUMCONTRAT)
      references CONTRAT (NUMCONTRAT);

alter table CONCERNE_QUANTITE_LOUEE
   add constraint FK_CONCERNE_CONCERNE__PRODUIT foreign key (REFPRODUIT)
      references PRODUIT (REFPRODUIT);

alter table CONTRAT
   add constraint FK_CONTRAT_SIGNE_PAR_CLIENT foreign key (NUMCLIENT)
      references CLIENT (NUMCLIENT);

alter table POSSEDE_QUANTITE_DISPO
   add constraint FK_POSSEDE__POSSEDE_Q_AGENCE foreign key (NUMAGENCE)
      references AGENCE (NUMAGENCE);

alter table POSSEDE_QUANTITE_DISPO
   add constraint FK_POSSEDE__POSSEDE_Q_PRODUIT foreign key (REFPRODUIT)
      references PRODUIT (REFPRODUIT);

alter table SIGNE_DANS
   add constraint FK_SIGNE_DA_SIGNE_DAN_AGENCE foreign key (NUMAGENCE)
      references AGENCE (NUMAGENCE);

alter table SIGNE_DANS
   add constraint FK_SIGNE_DA_SIGNE_DAN_CONTRAT foreign key (NUMCONTRAT)
      references CONTRAT (NUMCONTRAT);

