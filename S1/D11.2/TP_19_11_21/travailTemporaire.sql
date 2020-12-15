/*==============================================================*/
/* Nom de SGBD :  ORACLE Version 8                              */
/* Date de création :  21/11/2019 10:47:29                      */
/*==============================================================*/


/*==============================================================*/
/* Table : CLIENTS                                              */
/*==============================================================*/
create table CLIENTS  (
   CODE_CLIENT          INTEGER                          not null,
   RS_CLIENT            LONG,
   ADR_CLIENT           LONG,
   CP_CLIENT            INTEGER,
   TEL_CLIENT           INTEGER,
   constraint PK_CLIENTS primary key (CODE_CLIENT)
);

/*==============================================================*/
/* Table : CONTRATS                                             */
/*==============================================================*/
create table CONTRATS  (
   NUM_CONTRAT          INTEGER                          not null,
   CODE_CLIENT          INTEGER                          not null,
   DESC_CONTRAT         LONG,
   DATE_DEBUT           DATE,
   constraint PK_CONTRATS primary key (NUM_CONTRAT)
);

/*==============================================================*/
/* Index : DEMANDE_FK                                           */
/*==============================================================*/
create index DEMANDE_FK on CONTRATS (
   CODE_CLIENT ASC
);

/*==============================================================*/
/* Table : EMPLOYES                                             */
/*==============================================================*/
create table EMPLOYES  (
   ID_EMP               INTEGER                          not null,
   NOM_EMP              LONG,
   PRENOM_EMP           LONG,
   TELPORT_EMP          INTEGER,
   constraint PK_EMPLOYES primary key (ID_EMP)
);

/*==============================================================*/
/* Table : INTERVIENT                                           */
/*==============================================================*/
create table INTERVIENT  (
   NUM_CONTRAT          INTEGER                          not null,
   ID_EMP               INTEGER                          not null,
   CODE_QUALIF          INTEGER                          not null,
   NB_JOUR_TRAVAIL      FLOAT,
   constraint PK_INTERVIENT primary key (NUM_CONTRAT, ID_EMP, CODE_QUALIF)
);

/*==============================================================*/
/* Index : INTERVIENT_FK                                        */
/*==============================================================*/
create index INTERVIENT_FK on INTERVIENT (
   NUM_CONTRAT ASC
);

/*==============================================================*/
/* Index : INTERVIENT2_FK                                       */
/*==============================================================*/
create index INTERVIENT2_FK on INTERVIENT (
   ID_EMP ASC
);

/*==============================================================*/
/* Index : INTERVIENT3_FK                                       */
/*==============================================================*/
create index INTERVIENT3_FK on INTERVIENT (
   CODE_QUALIF ASC
);

/*==============================================================*/
/* Table : NECESSITE                                            */
/*==============================================================*/
create table NECESSITE  (
   NUM_CONTRAT          INTEGER                          not null,
   CODE_QUALIF          INTEGER                          not null,
   NB_JOUR_HOMME        FLOAT,
   constraint PK_NECESSITE primary key (NUM_CONTRAT, CODE_QUALIF)
);

/*==============================================================*/
/* Index : NECESSITE_FK                                         */
/*==============================================================*/
create index NECESSITE_FK on NECESSITE (
   NUM_CONTRAT ASC
);

/*==============================================================*/
/* Index : NECESSITE2_FK                                        */
/*==============================================================*/
create index NECESSITE2_FK on NECESSITE (
   CODE_QUALIF ASC
);

/*==============================================================*/
/* Table : POSSEDE                                              */
/*==============================================================*/
create table POSSEDE  (
   CODE_QUALIF          INTEGER                          not null,
   ID_EMP               INTEGER                          not null,
   constraint PK_POSSEDE primary key (CODE_QUALIF, ID_EMP)
);

/*==============================================================*/
/* Index : POSSEDE_FK                                           */
/*==============================================================*/
create index POSSEDE_FK on POSSEDE (
   CODE_QUALIF ASC
);

/*==============================================================*/
/* Index : POSSEDE2_FK                                          */
/*==============================================================*/
create index POSSEDE2_FK on POSSEDE (
   ID_EMP ASC
);

/*==============================================================*/
/* Table : QUALIF                                               */
/*==============================================================*/
create table QUALIF  (
   CODE_QUALIF          INTEGER                          not null,
   NOM_QUALIF           LONG,
   TARIF_JOURN          FLOAT,
   constraint PK_QUALIF primary key (CODE_QUALIF)
);

alter table CONTRATS
   add constraint FK_CONTRATS_DEMANDE_CLIENTS foreign key (CODE_CLIENT)
      references CLIENTS (CODE_CLIENT);

alter table INTERVIENT
   add constraint FK_INTERVIE_INTERVIEN_CONTRATS foreign key (NUM_CONTRAT)
      references CONTRATS (NUM_CONTRAT);

alter table INTERVIENT
   add constraint FK_INTERVIE_INTERVIEN_EMPLOYES foreign key (ID_EMP)
      references EMPLOYES (ID_EMP);

alter table INTERVIENT
   add constraint FK_INTERVIE_INTERVIEN_QUALIF foreign key (CODE_QUALIF)
      references QUALIF (CODE_QUALIF);

alter table NECESSITE
   add constraint FK_NECESSIT_NECESSITE_CONTRATS foreign key (NUM_CONTRAT)
      references CONTRATS (NUM_CONTRAT);

alter table NECESSITE
   add constraint FK_NECESSIT_NECESSITE_QUALIF foreign key (CODE_QUALIF)
      references QUALIF (CODE_QUALIF);

alter table POSSEDE
   add constraint FK_POSSEDE_POSSEDE_QUALIF foreign key (CODE_QUALIF)
      references QUALIF (CODE_QUALIF);

alter table POSSEDE
   add constraint FK_POSSEDE_POSSEDE2_EMPLOYES foreign key (ID_EMP)
      references EMPLOYES (ID_EMP);

