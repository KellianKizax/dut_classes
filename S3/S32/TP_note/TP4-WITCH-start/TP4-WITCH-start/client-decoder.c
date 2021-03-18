#include "client-decoder.h"

int main (int argc, char *argv[]) {
    // test des paramètres
    if (argc < 3) {
        printf("Usage: %s <encoder host> <port>\n", argv[0]);
        exit(EXIT_FAILURE);
    }


    // création de la structure d'adresse pour la création du socket
    char* server_name = argv[1];
    char* port = argv[2];

    struct addrinfo* server_info;
    struct addrinfo hints;

    memset( &hints, 0, sizeof(hints) );
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;


    // création d'un socket pour communiquer avec l'encoder (serveur)
    int error;
    error = getaddrinfo( server_name, port, &hints, &server_info );
    if ( error != 0 ) {
        perror("getaddrinfo");
        exit(EXIT_FAILURE);
    }

    int sock = socket( server_info->ai_family, server_info->ai_socktype, server_info->ai_protocol );
    if ( sock < 0 ) {
        perror("socket");
        exit( EXIT_FAILURE );
    }
    

    // connexion au serveur
    sendto( sock, "c", 1, 0, server_info->ai_addr, server_info->ai_addrlen );
    
    // boucle d'envoi des propositions
    uint8_t good_place;
    int nb_rounds;
    while ( good_place < 5 ) {

        fprintf(stderr, "What is the code ? ");

        char* proposition;
        memset( &proposition, 0, CODE_LENGTH);
        if ( get_proposition( proposition ) == EXIT_FAILURE ) {
            perror("get_proposition");
            exit(EXIT_FAILURE);
        }

        sendto( sock, proposition, 5, 0, server_info->ai_addr, server_info->ai_addrlen );

        struct sockaddr from;
        socklen_t length;
        
        char buffer[2];
        recvfrom( sock, buffer, 2, 0, &from, &length );

        good_place = buffer[0];
        uint8_t good_number = buffer[1];

        print_result( good_place, good_number );


        nb_rounds++;
    }

    fprintf(stderr, "You found the right code in %d rounds! Congrulations !", nb_rounds);


}

/*
 * Fonction d'affichage du résultat de l'analyse de la combinaison proposée.
 * Chaque * correspond à un chiffre bien placé dans la proposition
 * Chaque - correspond à un chiffre présent mais mal placé
 */
void print_result(uint8_t good_place, uint8_t good_number) {
    for (int i=0 ; i < good_place ; i++)
        printf("* ");
    for (int i=0 ; i < good_number ; i++)
        printf("- ");
    printf("\n");
}

/*
 * Fonction demandant la saisie au clavier d'une proposition de combinaison
 *  - proposition : la suite de CODE_LENGTH caractères saisie au clavier
 *
 * Attention ! proposition se composera de CODE_LENGTH caractères et doit avoir été allouée avant l'appel
 *
 * Valeurs renvoyées : EXIT_FAILURE en cas d'erreur de lecture de l'entrée standard, EXIT_SUCCESS sinon
 */
 int get_proposition(char* proposition) {
     char input[CODE_LENGTH+1];
     if (fgets(input, CODE_LENGTH+1, stdin) == NULL) {
         perror("fgets stdin");
         return(EXIT_FAILURE);
     }
     memcpy(proposition, input, CODE_LENGTH);
     fflush(stdin);

     return EXIT_SUCCESS;
 }

 /*
  * Fonction d'affichage d'une proposition
  */
 void print_proposition(char* proposition) {
   for (int i = 0 ; i < CODE_LENGTH ; i++)
     printf("%c", proposition[i]);
   printf("\n");
 }
