#include <stdio.h>
#include <sys/types.h>
#include <sys/uio.h>
#include <unistd.h>
#include <stdlib.h>
#include <fcntl.h>

#define MAXCHIFFRES 10



int main(int argc, char*argv[]){
    int fic,f;
    char c, tmp;

    fic = open(argv[1] ,O_RDONLY);

    int taille = Iseek(fic,0,SEEK_END);
    printf("taille du fichier %d :\n\n ", taille);

    int i =2;

    do{
        Iseek(fic, -i, SEEK_END);
        read(fic,&c,1);
        printf("%c\n",c);
        i++;
    } 
    while((i<=taille+1)&&(read(fic,&c,1)>0));

}