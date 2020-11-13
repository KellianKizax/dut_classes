// Les includes normaux
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>  
#include <string.h>
#include <pthread.h>
#include <signal.h>


int glob = 3; 

void nop( int s ) { printf( "Signal recu %d\n", s ); }

static void *tacheA (void *argA) {

    struct paramsTacheA {
        char *name;
        pthread_t tb;
    };

    struct paramsTacheA *pA = (struct paramsTacheA*) argA;

    printf ("TacheA (%s) P %d %d\n",pA->name,getpid(),glob); 

    // Création d'un masque
    sigset_t set;
    sigemptyset( &set );
    sigaddset( &set, SIGUSR2 ); // création du masque
    pthread_sigmask( SIG_UNBLOCK, &set, NULL ); // Débloquage de SIGUSR2 (il peut être recu)
    pause();
    
    glob ++;
    
    pthread_kill( pA->tb, SIGUSR1 );
    printf ("TacheA (%s) P %d %d %d\n",pA->name,(int)pthread_self(), getpid(),glob);
    
    return "A";
}

static void *tacheB (void *argB) { 
    // Création d'un masque
    sigset_t set;
    sigemptyset( &set );
    sigaddset( &set, SIGUSR1 ); // création du masque
    pthread_sigmask( SIG_UNBLOCK, &set, NULL ); // Débloquage de SIGUSR1 (il peut être recu)
    pause();

        printf ("TacheB (%s) P %d %d\n", (char*) argB,getpid(),glob); 
        glob ++;
        printf ("TacheB (%s) P %d %d %d\n", (char*) argB,(int)pthread_self(),getpid(),glob);
        
        return "B";
}

int main(int argc, char *argv[]){

    pthread_t ta = NULL, tb = NULL;
    struct sigaction new_action;
    sigset_t set;

    // Création des signaux
    new_action.sa_handler = nop;
    sigaction( SIGUSR1, &new_action, NULL );
    sigaction( SIGUSR2, &new_action, NULL );

    // Création d'un masque
    sigemptyset( &set );
    sigaddset( &set, SIGUSR2 );
    pthread_sigmask( SIG_BLOCK, &set, NULL );

    struct paramsTacheA {
        char *name;
        pthread_t tb;
    };

    struct paramsTacheA pA;
    pA.name = "A";
    pA.tb = tb;

    // Création des threads
	pthread_create (&ta, NULL, tacheA, &pA );
	pthread_create (&tb, NULL, tacheB, "B");
 	
    pthread_join(ta, NULL);
    pthread_join(tb, NULL);
	
    glob++;
   	
    printf ("Pere (%d) %d \n", getpid(), glob );
			
 }