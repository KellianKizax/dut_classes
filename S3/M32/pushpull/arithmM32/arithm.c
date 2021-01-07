#include "arithm.h"



uint32_t crible(uint32_t N, uint32_t* prime_tab){

    uint64_t k, i, nb_prime;
    char *not_prime_tab;

    k = 2;

	if ((not_prime_tab = calloc( N+1, sizeof(int))) == NULL) {
		perror("calloc");
        exit(EXIT_FAILURE);
    }
	
    while ( k*k <= N) {
		for (i = 2 * k; i <= N; i += k) {
            // boucle marquant tous les multiples de k
			not_prime_tab[i] = 'y';
        }
		while (not_prime_tab[++k] == 'y');
        // on passe tous les multiples déjà marqués
	}

    // on compte le nombre de nombres premiers pour l'allocation
    nb_prime = 0;
    for ( i = 2; i<=N; i++) {
        if (not_prime_tab[i] != 'y' ){
            nb_prime++;
        }
    }

    // on alloue l'espace mémoire nécessaire pour prime_tab
    if ((prime_tab = calloc( nb_prime, sizeof(uint32_t))) == NULL) {
		perror("calloc");
        exit(EXIT_FAILURE);
    }

    // on enregistre dans prime_tab les nombres premiers
    nb_prime = 0;
    for ( i = 2; i<= N; i++) {        
        if ( not_prime_tab[i] != 'y' ){
            prime_tab[nb_prime++] = i;
        }
    }

    /*
    // affichage lors de debuggage
    for (int i = 0; i < nb_prime; i++) {
        printf("%d ", prime_tab[i] );
    }
    */

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
    uint32_t res = a;
    uint32_t puissance = k;
    char paire = 'n';

    if (k%2 == 0) {
        paire = 'y';
    }

    while ( puissance > 0 ) {
        if ( puissance > 1 ) {
            res = ( res * res ) % n;
            puissance = (uint32_t)( puissance / 2 );
        }
        
        else if ( !(puissance > 1) && (paire == 'n') ) {
            res = (res * a) % n;
            puissance -= 1;
        }

        else {
            puissance -= 1;
        }

    }

    return res;
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



