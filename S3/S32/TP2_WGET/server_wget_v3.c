#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>
#include <string.h>
#include <fcntl.h>
#include <sys/uio.h>
#include <unistd.h>
#include <sys/stat.h>


int main( int argc, char* argv[] ) {

    if ( argc != 2 ) {
        fprintf( stdout, "Usage : %s <port>\n", argv[0] );
        exit(EXIT_FAILURE);
    }


    // Creation du socket ========================
    int port = htons( atoi(argv[1]) );

    int s = socket( AF_INET, SOCK_STREAM, 0 );
    if( s < 0 ) {
        perror("socket");
        exit(EXIT_FAILURE);
    }

    struct sockaddr_in saddr_in;
    memset( &saddr_in, 0, sizeof(saddr_in) );
    saddr_in.sin_port = port;
    saddr_in.sin_family = AF_INET;
    
    if ( bind( s, (struct sockaddr*) &saddr_in, sizeof(saddr_in) ) < 0 ) {
        perror("bind");
        exit(EXIT_FAILURE);
    }


    // Ecoute du socket ==========================
    int l = listen( s, 10 );
    if ( l < 0 ) {
        perror("listen");
        exit(EXIT_FAILURE);
    }


    // Attente de connexion ======================
    struct sockaddr saddr_client;
    socklen_t saddr_csize = sizeof(saddr_client);

    int new_socket = accept( s, &saddr_client, &saddr_csize );
    if ( new_socket < 0 ) {
        perror("accept");
        exit(EXIT_FAILURE);
    }


    // Reception de la requete =====================
    char requete[1024];
    int requete_len = recv( new_socket, requete, 1024, 0 );
    if ( requete_len < 0 ){
        perror("recv");
        exit(EXIT_FAILURE);
    }
    printf( "%s\n", requete );

    char delim[] = " ";
    char *buff_file_req = strtok( requete, delim );
    buff_file_req = strtok( NULL, delim );

    char* path_file_request;
    path_file_request = malloc( strlen(buff_file_req)+2 );
    strcpy( path_file_request, "." );
    strcat( path_file_request, buff_file_req );


    // Envoi du message ==========================
    
    int file_descriptor;
    char c;

    struct stat st;
    int file_size;

    if( stat( path_file_request, &st ) == 0 )
        file_size = st.st_size;
    else
        exit(EXIT_FAILURE);

    if ( ( file_descriptor = open( path_file_request, O_RDONLY ) ) <= 0 )
        exit(EXIT_FAILURE);    

    printf("size : %d\n", file_size);

    int block_size = 1024;
    int already_written = 0;
    int remaining = file_size;
    int to_be_written;

    while( already_written < file_size ) {
        if( remaining < block_size )
            to_be_written = remaining;
        else
            to_be_written = block_size;

        printf("written : %d ; remaining : %d ; to_be %d\n", already_written, remaining, to_be_written );
        
        char buffer[to_be_written];
        printf("\n%ld\n", sizeof(buffer));
        memset( buffer, 0, sizeof(buffer) );    // CORE DUMPED ==> soit buffer[1024] soit memset(..., ..., to_be_written)

        printf("buffer");

        int i = 0;
        while( read( file_descriptor, &c, 1 ) != 0 && i < to_be_written) {
            strcat( buffer, &c );
            i++;
        }

        printf("read");

        write( new_socket, buffer, strlen(buffer) );  

        printf("write"); 

        already_written += to_be_written;
        remaining -= to_be_written;
    }   
    close(file_descriptor);


    return EXIT_SUCCESS;
}
