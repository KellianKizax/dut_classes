#include "fonctions_sup_TP10.h"


int main(int argc, char *argv[]){

 if ( argc != 3) { printf(" Usage : %s nomDuProgramme fichierSauvegarde \n", argv[0]); exit(-1); }

char *fichierProg =  argv[1];
char *fichierRes =  argv[2];
int ficProg, ficRes; 

int pipeEnvoi[2], pipeRes[2];
pipe(pipeEnvoi);

 if (fork() > 0) {  // Le père ouvre le fichier programme et l’envoi à son fils via le pipe pipeEnvoi
        ficProg = open(fichierProg, O_RDONLY);
        transfererFichier(ficProg, pipeEnvoi[1]);
   } else {   
           // Création du pipe et du petit-fils
           pipe(pipeRes);
           if (fork() > 0) {  
                 exec_sauvProg(pipeEnvoi[0], pipeRes[1]);     // Le fils lit le pipe pipeEnvoi, exécute les instructions et les transfère
                 } else {
                 // Le petit-fils lit le pipeRes et enregistre dans  fichier
  		 ficRes = open(fichierRes,O_WRONLY | O_CREAT, S_IRUSR | S_IWUSR);
 		 transfererFichier(pipeRes[0],ficRes);
          }
   }
}