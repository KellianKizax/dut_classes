#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char *argv[]){
	if(argc != 4){
		printf(" Usage : %s codeOp arg1 arg2 \n",argv[0]); 
    	return -1;
	}

	char * commandes[5];
	commandes[0] = "./calculatrice";
	commandes[1] = argv[1];
	commandes[2] = argv[2];
	commandes[3] = argv[3];
	commandes[4] = NULL;
	execv(commandes[0], commandes);
}