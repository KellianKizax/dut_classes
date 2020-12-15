#include <stdio.h>
#include "m11Eval.h"

unsigned long quotient(unsigned long a, unsigned long b) {
    long q;
    q = a / b;
    return q;
}

void afficher_division_euclidienne(unsigned long a, unsigned long b) {
    long q;
    int r;
    q = quotient(a,b);
    r = a - (b*q);
    printf("%lu=%lu*%ld+%d\n", a,b,q,r);
}



void afficher_diviseurs(long nb) {
    printf("Diviseurs de %lu :\n", nb);

    for (int i = nb; i >= 1; i = i - 1)
    {
        long q;
        int r;
        q = quotient(nb,i);
        r = nb - (i*q);
        
        if ( r == 0 )
        {
            printf("-%d\n", i);
        }
    }
    for (int i = 1; i <= nb; i = i + 1)
    {
        long q;
        int r;
        q = quotient(nb,i);
        r = nb - (i*q);
        
        if ( r == 0 )
        {
            printf("%d\n", i);
        }
    }
}

unsigned int nombre_de_diviseurs_positifs(unsigned long nb) {
    int nbr;
    nbr = 0;
    for (int i = 1; i <= nb; i = i + 1)
    {
        long q;
        int r;

        q = quotient(nb,i);
        r = nb - (i*q);
        
        if ( r == 0 )
        {
            nbr = nbr + 1;
        }
    }
    return nbr;
}

char est_premier(unsigned long nb) {
    int nbr;
    char premier;
    nbr = nombre_de_diviseurs_positifs(nb);
    if ( nb == 1 )
    {
        premier = '1';
    }
    else if ( nbr == 2 )
    {
        premier = '1';
    }
    else
    {
        premier = '0';
    }
    return premier;
}

void afficher_decomposition_facteurs_premiers(unsigned long nb) {
    /*for (unsigned long i = 2; i <= nb; i++)
    {
        if ( nombre_de_diviseurs_positifs(i) == 2)
        {
            while ()
        }
    }*/
}