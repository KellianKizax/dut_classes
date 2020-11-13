#include <stdio.h>
#include <signal.h>
#include <unistd.h>

int main(int argc, char *argv[]){
    int pid;
    printf("pid?\n");
    scanf("%d", &pid);
    kill(pid,SIGUSR1);
}