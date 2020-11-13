#include <stdio.h>
#include <sys/types.h>
#include <sys/uio.h>
#include <unistd.h>
#include <stdlib.h>
#include <fcntl.h>

#define MAXCHIFFRES 10


int main(int argc, char *argv[]) {
    int oldFile,newFile,len,i;
    char tmp;

    if( ( oldFile = open(argv [1] ,O_RDONLY) )<=0 )
        exit(0);

    if ( ( newFile = open(argv[2],O_WRONLY | O_CREAT, S_IRUSR |  S_IWUSR | S_IRGRP | S_IROTH) )<= 0 )
        exit(0);

    len = lseek(oldFile,0,SEEK_END);
    lseek(oldFile,-1,SEEK_END);
    i=0;
    while (i<len)
    {
        i++;
        lseek(oldFile,-i,SEEK_END);
        read(oldFile,&tmp,1);
        write(newFile,&tmp,1);
    }

    close(oldFile);
    close(newFile);
}