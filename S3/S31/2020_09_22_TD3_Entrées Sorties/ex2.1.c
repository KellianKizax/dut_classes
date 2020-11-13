#include <fcntl.h>
#include <stdlib.h>
#include <sys/stat.h>

int main(int argc, char *argv[]){
    
    int f,g;
    char c;

    if(( f = open(argv[1], O_RDONLY)) <= 0) exit(0);

    if((g = open(argv[2], O_WRONLY | O_CREAT, S_IRUSR | S_IWUSR | S_IRGRP | S_IROTH )) <= 0) exit(0);

    while(read(f,&c,1) != 0) write(g,&c,1);

    close(f); close(g);

    return 0;
}