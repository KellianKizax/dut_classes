#include "calculatrice.h"
#include <sys/types.h>
#include <sys/wait.h>

int main(int argc, char *argv[]){
  // Déclaration et création d'un template d'instruction 
 int myOP[5] = { 0, 0, 0, 0, 0};

// Test paramètres
  if (argc != 4) {
    printf(" Usage : %s codeOp arg1 arg2 \n",argv[0]); 
    return -1;
  }
 
 // Initialisation de l'instruction
  myOP[0] = atoi(argv[1]);
  myOP[1] = atoi(argv[2]);
  myOP[2] = atoi(argv[3]);  
 
 // Exécution de l'instruction
 int i = fork();
 int status;

 if(i==0){
  sleep(1);
  calcule(myOP);
  // Affichage du résultat
  printf(" Res : %d %d \n", myOP[3], myOP[4]);
  exit(0);
 }
 else{
   waitpid(i,&status,0);
 }

  printf("Le processus s'est terminé avec le code d'erreur %d\n", WEXITSTATUS(status));
}