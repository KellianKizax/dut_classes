#include "calculatrice.h"
#include <sys/types.h>
#include <sys/wait.h>

void nop(int s){};

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
 
    OP=myOP;

    // Exécution de l'instruction
    int i = fork();
    int status;

    if(i==0){
        struct sigaction new_action;
    
        new_action.sa_handler = calcule;
        sigaction(SIGUSR1, &new_action, NULL);
        pause();

        // Affichage du résultat
        printf(" Res : %d %d \n", myOP[3], myOP[4]);
        exit(0);
    }
    else {
        sleep(1);
        kill(i,SIGUSR1);
        waitpid(i,&status,0);
    }

    printf("Le processus s'est terminé avec le code d'erreur %d\n", WEXITSTATUS(status));
}