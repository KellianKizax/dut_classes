#include <stdio.h>
#include <math.h>
#include <time.h>
#include <limits.h>
#include <stdint.h>
#include <stdlib.h>
#include <ctype.h>


int32_t fast_exp(uint32_t a,  uint32_t k, uint32_t n){
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


int main(int argc, char *argv[] ) {

    uint32_t a = 3;
    uint32_t k = 4;
    uint32_t n = 100;


    printf("%d\n", fast_exp(a, k, n) );

    return EXIT_SUCCESS;
}