#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <errno.h>  
#include <sys/wait.h>
#include <sys/types.h>
#include <sys/stat.h>

int main() {

    if (mkfifo("./FP1.pipe",                   ...                        ) == -1) {
        
        if (errno == EEXIST) {
            /* nop : c'est juste que le fichier existe dejà */
            }
        else {
            perror("Création du fichier de pipe nommé : ");
            exit(errno);
            }
    }; 

    int FP1 = open(... , ... );// ouverture en écriture seule
    char * c = "Hello";  write(... , ... ,...);  
    close( ... );
}