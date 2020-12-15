#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>
#include <string.h>

int main( int argc, char* argv[] ) {
    
    if ( argc != 3 ) {
        fprintf(stdout, "Usage : %s <nom_serveur> <port>\n", argv[0] );
    }


    const char* servername = argv[1];
    const char* port = argv[2];

    struct addrinfo *res;
    struct addrinfo hints;          // filtres


    memset(&hints, 0, sizeof(hints) );
    hints.ai_family=AF_INET;        // ipv4
    hints.ai_socktype=SOCK_DGRAM;   // udp mode non connecté


    getaddrinfo(servername, port, &hints, &res);
    int s = socket(PF_INET, SOCK_DGRAM, 0);

    if(s<0) {
        perror("socket");
        exit(EXIT_FAILURE);
    }


    sendto(s, "Coucou !!", 10, 0, res->ai_addr, res->ai_addrlen);

    char buffer[1024];
    struct sockaddr from;
    socklen_t length;

    recvfrom(s, buffer, 1024, 0, &from, &length);
    printf("Réponse : %s\n", buffer);


    if(res!=NULL)
    {

    struct addrinfo *tmp;

    int i = 1;
    for ( tmp=res; tmp != NULL; tmp=tmp->ai_next ) {
        printf("%d\n",i);

        printf("family : ");
        switch(tmp->ai_family) {
            case PF_INET : printf("PF_INET\n"); break;
            case PF_INET6 : printf("PF_INET6\n"); break;
            case PF_LOCAL : printf("PF_LOCAL\n"); break;
            default : printf("unknown\n");
        }

        printf("socktype :\n");
        /*switch(tmp->ai_socktype) {
            case 
        }*/




        printf("protocol : ");
        switch(tmp->ai_protocol) {
            case IPPROTO_UDP : printf("IPPROTO_UDP\n"); break;
            case IPPROTO_TCP : printf("IPPROTO_TCP\n"); break;
            default : printf("unknown\n");
        }

        printf("adress : \n");

        switch(tmp->ai_addr->sa_family) {
            case AF_INET:{
                struct sockaddr_in *sa_in=(struct sockaddr_in *)tmp->ai_addr;
                char* ip = inet_ntoa(sa_in->sin_addr);
                printf("%s\n", ip);
                break;
            }
            case AF_INET6:{
                struct sockaddr_in6 *sa_in6=(struct sockaddr_in6 *)tmp->ai_addr;
                char dst[tmp->ai_addrlen];
                const char *ip=inet_ntop(AF_INET6, &(sa_in6->sin6_addr), dst, tmp->ai_addrlen);
                printf("%s\n", ip);
                break;
            }
            case PF_LOCAL : printf("PF_LOCAL\n"); break;
            default : printf("unknown\n");
        }



    }

    }


}