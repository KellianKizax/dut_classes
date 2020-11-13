#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <errno.h>  
#include <sys/wait.h>

int main(int argc, char *argv[]){
 
    int i = 0; 
    int fda[2];   // Pipe entre le père et le fils
    int fdb[2];

    // Création du pipe 
    pipe(fda);
    pipe(fdb); 

    if (fork() == 0) {    
        char *c = "J'adore ce TD";
        i = strlen(c)+1;
        write(fda[1], c , i);
        printf(" Texte écrit %d par le fils : %s \n",i, c);

        // Lecture de la réponse
        char lu[100]; 
        i = 0;
        do {
            read(fdb[0], &lu[i], 1);
            i++; 
        } while ((lu[i-1] != '\0') && (i<100));

        printf(" Caractères lus %d par le fils : %s \n",i, lu); 

    }
    else {
        char lu[100]; 
        
        do {
            read(fda[0], &lu[i], 1);
            i++; 
        } while ((lu[i-1] != '\0') && (i<100));
        
        printf(" Caractères lus %d par le père : %s \n",i, lu); 
        
        char *rep = "Moi aussi et en mieux" ;  
        
        // Envoi de la réponse 
        i = strlen(rep)+1;
        write(fdb[1], rep , i);
        
        printf(" Texte écrit %d par le pere : %s \n",i, rep);
    }
    return (0);
}