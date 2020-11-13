#include "fonctions_sup_TP8.h"
#include <pthread.h>


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
    for ( N = 1; N <= nbr_instructions; N++ ) {
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

/***************************************
**
**    Le main
**
****************************************/
int main(int argc, char *argv[]){

    if ( argc != 3){
        printf("Syntaxe : %s <nom_fichier_prog> <nom_fichier_resultat>\n", argv[0] );
        exit( EXIT_FAILURE );
    }

    char *fichierProg =  argv[1];
    char *fichierRes =  argv[2];

    int ficProg = open(fichierProg, O_RDONLY);
    int ficRes = open(fichierRes,O_WRONLY | O_CREAT, S_IRUSR | S_IWUSR);

    int pipeEnvoi[2];
    pipe(pipeEnvoi);
    pthread_t tcalc;

    struct ArgumentsThread myArg;
    myArg.fileIn = pipeEnvoi[0];
    myArg.fileOut = ficRes;

    pthread_create (&tcalc, NULL, exec_sauvProg, (void*)&myArg );

    // Le père envoie le fichier programme à son fils via le pipe
    transfererFichier(ficProg, pipeEnvoi[1]);

    pthread_join(tcalc, NULL);
    
    return 0;
}