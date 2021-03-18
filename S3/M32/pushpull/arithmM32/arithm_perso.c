#include "arithm.h"



uint32_t crible(uint32_t N, uint32_t* prime_tab){

    uint64_t k, i;
    uint32_t nb_prime;
    char *not_prime_tab;

    k = 2;

	if ((not_prime_tab = calloc( N+1, sizeof(char))) == NULL) {
		perror("calloc");
        exit(EXIT_FAILURE);
    }
	
    while ( k*k <= N) {

		for (i = k; k*i <= N; i++) {
            // boucle marquant tous les multiples de k
			not_prime_tab[k*i] = 1;
        }
        k++;
		while (not_prime_tab[k]) k++;
        // on passe tous les multiples déjà marqués
	}

    // on alloue l'espace mémoire nécessaire pour prime_tab
    if ((prime_tab = calloc( nb_prime, sizeof(uint32_t))) == NULL) {
		perror("calloc");
        exit(EXIT_FAILURE);
    }

    // on enregistre dans prime_tab les nombres premiers
    nb_prime = 0;
    for ( i = 2; i <= N; i++) {

        if ( !not_prime_tab[i] ){
            prime_tab[nb_prime] = i;
            nb_prime++;
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
    uint32_t reste_b, reste_a, quotient, reste_c;
    reste_a = a;
    reste_b = b;

    uint32_t u_a = 1, u_b = 0, v_a = 0, v_b = 1, tmp;

    while ( reste_b > 0 ) {
        quotient = reste_a / reste_b;
        reste_c = reste_a % reste_b;

        reste_a = reste_b;
        reste_b = reste_c;

        tmp = u_a;
        u_a = u_b;
        u_b = tmp - quotient*u_b;

        tmp = v_a;
        v_a = v_b;
        v_b = tmp - quotient*v_b;
    }

    EB coeff_bezout = {a, b, u_a, v_a, reste_a};
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



