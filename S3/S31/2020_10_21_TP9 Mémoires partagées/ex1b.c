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

void nop( int signum ) { }

int main() {

    char * filename = "bin/dpkg";
    int proid = 99; 
   
    key_t myClef = (key_t) ftok( filename, proid );
 
    int  sm = -1;
    if ( ( sm = shmget( myClef, 100 , IPC_CREAT | IPC_EXCL | SHM_R | SHM_W ) ) == -1 ) {
        perror("dans shmget");
        exit(1);
    }
    
    char* mem = shmat( sm, 0, SHM_R );  if ( mem == (char*) ( -1 ) ) { exit(1); }

    sleep(1);      // Pour attendre que le premier processus est fini de transférer  
   
    // Afficher le contenu écrit par l'autre processus  
    printf( "Dans P2 je reçoit  = %s\n", mem );
 
    // Détacher le segment de mémoire partagée.
    shmdt( mem ); 
}