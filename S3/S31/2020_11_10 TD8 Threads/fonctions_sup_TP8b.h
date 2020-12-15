/******************
** Includes communs 
*******************/
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <fcntl.h>
#include <pthread.h>

#define MAXCHIFFRES 10


/**************************
**  Partie 1 : Fonctions de base
***************************/


/**Lit un entier dans un programme à partir de la position courante **/ 
int lireEntier(int ficProg ) {
    char nbr[MAXCHIFFRES+1];  // Une chaîne de caractères à transformer en entier
    int i =0; 
    char c;
    do {
        read( ficProg , &c , 1);  // Lire un caractère dans le fichier 
        if ((c != ' '))
            nbr[i] = c;
            i++;  // Ignore les espaces
    } while ( (c != '\n') && (c != ';') );   // Arrêt lors qu'elle lit un \n ou un ';'
   
    nbr[i-1] = '\0';  // Marque la fin de la chaîne de caractère
  
    int r = atoi(nbr) ;   // Transformation la chaîne de caractère en un int
    return r;   //Renvoie de cet entier 
 }


/* Fonction permettant de transformer un entier E en une chaîne de caractères Res : retourne la longueur de la chaîne */
int itoa(char *Res, int I) {
    /*   La fonction sprintf  est très souvent utilisée pour transformer un entier en une chaînes de caractères */
    sprintf(Res,"%d",I);
    return(strlen(Res));
}

/** Fonction qui exécute une instruction **/
void calcule(int OP[]) {
    switch (OP[0]) {
        case 1: OP[3] = OP[1] + OP[2]; break; 
        case 2: OP[3] = OP[1] - OP[2]; break;
        case 3: OP[3] = OP[1] * OP[2]; break;
        case 4: if (OP[2] !=0) OP[3] = OP[1] / (int) OP[2]; break;
        case 5: OP[3] = OP[1] / OP[2];
	    OP[4] = OP[1] % OP[2]; break;
    }
}


/**************************
**  Partie 2 : Fonctions d'E/S 
***************************/


/** Fonction qui retourne le nombre d'instructions **/
int nbrInstr(int ficProg) {
    // On se positionne en début des fois que le fichier aie déjà été lu en partie
    lseek(ficProg, 0, SEEK_SET);
    return lireEntier(ficProg);
}


/** Fonction qui affiche le programme sur la sortie standard **/
void afficheProg(int ficProg) {
    char c;
    lseek(ficProg, 0, SEEK_SET);                 // Positionnement en début de fichier
    while (read(ficProg,&c,1)) write(1,&c,1); // On affiche sur la sortie standard
}

/** Fonction qui affiche la liste des instructions  **/
void afficheListeInst(int ficProg) {
    int op[5];

    lseek(ficProg, 0, SEEK_SET);                // Positionnement en début de fichier
    int Nbr_Inst  = lireEntier(ficProg);           // Lecture du nombre d'instruction
 
    for(int i=0; i< Nbr_Inst; i++) { // On va afficher les instructions une à une 
        op[0] = lireEntier(ficProg);
        op[1] = lireEntier(ficProg);
        op[2] = lireEntier(ficProg); 
        op[3] = lireEntier(ficProg);  
        op[4] = lireEntier(ficProg);
        printf("instruction %d : codeOp : %d arg 1 : %d arg 2 : %d\n",i+1, op[0], op[1], op[2]);
    }
}


/** Fonction qui exécute la liste des instructions **/
void executerProg(int ficProg) {
 
    // lseek(ficProg, 0, SEEK_SET); // Positionnement en début de fichier
    int Nbr_Inst  = lireEntier(ficProg);  // Lecture du nombre d'instruction

    int myOP[5];
    for(int i = 0;i < Nbr_Inst ; i++) {   // On va exécuter les instructions une à une 
        myOP[0] = lireEntier(ficProg);
        myOP[1] = lireEntier(ficProg);
        myOP[2] = lireEntier(ficProg); 
        myOP[3] = lireEntier(ficProg);  
        myOP[4] = lireEntier(ficProg);
        calcule(myOP);
        printf("instruction %d : codeOp : %d arg 1 : %d arg 2 : %d res1 : %d res2 : %d\n",i+1, myOP[0], myOP[1], myOP[2], myOP[3], myOP[4]);
    }
}


/* Fonction qui sauvegarde le résultat de l'exécution de la N-ieme instruction  dans un fichier */
void sauvegardeOP(int N, int myOP[], int ficRes) {

    char nbr[MAXCHIFFRES+1];   // Utilisé pour mettre l'entier sous forme d'une chaîne de caractères 
    int a = 0;  // Le nombre dans cette chaîne

    write(ficRes,"Inst ",5); 
    a = itoa(nbr, N);          // Le numéro de l'instruction est transformé en chaîne de caractères
    write(ficRes, nbr, a);   // Cette chaîne est mise dans le fichier 

    // Sauvegarde du Code OP :
    write(ficRes," - Code : ",10);
    a = itoa(nbr, myOP[0]);      // Le code opération de l'instruction est transformé en chaîne de caractères
    write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

    // Sauvegarde des deux arguments :
    write(ficRes," Args : ",8);
    a = itoa(nbr, myOP[1]);      // Le premier argument est transformé en chaîne de caractères
    write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

    write(ficRes," ",1);  // Ajout d'un espace entre les valeurs du résulat

    a = itoa(nbr, myOP[3]);      // Le deuxième argument est transformé en chaîne de caractères
    write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

    // Sauvegarde des deux résultats
    write(ficRes," Résultats : ",13);
    a = itoa(nbr, myOP[4]);      // Le premier résultat est transformé en chaîne de caractères
    write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

    write(ficRes," ",1);  // Ajout d'un espace entre les valeurs du résulat
      
    a = itoa(nbr, myOP[5]);      // Le deuxième résultat argument est transformé en chaîne de caractères
    write(ficRes, nbr, a);         // Cette chaîne est mise dans le fichier 

    // Enfin on ajoute un retour à la ligne
    char c = '\n';
    write(ficRes,&c,1);
}


/****************************
**  Partie 3 : Fonctions de transfert 
*****************************/

/** Fonction qui transfère un fichier**/
void transfererFichier(int pI, int pE) {
    char c;
    while (read (pI, &c,1)) { 
        if (c == '\t')
            return;
        else
            write(pE,&c,1);
  }
}



/************************************
*
*  La structure de passage des paramètres aux threads
*
*************************************/
struct ArgumentsThread {
    int fileIn;
    int fileOut;
};

/***********************************************
**
** La NOUVELLE fonction de lecture  d'un programme, exécution et sauvegarde dans un fichier
**
************************************************/

void * exec_sauvProg(void *LesArguments) {
 
// On "redéfini" le type de l'argument pour pouvoir accéder à ses champs
 struct ArgumentsThread * Args = (struct ArgumentsThread *)LesArguments; 
 
int ficProg  = Args->fileIn;
int ficRes = Args->fileOut;

int myOP[5] = { 0, 0, 0, 0, 0}; 
 int N;
   
 // Lecture du nombre d'instructions
  int nbr_instructions = nbrInstr(ficProg);
  for(N=1; N<=nbr_instructions; N++){
    myOP[0] = lireEntier(ficProg);
    myOP[1] = lireEntier(ficProg);
    myOP[2] = lireEntier(ficProg); 
    myOP[3] = lireEntier(ficProg);  
    myOP[4] = lireEntier(ficProg);
    calcule(myOP);
    sauvegardeOP(N, myOP, ficRes);
  }
  char fin = '\t'; 
  write(ficRes, &fin, 1); 
  return NULL;
}