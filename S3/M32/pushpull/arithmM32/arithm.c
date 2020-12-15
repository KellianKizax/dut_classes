#include "arithm.h"



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

    /*for (int i = 0; i < nb_prime; i++) {
        printf("%d ", prime_tab[i] );
    }*/

	free(not_prime_tab);

    return nb_prime;
}

EB bezout(uint32_t a, uint32_t b){
    
    EB coeff_bezout;
    return coeff_bezout;
}

uint32_t modular_inv(uint32_t a, uint32_t n){

    return 0;
}


uint32_t fast_exp(uint32_t a,  uint32_t k, uint32_t n){
    
    return 0;
}

int64_t chinese_remainder(uint32_t s, uint32_t t, uint32_t a, uint32_t b ){

    return 0;   
}



char MR_witness(uint32_t n, uint32_t m, int s, uint32_t a){
  
    return 0;
}

uint32_t MR_prime(int k, float epsilon){

    return 0;
} 

uint32_t primitive_root(uint32_t p){

  
    return 0;
}


uint32_t discrete_log(uint32_t a, uint32_t g,uint32_t p){

    return 0;
}



