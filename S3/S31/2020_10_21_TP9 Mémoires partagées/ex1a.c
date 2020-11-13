#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <errno.h> 
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <signal.h>

int main( int argc, char *argv[] ){

    char * filename = "/bin/dpkg";
    int proid = 99;
   
    key_t myClef = (key_t) ftok( filename, proid ) ;
 
    printf("a\n");

    int sm = -1;
    if ( ( sm = shmget( myClef, 100 , IPC_CREAT | IPC_EXCL | SHM_R | SHM_W ) ) == -1 ) {
        perror("dans shmget");
        exit(1);
    } 

    printf( "%d \n", sm );

    char* mem = shmat( sm, 0, SHM_W );
    if ( mem == (char*) (-1) ) { 
        perror("dans shmat");
        exit(1);
        }

    printf("%s \n", mem);

    int i = 0;
    do{
        mem[i] = argv[1][i];
    } while ( mem[i++]  != '\0' );   // On transfére le message

    printf("Dans P1 je transfere = %s\n", mem );

    // Libérer le segment de mémoire partagée.
    shmdt( mem ); 

    shmctl ( sm, IPC_RMID, 0 ); // Marque que le segment doit être supprimé.Cela ne sera fait effectivement qu'après le dernier détachement 


}