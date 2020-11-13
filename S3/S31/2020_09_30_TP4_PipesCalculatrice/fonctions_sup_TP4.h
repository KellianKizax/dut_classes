/* TP 3 -  Fonctions supplémentaire  */


/***************************
**
** Deux fonctions de converstion int <-> chaine de caractères
**  
** On suppose que chaque entier est formé de MAXCHIFFRES chiffres
**
***************************/

#define MAXCHIFFRES 10

/** Fonction qui lit lire un entier dans un programme à partir de la position courante **/ 
int lireEntier(int ficProg ) {

   char nbr[MAXCHIFFRES+1];  // Une chaîne de caractères à transformer en entier
   int i =0; 
   char c;
   do {
    read( ficProg , &c , 1);  // Lire un caractère dans le fichier 
    if ((c != ' ')) { nbr[i] = c; i++;}  // Ignore les espaces
   } while ((c != '\n')&&(c != ';'));   // Arrêt lors qu'elle lit un \n ou un ';'
   
   nbr[i-1] = '\0';  // Marque la fin de la chaîne de caractère
  
   int r = atoi(nbr) ;   // Transformation la chaîne de caractère en un int
   return r;   //Renvoie de cet entier 
}

#include <string.h>

/* Fonction permettant de transformer un entier E en une chaîne de caractères Res : retourne la longueur de la chaîne */
int itoa(char *Res, int I) {
   /*   La fonction sprintf  est très souvent utilisée pour transformer un entier en une chaînes de caractères */
  sprintf(Res,"%d",I);
  return(strlen(Res));
}

/**************************
**
** Exo 1.1 - Les Fonctions complémentaires
**
***************************/

/** Fonction qui retourne le nombre d'instructions **/
int nbrInstr(int ficProg) {
      // On se positionne en début des fois que le fichier aie déjà été lu en partie
      lseek(ficProg, 0,SEEK_SET);
      // On lit en entier dans le fichier
      int n = lireEntier(ficProg);
      return n;
}

/** Fonction qui affiche le programme sur la sortie standard **/
void afficheProg(int ficProg) {
     char c;
     lseek(ficProg, 0, SEEK_SET);                	 // Positionnement en début de fichier
     while (read(ficProg,&c,1)) write(1, &c, 1); 	// On affiche sur la sortie standard
}

/** Fonction qui affiche la liste des instructions  **/
void afficheListeInst(int ficProg) {
  int op[5];

  lseek(ficProg, 0, SEEK_SET);                // Positionnement en début de fichier
  int Nbr_Inst  =  nbrInstr(ficProg);           		// Lecture du nombre d'instructions
 
  for(int i=0; i< Nbr_Inst; i++) {                        	 // On va afficher les instructions une à une 
    op[0] = lireEntier(ficProg);
    op[1] = lireEntier(ficProg);
    op[2] = lireEntier(ficProg); 
    op[3] = lireEntier(ficProg);  
    op[4] = lireEntier(ficProg);
    printf("instruction %d : codeOp : %d arg 1 : %d arg 2 : %d\n",i+1,  op[0], op[1], op[2]);
  }
}

/**********************************
**
** Exo 1.3
**
**********************************/

/* Fonction qui exécute la liste des instructions */
void executerProg(int ficProg) {
 
  lseek(ficProg, 0, SEEK_SET);                // Positionnement en début de fichier
  int Nbr_Inst  =  nbrInstr(ficProg);           		// Lecture du nombre d'instructions
  int myOP[5];

 for(int i=0; i< Nbr_Inst; i++) {                         	// On va exécuter les instructions une à une 
    myOP[0] = lireEntier(ficProg);
    myOP[1] = lireEntier(ficProg);
    myOP[2] = lireEntier(ficProg); 
    myOP[3] = lireEntier(ficProg);  
    myOP[4] = lireEntier(ficProg);     
     calcule(myOP);
     printf("instruction %d : codeOp : %d arg 1 : %d arg 2 : %d res1 : %d res2 : %d\n",i+1, myOP[0], myOP[1], myOP[2], myOP[3], myOP[4]);

  }
}

/**********************************
**
** Exo 1.5
**
**********************************/

/* Fonction qui sauvegarde le résultat de l'exécution de la N-ieme instruction  dans un fichier */
void sauvegardeOP(int N, int myOP[], int ficRes) {

  char nbr[MAXCHIFFRES+1];   // Utilisé pour mettre l'entier sous forme d'une chaîne de caractères 
  int a = 0;  // Le nombre dans cette chaîne

  write(ficRes,"Inst ", 5); 
  a = itoa(nbr, N);          // Le numéro de l'instruction est transformé en chaîne de caractères
  write(ficRes, nbr, a);   // Cette chaîne est mise dans le fichier 

  // Sauvegarde du Code OP :
  write(ficRes," - Code : ",10);
  a = itoa(nbr, myOP[1]);       // Le code opération de l'instruction est transformé en chaîne de caractères
  write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

  // Sauvegarde des deux arguments :
  write(ficRes," Args : ",8);
  a = itoa(nbr, myOP[1]);      // Le premier argument est transformé en chaîne de caractères
  write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

  write(ficRes," ",1);  // Ajout d'un espace entre les valeurs du résulat

  a = itoa(nbr, myOP[2]);      // Le deuxième argument est transformé en chaîne de caractères
  write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

  // Sauvegarde des deux résultats
  write(ficRes," Résultats : ",13);
  a = itoa(nbr, myOP[3]);      // Le premier résultat est transformé en chaîne de caractères
  write(ficRes, nbr, a);          // Cette chaîne est mise dans le fichier 

  write(ficRes," ",1);  // Ajout d'un espace entre les valeurs du résulat
      
  a = itoa(nbr, myOP[4]);      // Le deuxième résultat  est transformé en chaîne de caractères
  write(ficRes, nbr, a);    // Cette chaîne est mise dans le fichier 

  // Enfin on ajoute un retour à la ligne
  char c = '\n';
  write(ficRes,&c,1);
}



/**********************************
**
** Exo 1.6
**
**********************************/
/** Fonction qui exécute la liste des instructions **/
void exec_sauvProg(int ficProg, int ficRes) {
 
  lseek(ficProg, 0, SEEK_SET);                // Positionnement en début de fichier
  int Nbr_Inst  = nbrInstr(ficProg);           // Lecture du nombre d'instructions

  int myOP[5];
  for(int i=0; i< Nbr_Inst; i++) {                         // On va exécuter les instructions une à une 
    myOP[0] = lireEntier(ficProg);
    myOP[1] = lireEntier(ficProg);
    myOP[2] = lireEntier(ficProg); 
    myOP[3] = lireEntier(ficProg);  
    myOP[4] = lireEntier(ficProg);     
    calcule(myOP);
    sauvegardeOP(i, myOP, ficRes);
  }
}


void transfererFichier(int pI, int pE)
{
  char c;
  while (read(pI,&c,1) && c !='\t') write(pE, &c, 1);
}




