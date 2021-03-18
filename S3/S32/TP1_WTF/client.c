#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>
#include <string.h>
#include <signal.h>
#include <unistd.h>
#include <time.h>

void fonc_action( int s ) {
    printf("Aucun message reçu.\n");
    exit(EXIT_SUCCESS);
}

int main( int argc, char* argv[] ) {

    if ( argc != 3 ) {
        fprintf( stdout, "Usage : %s <nom_serveur> <port>\n", argv[0] );
        exit( EXIT_FAILURE );
    }

    // Envoi ============================    
    const char* server_name = argv[1];
    const char* port = argv[2];

    struct addrinfo* res;
    struct addrinfo hints;  //filtres

    memset( &hints, 0, sizeof(hints) );
    hints.ai_flags = AI_CANONNAME; // pour pouvoir mettre un nom tel que abcd.fr et pas une ip
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_DGRAM; // SOCK_DGRAM pour udp : SOCK_STREAM pour tcp

    getaddrinfo( server_name, port, &hints, &res );
    int s = socket( res->ai_family, res->ai_socktype, res->ai_protocol );

    if( s < 0 ) {
        perror( "socket" );
        exit( EXIT_FAILURE );
    }

    time_t time_now = time(0);
    sendto( s, localtime( &time_now ), 7, 0, res->ai_addr, res->ai_addrlen );
    

    // Réception =======================
    char buffer[1024];
    struct sockaddr from;
    socklen_t length;
    
    struct sigaction new_action;
    new_action.sa_handler = fonc_action;
    sigaction( SIGALRM, &new_action, NULL);

    alarm(5);
    
    recvfrom(s, buffer, 1024, 0, &from, &length);
    printf("Réponse : %s\n", buffer);
}