#include <stdio.h>
#include <math.h>
#include <time.h>
#include <limits.h>
#include <stdint.h>
#include <stdlib.h>
#include <ctype.h>


uint32_t crible(uint32_t N, uint32_t* prime_tab){

    uint64_t k, sqrt_N, i, nb_prime;
    int *not_prime_tab;

    k = 2;
	sqrt_N = sqrt(N);

	if ((not_prime_tab = calloc( N+1, sizeof(int))) == NULL) {
		perror("calloc");
        exit(EXIT_FAILURE);
    }
	
    while (k <= sqrt_N) {
		for (i = 2 * k; i <= N; i += k) {
			not_prime_tab[i] = 2;
        }
		while (not_prime_tab[++k] == 2);
	}

    

	nb_prime = 0;
	for (i = 2; i <= N; i++) {
		if ( not_prime_tab[i] != 2 ) {
			nb_prime++;
		}
    }

    if ((prime_tab = calloc( nb_prime+1, sizeof(uint32_t))) == NULL) {
		perror("calloc");
        exit(EXIT_FAILURE);
    }

    int ind = 0;
    for (i = 2; i <= N; i++) {
        if ( not_prime_tab[i] != 2 ) {
            prime_tab[ind] = i;
            ind++;
        }
    }

    for (int i = 0; i < nb_prime; i++) {
        printf("%d ", prime_tab[i] );
    }

	free(not_prime_tab);

    return nb_prime;
}






int main(int argc, char *argv[] ) {

    uint32_t N = 15;
    uint32_t* prime_tab;

    printf("%d\n", crible(N, prime_tab));

    return EXIT_SUCCESS;
}