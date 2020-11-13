#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char *argv[]){
  int i;
  int M = atoi(argv[1]);
  int N = atoi(argv[2]);

  sleep(M);
  for(int x = 0; x<=N; x++){
    i = fork();
  

    if ( i ==  0) {
      printf(" Je suis le fils, mon PID vaut : %d et celui de mon pere %d\n", getpid(), getppid());
      exit(0);
    } else {
      sleep(1);
      printf(" Je suis le pere, mon PID vaut : %d et celui de mon fils %d\n", getpid() , i);
    }
  }
}