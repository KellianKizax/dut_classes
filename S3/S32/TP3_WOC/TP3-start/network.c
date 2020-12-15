#include "network.h"

#include <stdio.h>
#include <string.h>

int bind_socket(int sock, int port)
{
	struct sockaddr_in saddr_in;

	memset( &saddr_in, 0, sizeof(saddr_in) );
	saddr_in.sin_port = port;
	saddr_in.sin_family = AF_INET;

	return bind( sock, (struct sockaddr*) &saddr_in, sizeof(saddr_in) );
}

struct addrinfo* get_host_info(const char* name, const char* service)
{
	return NULL;
}

void print_host_info(const struct addrinfo* host_info)
{

}
