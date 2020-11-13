#include <stdio.h>
#include <stdlib.h>
 #include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <errno.h>  
#include <sys/wait.h>

int main(int argc, char *argv[]){

    int fd[2];   // Pipe entre le père et le fils 

    // Création du pipe 
    pipe(fd);
    int i;

    if ((i = fork()) == 0){
        char *c = argv[1];
        write(fd[1], c, strlen(c)+1);
        printf("Texte écrit (%ld caractères) par le fils : %s \n",strlen(c),c);
        }

    else {
        wait(&i);
        char d[100];

        int y = 0;
        do{
            read( fd[0], &d[y], 1);
            y++;
        }
        while(d[y-1] != '\0');

        printf("Caractères (%ld caractères) lus par le père : %s \n",strlen(d),d);
        }
}