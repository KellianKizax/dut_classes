#include <calculatrice.h>
#include <fonctions_sup_TP4.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <errno.h>  
#include <sys/wait.h>
#include <sys/types.h>
#include <sys/stat.h>

#include <fcntl.h>
#include <stdlib.h>
#include <sys/stat.h>


int main(int argc, char *argv[]){

    if ( argc != 2) { printf(" Usage : %s nomDuProgramme \n", argv[0]); exit(-1); }

/**********************
**
** Exo 1.1.2
**
**********************/
    mkfifo("./FP1.pipe", S_IRUSR|S_IWUSR|S_IRGRP|S_IWGRP); 

    if (fork() > 0) {  // Le père ouvre le fichier programme et l’envoi à son fils via le pipe pipeEnvoi
        char *fichierProg =  argv[1];
        int ficProg;

        if ( ( ficProg = open( fichierProg, O_RDONLY ) ) <= 0 ) { 
            perror("Ouverture du fichier programme :");
            exit(-2);
        }
        //....
    }
    else {   // Le fils lit le pipe pipeEnvoi, exécute les instructions
        //...
    }

    return(0);
}
