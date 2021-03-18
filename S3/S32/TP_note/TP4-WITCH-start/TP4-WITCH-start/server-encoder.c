#include "server-encoder.h"


// code à découvrir
char code[CODE_LENGTH];


int main (int argc, char *argv[]) {
    // test des paramètres
    if (argc < 4) {
        printf("Usage: %s <port> <code to discover> <number of decoder>\n", argv[0]);
        exit(EXIT_FAILURE);
    }

    if (strlen(argv[2]) < CODE_LENGTH) {
        printf("The given code is too short. Please provide %u digits\n", CODE_LENGTH);
        exit(EXIT_FAILURE);
    }

    if ( argv[3] <= 0 ) {
        printf("The number of decoder must be superior than 0.");
        exit(EXIT_FAILURE);
    }
    memcpy(code, argv[2], CODE_LENGTH);
    int nb_decoder = atoi( argv[3] );

    // création de la structure d'adresse pour la création du socket
    int error;

    struct addrinfo* server_info;
    struct addrinfo hints;
    memset( &hints, 0, sizeof(hints) );
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;

    error = getaddrinfo( NULL, argv[1], &hints, &server_info );
    if ( error != 0 ) {
        perror("getaddrinfo");
        exit( EXIT_FAILURE );
    }

    // création d'un socket pour se mettre en attente de requêtes
    int sock = socket( server_info->ai_family, server_info->ai_socktype, server_info->ai_protocol );
    if ( sock < 0 ) {
        perror("socket");
        exit( EXIT_FAILURE );
    }

    // attachement du socket au port passé en paramètre
    error = bind( sock, server_info->ai_addr, server_info->ai_addrlen );
    if ( error < 0 ) {
        perror("bind");
        exit( EXIT_FAILURE );
    }


    // préparation du socket pour les connexions des clients
    error = listen( sock, 10 );
    if ( error < 0 ) {
        perror("listen");
        exit( EXIT_FAILURE );
    }

    // en attente d'une connexion
    int sockets[nb_decoder];
    int connected = 0;
    while ( connected < nb_decoder ) {
        struct sockaddr client_info;
        socklen_t addr_size = sizeof(client_info);

        sockets[connected] = accept( sock, &client_info, &addr_size );
        connected++;
        fprintf(stderr, "Connection %d received\n", connected);
    }

    // la connexion est établie et on lance la boucle de jeu
    char* msg = "If you strike me down, I shall become more powerful than you can possibly imagine!";

    for( int i = 0; i < nb_decoder; i++ ) {
        sendto( sockets[i], msg, strlen(msg), 0, server_info->ai_addr, server_info->ai_addrlen);
    }

    // Boucle de jeu
    int winner;
    int res = CODE_NOT_FOUND;
    while ( res == CODE_NOT_FOUND ) {
        uint8_t good_place, good_number;
        
        // attente de reception de proposition
        for ( int i = 0; i < nb_decoder; i++ ) {

            struct sockaddr from;
            socklen_t length;
            char buffer[5];
            recvfrom( sockets[i], buffer, 5, 0, &from, &length );

            res = test_code( buffer, &good_place, &good_number );

            char sendbuffer[2];
            sendbuffer[0] = good_place;
            sendbuffer[1] = good_number;
            sendto( sockets[i], sendbuffer, 2, 0, server_info->ai_addr, server_info->ai_addrlen );
            if ( res == CODE_FOUND ) {
                winner = i+1;
            }
        }

    }

    // quelqu'un a trouvé le code
    // envoi du message a tout le monde
    msg = "And the winner is decoder n°"+winner;
    for ( int i = 0; i < nb_decoder; i++ ) {
        sendto( sockets[i], msg, sizeof(msg), 0, server_info->ai_addr, server_info->ai_addrlen );
    }
}


/*
 * Fonction permettant de tester la combinaison proposée par un décodeur
 *  - proposition : la proposition à tester
 *  - good_place  : nombre de chiffres bien placés (paramètre de sortie)
 *  - good_number : nombre de chiffres présents mal placés (paramètre de sortie)
 *
 * Valeurs renvoyées : CODE_FOUND si le code a été trouvé, CODE_NOT_FOUND sinon
 */
uint8_t test_code(const char* proposition, uint8_t* good_place, uint8_t* good_number) {
  char *test = malloc(CODE_LENGTH+1);
  *good_place  = 0;
  *good_number = 0;
  memcpy(test, code, CODE_LENGTH);
  test[CODE_LENGTH] = '\0';

    // test des chiffres bien placés
    for (int i=0 ; i<CODE_LENGTH ; i++) {
        if (proposition[i] == test[i]) {
            (*good_place)++;
            test[i]='x';
        }
    }

    // test des chiffres présents mal placés
    for (int i=0 ; i<CODE_LENGTH ; i++) {
        if (strchr(test, proposition[i]) != NULL) {
            (*good_number)++;
            str_remove(test, proposition[i]);
        }
    }

    if (*good_place == CODE_LENGTH)
        return CODE_FOUND;

    free(test);

    return CODE_NOT_FOUND;
}

/*
 * Fonction remplaçant un caractère dans une chaîne par le caractère 'x'
 * utilisée pour l'évaluation des propositions
 *  - string    : la chaîne à modifier
 *  - to_remove : le caractère à remplacer par 'x'
 */
void str_remove(char * string, const char to_remove) {
    for(int i=0 ; i<strlen(string) ; i++)
        if (string[i]==to_remove) {
            string[i] = 'x';
        }
}
