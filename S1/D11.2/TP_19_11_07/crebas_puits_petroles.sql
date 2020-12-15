/*==============================================================*/
/* Nom de SGBD :  ORACLE Version 8                              */
/* Date de création :  14/11/2019 17:27:58                      */
/*==============================================================*/


/*==============================================================*/
/* Table : COMPAGNIE                                            */
/*==============================================================*/
create table COMPAGNIE  (
   CODE_CP              LONG                             not null,
   NOM_CP               LONG,
   NATIONALITE_CP       LONG,
   RESPONSABLE_CP       LONG,
   constraint PK_COMPAGNIE primary key (CODE_CP)
);

/*==============================================================*/
/* Table : MESURES_RESISTANCES                                  */
/*==============================================================*/
create table MESURES_RESISTANCES  (
   CODE_PT              LONG                             not null,
   CODE_PT_RES          LONG                             not null,
   RESISTANCE           FLOAT,
   constraint PK_MESURES_RESISTANCES primary key (CODE_PT, CODE_PT_RES)
);

/*==============================================================*/
/* Index : MESURES_RESISTANCES_FK                               */
/*==============================================================*/
create index MESURES_RESISTANCES_FK on MESURES_RESISTANCES (
   CODE_PT ASC
);

/*==============================================================*/
/* Index : MESURES_RESISTANCES2_FK                              */
/*==============================================================*/
create index MESURES_RESISTANCES2_FK on MESURES_RESISTANCES (
   CODE_PT_RES ASC
);

/*==============================================================*/
/* Table : PUITS_PETROLES                                       */
/*==============================================================*/
create table PUITS_PETROLES  (
   CODE_PT              LONG                             not null,
   CODE_TYPE            INTEGER                          not null,
   CODE_CP              LONG                             not null,
   DATE_OUVERTURE_PT    DATE,
   EAU_POURC_PT         NUMBER,
   GAZ_POURC_PT         NUMBER,
   PETROLE_QT_PT        FLOAT,
   constraint PK_PUITS_PETROLES primary key (CODE_PT)
);

/*==============================================================*/
/* Index : APPARTIENT_A_FK                                      */
/*==============================================================*/
create index APPARTIENT_A_FK on PUITS_PETROLES (
   CODE_CP ASC
);

/*==============================================================*/
/* Index : TYPE_DE_PETROLE_EXTRAIT_FK                           */
/*==============================================================*/
create index TYPE_DE_PETROLE_EXTRAIT_FK on PUITS_PETROLES (
   CODE_TYPE ASC
);

/*==============================================================*/
/* Table : RESISTANCES_DES_SOLS                                 */
/*==============================================================*/
create table RESISTANCES_DES_SOLS  (
   CODE_PT_RES          LONG                             not null,
   PROFONDEUR_RES       INTEGER,
   constraint PK_RESISTANCES_DES_SOLS primary key (CODE_PT_RES)
);

/*==============================================================*/
/* Table : TYPES_PETROLES                                       */
/*==============================================================*/
create table TYPES_PETROLES  (
   CODE_TYPE            INTEGER                          not null,
   LIBELLE_TYPE         LONG,
   constraint PK_TYPES_PETROLES primary key (CODE_TYPE)
);

alter table MESURES_RESISTANCES
   add constraint FK_MESURES__MESURES_R_PUITS_PE foreign key (CODE_PT)
      references PUITS_PETROLES (CODE_PT);

alter table MESURES_RESISTANCES
   add constraint FK_MESURES__MESURES_R_RESISTAN foreign key (CODE_PT_RES)
      references RESISTANCES_DES_SOLS (CODE_PT_RES);

alter table PUITS_PETROLES
   add constraint FK_PUITS_PE_APPARTIEN_COMPAGNI foreign key (CODE_CP)
      references COMPAGNIE (CODE_CP);

alter table PUITS_PETROLES
   add constraint FK_PUITS_PE_TYPE_DE_P_TYPES_PE foreign key (CODE_TYPE)
      references TYPES_PETROLES (CODE_TYPE);

