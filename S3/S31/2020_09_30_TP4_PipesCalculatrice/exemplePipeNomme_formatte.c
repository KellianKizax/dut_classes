#include <stdio.h>
#include <stdlib.h>
 #include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <errno.h>  
#include <sys/wait.h>
#include <sys/types.h>
#include <sys/stat.h>



//  MAIN
int main(int argc, char *argv[]){
 	
  char *c, d[100];
 
 
  // Création du pipe AVANT le fork pour éviter que chaque processus les crée
  ...("./FP1.pipe", S_IRUSR|S_IWUSR|S_IRGRP|S_IWGRP); 

  if ( fork() == 0) {
     
    
    // Ouverture du pipe
    ... * FP1 = fopen("./FP1.pipe",...);// ouverture en écriture seule
   
    c = "Hello"; 
    fprintf(FP1, "%s",c);
    printf(" Texte écrit par le fils sur FP1 : %s \n",c);

    
  }  else {
    
    // Ouverture du pipe 
     ... * FP1 = fopen("./FP1.pipe",...); // ouverture en lecture seule
    
    fscanf(FP1, "%s", d);
    printf(" Caractères lus par le père sur FP1 : %s \n",d);
  }

  return (0);
}

