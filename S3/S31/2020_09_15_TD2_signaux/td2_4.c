#include <stdio.h>
#include <signal.h>
#include <unistd.h>

int main(int argc, char *argv[]){

    struct sigaction oldAction;
    sigaction(SIGUSR1, &oldAction, NULL);

    if(oldAction.sa_handler == SIG_IGN){
        printf("Le signal est ignore \n");
    }
    else if(oldAction.sa_handler == SIG_DFL){
        printf("Signal par defaut \n");
    }
    else {
        printf("SIGUSR1 est associe a une fonction \n");
    }
}