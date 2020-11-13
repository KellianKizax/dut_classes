#include <stdio.h>
#include <sys/types.h>
#include <sys/uio.h>
#include <unistd.h>
#include <stdlib.h>
#include <fcntl.h>

#define MAXCHIFFRES 10


int main(int argc, char *argv[]) {
     int fic,g;
     char c;

     if( ( fic = open(argv [1] ,O_RDONLY) )<=0 )
          exit(0);

     if ( ( g = open(argv[2],O_WRONLY | O_CREAT, S_IRUSR |  S_IWUSR | S_IRGRP | S_IROTH) )<= 0 )
          exit(0);

     while ( read(fic,&c,1) != 0 )
     {
         write(g,&c,1);

     }
     close(fic);
     close(g);

}