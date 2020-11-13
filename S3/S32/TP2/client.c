#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>
#include <string.h>

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
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_DGRAM;

    getaddrinfo( server_name, port, &hints, &res );
    int s = socket( PF_INET, SOCK_DGRAM, 0 );

    if( s < 0 ) {
        perror( "socket" );
        exit( EXIT_FAILURE );
    }

    sendto( s, "Goffic", 7, 0, res->ai_addr, res->ai_addrlen );
    

    // Réception =======================
    char buffer[1024];
    struct sockaddr from;
    socklen_t length;

    recvfrom(s, buffer, 1024, 0, &from, &length);
    printf("Réponse : %s\n", buffer);

}