#include "fonctions_sup_TP8b.h"


/****** Pour vous aider voici l'ancien code ******************

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

*****************************************************
****************************************************/



/***********************************************
** La nouvelle fonction de lecture et transfert de fichier
**  (Remplace le fonction transfererFichier du  fichier fonctions_sup_TP8.h)
**
************************************************/
void * transfererFichierThread( void* lesArguments ) {

    struct ArgumentsThread* argPipe = (struct ArgumentsThread*) lesArguments;

    int pI = argPipe->fileIn;
    int pE = argPipe->fileOut;
  
    char c;
    while (read (pI, &c,1)) {
        if (c == '\t')
            return NULL;
        else
            write(pE,&c,1);
    }

    return NULL;
 }

/***************************************
**
**    Le main
**
****************************************/
int main(int argc, char *argv[]){

    char *fichierProg =  argv[1];
    char *fichierRes =  argv[2];

    if ( argc != 3) {
        printf(" Usage : %s nomDuProgramme nomFichierRes \n", argv[0]);
        exit(-1);
    }

    int ficProg, ficRes;
    if ( (ficProg = open(fichierProg, O_RDONLY)) < 0 )
        exit(-2);
    if ( (ficRes = open( fichierRes,O_WRONLY | O_CREAT, S_IRUSR |  S_IWUSR | S_IRGRP | S_IROTH )) < 0 )
        exit(-2);

    int pipeEnvoi[2];
    pipe(pipeEnvoi);

    int pipeRes[2];
    pipe(pipeRes);
 
    struct ArgumentsThread arguments_Fils1, arguments_Fils2, arguments_Fils3;


    /***********************************************
    **
    ** Ce thread 1 fait lit les instructions et les transfère
    **
    ***********************************************/

    arguments_Fils1.fileIn = ficProg;
    arguments_Fils1.fileOut = pipeEnvoi[1];

    pthread_t ttransf;
    pthread_create( &ttransf, NULL, transfererFichierThread, (void*)&arguments_Fils1 );

    /***********************************************
    **
    ** Ce thread 2 fait les calculs et les met dans le nouveau pipe
    **
    ***********************************************/
  
    arguments_Fils2.fileIn = pipeEnvoi[0];
    arguments_Fils2.fileOut = pipeRes[1];

    pthread_t tcalc;
    pthread_create(&tcalc , NULL, exec_sauvProg, (void *)&arguments_Fils2 ) ;

  /***********************************************
  **
  ** Ce thread 3 lit le pipe et sauvegarde dans le fichier 
  **
  ***********************************************/
 
  arguments_Fils3.fileIn = pipeRes[0];
  arguments_Fils3.fileOut = ficRes;

  pthread_t tsave;
  pthread_create ( &tsave, NULL, exec_sauvProg, (void*)&arguments_Fils3 );

 /*********************************************
**
** Le père doit attendre  la fin des processus légers
**
**********************************************/
  pthread_join(ttransf, NULL);
  printf(" Transfert termine\n");

  pthread_join( tcalc, NULL);
  printf(" thread tcalc termine\n");
   
  pthread_join( tsave, NULL);
  printf(" thread save terminé\n");

 return 0;

}
