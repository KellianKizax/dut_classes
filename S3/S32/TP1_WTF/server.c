#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>
#include <string.h>

int main( int argc, char* argv[] ) {

    if ( argc != 2 ) {
        fprintf( stdout, "Usage : %s <port>\n", argv[0] );
        exit( EXIT_FAILURE );
    }

    // Envoi ============================    
    const char* port = argv[1];

    struct addrinfo* res;
    struct addrinfo hints;  //filtres
    

    memset( &hints, 0, sizeof(hints) );
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_flags = AI_PASSIVE;

    getaddrinfo( NULL, port, &hints, &res );
    int s = socket( res->ai_family, res->ai_socktype, res->ai_protocol );

    if( s < 0 ) {
        perror( "socket" );
        exit( EXIT_FAILURE );
    }

    bind( s, res->ai_addr, res->ai_addrlen );
    listen( s, 10 );

    char buffer[1024];
    struct sockaddr from;
    socklen_t length;

    recvfrom(s, buffer, 1024, 0, &from, &length);
    printf("Message recu : %s\n", buffer);

    struct sockaddr their_addr;

    socklen_t addr_size = sizeof(their_addr);
    int new_socket = accept( s, (struct sockaddr *) &their_addr, &addr_size );




    sendto( new_socket, "Message recu !", 7, 0, res->ai_addr, res->ai_addrlen );

}