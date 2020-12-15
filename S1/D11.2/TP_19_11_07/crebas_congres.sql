
/*==============================================================*/
/* Table : ASSOCIATION_6                                        */
/*==============================================================*/
create table ASSOCIATION_6  (
   CODE_SS              INTEGER                          not null,
   NUM_INSCRIPTION      INTEGER                          not null,
   constraint PK_ASSOCIATION_6 primary key (CODE_SS, NUM_INSCRIPTION)
);

/*==============================================================*/
/* Index : ASSOCIATION_6_FK                                     */
/*==============================================================*/
create index ASSOCIATION_6_FK on ASSOCIATION_6 (
   CODE_SS ASC
);

/*==============================================================*/
/* Index : ASSOCIATION_8_FK                                     */
/*==============================================================*/
create index ASSOCIATION_8_FK on ASSOCIATION_6 (
   NUM_INSCRIPTION ASC
);

/*==============================================================*/
/* Table : CATEGORIE_HOTEL                                      */
/*==============================================================*/
create table CATEGORIE_HOTEL  (
   CODE_CAT             INTEGER                          not null,
   LIBELLE_CAT          LONG,
   constraint PK_CATEGORIE_HOTEL primary key (CODE_CAT)
);

/*==============================================================*/
/* Table : CONGRESSISTES                                        */
/*==============================================================*/
create table CONGRESSISTES  (
   DATE_INSCRIPTION     DATE,
   NUM_INSCRIPTION      INTEGER                          not null,
   CODE_CAT             INTEGER,
   CODE_ENTREPRISE      INTEGER                          not null,
   NUM_HOTEL            INTEGER,
   NOM_CG               LONG,
   ADRESSE_CG           LONG,
   TEL_CG               INTEGER,
   ACCOMPTE_CG          FLOAT,
   ACCOMPAGNATEUR_CG    INTEGER,
   constraint PK_CONGRESSISTES primary key (NUM_INSCRIPTION)
);

/*==============================================================*/
/* Index : DORT_DANS_FK                                         */
/*==============================================================*/
create index DORT_DANS_FK on CONGRESSISTES (
   NUM_HOTEL ASC
);

/*==============================================================*/
/* Index : FINANCE_FK                                           */
/*==============================================================*/
create index FINANCE_FK on CONGRESSISTES (
   CODE_ENTREPRISE ASC
);

/*==============================================================*/
/* Index : ASSOCIATION_7_FK                                     */
/*==============================================================*/
create index ASSOCIATION_7_FK on CONGRESSISTES (
   CODE_CAT ASC
);

/*==============================================================*/
/* Table : ENTREPRISE                                           */
/*==============================================================*/
create table ENTREPRISE  (
   NOM_ENTREPRISE       LONG,
   ADRESSE_ENTREPRISE   LONG,
   CODE_ENTREPRISE      INTEGER                          not null,
   constraint PK_ENTREPRISE primary key (CODE_ENTREPRISE)
);

/*==============================================================*/
/* Table : HOTEL                                                */
/*==============================================================*/
create table HOTEL  (
   ADRESSE_HOTEL        LONG,
   NOM_HOTEL            LONG,
   PRIX_HOTEL           FLOAT,
   PRIX_ACC_HOTEL       FLOAT,
   TEL_HOTEL            INTEGER,
   NUM_HOTEL            INTEGER                          not null,
   CODE_CAT             INTEGER                          not null,
   constraint PK_HOTEL primary key (NUM_HOTEL)
);

/*==============================================================*/
/* Index : EST_DE_FK                                            */
/*==============================================================*/
create index EST_DE_FK on HOTEL (
   CODE_CAT ASC
);

/*==============================================================*/
/* Table : PARTICIPE_A                                          */
/*==============================================================*/
create table PARTICIPE_A  (
   CODE_SS              INTEGER                          not null,
   NUM_INSCRIPTION      INTEGER                          not null,
   constraint PK_PARTICIPE_A primary key (CODE_SS, NUM_INSCRIPTION)
);

/*==============================================================*/
/* Index : PARTICIPE_A_FK                                       */
/*==============================================================*/
create index PARTICIPE_A_FK on PARTICIPE_A (
   CODE_SS ASC
);

/*==============================================================*/
/* Index : PARTICIPE_A2_FK                                      */
/*==============================================================*/
create index PARTICIPE_A2_FK on PARTICIPE_A (
   NUM_INSCRIPTION ASC
);

/*==============================================================*/
/* Table : "SESSION"                                            */
/*==============================================================*/
create table "SESSION"  (
   CODE_SS              INTEGER                          not null,
   CODE_THEME           INTEGER                          not null,
   DATE_SS              DATE,
   H_DEBUT_SS           DATE,
   DATE_LIM_INSC_SS     DATE,
   NB_PLACE_DISPO_SS    INTEGER,
   PRES_SS              LONG,
   SALLE_SS             INTEGER,
   TARIF_SS             FLOAT,
   constraint PK_SESSION primary key (CODE_SS)
);

/*==============================================================*/
/* Index : ASSOCIATION_9_FK                                     */
/*==============================================================*/
create index ASSOCIATION_9_FK on "SESSION" (
   CODE_THEME ASC
);

/*==============================================================*/
/* Table : THEME_SESSION                                        */
/*==============================================================*/
create table THEME_SESSION  (
   CODE_THEME           INTEGER                          not null,
   LIBELLE_THEME        LONG,
   constraint PK_THEME_SESSION primary key (CODE_THEME)
);

alter table ASSOCIATION_6
   add constraint FK_ASSOCIAT_ASSOCIATI_SESSION foreign key (CODE_SS)
      references "SESSION" (CODE_SS);

alter table ASSOCIATION_6
   add constraint FK_ASSOCIAT_ASSOCIATI_CONGRESS foreign key (NUM_INSCRIPTION)
      references CONGRESSISTES (NUM_INSCRIPTION);

alter table CONGRESSISTES
   add constraint FK_CONGRESS_ASSOCIATI_CATEGORI foreign key (CODE_CAT)
      references CATEGORIE_HOTEL (CODE_CAT);

alter table CONGRESSISTES
   add constraint FK_CONGRESS_DORT_DANS_HOTEL foreign key (NUM_HOTEL)
      references HOTEL (NUM_HOTEL);

alter table CONGRESSISTES
   add constraint FK_CONGRESS_FINANCE_ENTREPRI foreign key (CODE_ENTREPRISE)
      references ENTREPRISE (CODE_ENTREPRISE);

alter table HOTEL
   add constraint FK_HOTEL_EST_DE_CATEGORI foreign key (CODE_CAT)
      references CATEGORIE_HOTEL (CODE_CAT);

alter table PARTICIPE_A
   add constraint FK_PARTICIP_PARTICIPE_SESSION foreign key (CODE_SS)
      references "SESSION" (CODE_SS);

alter table PARTICIPE_A
   add constraint FK_PARTICIP_PARTICIPE_CONGRESS foreign key (NUM_INSCRIPTION)
      references CONGRESSISTES (NUM_INSCRIPTION);

alter table "SESSION"
   add constraint FK_SESSION_ASSOCIATI_THEME_SE foreign key (CODE_THEME)
      references THEME_SESSION (CODE_THEME);

