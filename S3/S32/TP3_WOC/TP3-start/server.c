#include "config.h"
#include "network.h"
#include "game.h"

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <pthread.h>
#include <sys/time.h>

int sock = -1;
struct sockaddr_in clients_info[MAX_PLAYERS];
GameData g;

// you should use this mutex somewhere..
// pthread_mutex_t game_data_mutex = PTHREAD_MUTEX_INITIALIZER;



void* server_listen_loop(void* arg)
{
	// wait for client messages
	// messages can be:
	// - [REQUEST_ID]: next_available_id, store client sockaddr_in, init_player, send 2 bytes [REQUEST_ID, id]
	// - [RELEASE_ID, id]: release_player
	// - [PLAYER_MOVE, id, MOVE_TYPE]: update_player_direction

	fprintf(stderr, "serverlisten loop\n");
	while( NULL == NULL ) {

		/* UNIQUEMENT POUR DU TCP

		int l = listen( sock, MAX_PLAYERS );
		if ( l < 0 ) {
			perror("Listen server.c");
			exit(EXIT_FAILURE);
		}

		struct sockaddr saddr_client;
		socklen_t saddr_cl_size = sizeof(saddr_client);

		int new_socket = accept( sock, &saddr_client, &saddr_cl_size );
		if ( new_socket < 0 ) {
			perror("accept creation server.c");
			exit(EXIT_FAILURE);
		}
		*/
	
		fprintf(stderr, "while\n");

		struct sockaddr saddr_in;
		socklen_t saddr_in_size;

		char request[3];

		fprintf(stderr, "before recvfrom\n");
		
		int request_len = recvfrom( sock, request, 3, 0, &saddr_in, &saddr_in_size );
		
		fprintf(stderr, "after recvfrom\n");
		
		if ( request_len < 0 ) {
			perror("recv server.c");
			exit(EXIT_FAILURE);
		}
		
		fprintf(stderr, "Request message : %s\n", request);

	}

	return NULL;
}



void* server_game_loop(void* arg)
{
	// at regular interval:
	// - move_players
	// - send [GAME_DATA, struct GameData g] to all valid players

	// to make regular intervals:
	// - gettimeofday at the beginning of the loop
	// - gettimeofday at the end of the loop
	// - timersub
	// - usleep the number of milliseconds needed to reach FRAME_DURATION

	return NULL;
}



int main(int argc, char** argv)
{
	fprintf(stderr, "main\n");
	if (argc != 2)
	{
		fprintf(stderr, "Usage: %s port\n", argv[0]);
		return EXIT_FAILURE;
	}
	 
	// create socket
	int port = htons( atoi(argv[1]) );

	sock = socket( AF_INET, SOCK_DGRAM, 0 );

	if ( sock < 0 ) {
		perror("Socket creation server.c");
		exit(EXIT_FAILURE);
	}


	// bind socket to given port
	if ( bind_socket( sock, port ) < 0 ) {
		perror("Bind socket server.c");
		exit(EXIT_FAILURE);
	}

	srand(time(NULL));

	init_gamedata(&g);

	fprintf(stderr, "pthread_t\n");
	pthread_t thr_listen, thr_game;
	pthread_mutex_t game_data_mutex = PTHREAD_MUTEX_INITIALIZER;

	fprintf(stderr, "pthred_create\n");
	// launch server_listen_loop thread
	pthread_create( &thr_listen, NULL, server_listen_loop, NULL );
	
	// launch server_game_loop thread
	pthread_create( &thr_game, NULL, server_game_loop, NULL );

	fprintf(stderr, "pthread_join\n");
	// wait for threads end
	pthread_join( thr_listen, NULL );
	pthread_join( thr_game, NULL );

	// close socket
	close(sock);

	return EXIT_SUCCESS;
}
