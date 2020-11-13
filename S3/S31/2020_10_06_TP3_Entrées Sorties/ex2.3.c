#include <stdio.h>
#include <sys/types.h>
#include <sys/uio.h>
#include <unistd.h>
#include <stdlib.h>
#include <fcntl.h>

#define MAX_CHIFFRES 10

int lireEntier(int file) {
    char nbr[MAX_CHIFFRES]; // une chaine de caractères a transformer en entier
    int i = 0;
    char c;

    do {
        read(file,&c,1); // Lire un caractère dans le fichier
        if( c != '\0' ) {
            nbr[i] = c;
            i++;
        }
    } while(( c != ';' && c != '\n' )); // Arret lorsqu'elle lit un /n ou un ';'

    nbr[i-1] = '\0'; // Marque la fin de la chaîne de caractères

    int r = atoi(nbr); // Transformation de la chaîne de caractères en un int
    return r;
}

int main(int argc, char *argv[]){
    int file = open(argv[1], O_RDONLY);

    printf("%d \n",lireEntier(file));

    close(file);

    return 0;
}