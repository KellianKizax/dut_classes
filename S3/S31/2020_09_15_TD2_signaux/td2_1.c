#include <stdio.h>
#include <signal.h>
#include <unistd.h>

void frecu (int numSignal) {
    printf("La fonction frecu a ete appelee a la reception du signal %d\n", numSignal);
}

int main(int argc, char *argv[]){
    struct sigaction new_action;
    new_action.sa_handler = frecu;
    
    sigaction(SIGUSR1, &new_action, NULL);
    sigaction(SIGUSR2, &new_action, NULL);
    
    pause();
}