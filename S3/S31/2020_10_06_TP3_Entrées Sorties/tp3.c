#include "calculatrice.h"
#include "fonctions_sup_TP3.h"


int main(int argc, char *argv[]){

  if ( argc != 3) { printf(" Usage : %s nomDuProgramme nomFichierRes \n", argv[0]); exit(-1); }

/**********************
**
** Exo 1.2
**
**********************/

  char *fichierProg =  argv[1];
  int ficProg;
  char *fichierRes =  argv[2];
  int ficRes;

 
  // Ouverture du fichier Prog
  if ((ficProg = open(fichierProg, O_RDONLY) ) < 0) {
	  perror("Ouverture de fichierProg : ");  exit(-2);
  }

  // Affichage du contenu
  afficheProg(ficProg);

  // Lecture du nombre d'instructions
  int nbr_instructions = nbrInstr(ficProg);
  printf(" Nombre d 'instructions dans %s : %d\n",fichierProg , nbr_instructions);
  
  // Affichage du contenu
  afficheListeInst(ficProg);

  /**********************
  **
  ** Exo 1.4
  **
  **********************/
  // Exécution du programme
  executerProg(ficProg);

  /**********************
  **
  ** Exo 1.6
  **
  **********************/
  // Exécution du programme avec sauvegarde
  // Ouverture du fichier Resultat : le fichier est crée s'il n'existe pas
  if ((ficRes = open(fichierRes, O_WRONLY | O_CREAT, S_IRUSR |  S_IWUSR | S_IRGRP | S_IROTH) ) < 0) {
	  perror("Ouverture de fichierRes : ");  exit(-2);
  }

  // Execution et sauvegarde  :
  exec_sauvProg(ficProg, ficRes);

  /*********************
  **
  **  Pour finir proprement
  **
  **********************/
  close(ficProg);
  // close(ficRes);
 
  return(0);
}
