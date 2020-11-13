#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char *argv[]){
	char * commandes[4];
	commandes[0] = "./multifork";
	commandes[1] = argv[1];
	commandes[2] = argv[2];
	commandes[3] = NULL;
	execv(commandes[0],commandes);
}