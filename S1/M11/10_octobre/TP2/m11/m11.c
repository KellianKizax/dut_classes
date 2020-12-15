#include <stdio.h>
#include "m11.h"


void conversion(unsigned long n, unsigned int b)
{
    if ( n == 0 )
    {
        printf("0\n");
    }
    else 
    {
        unsigned long p;
        unsigned long e;
        p = 1;
        
        while (b * p <= n && b * p / b == p)
        {
            p = p * b;
        }
        
        
        while (p!=0)
        {
            e = n / p;
            if (e < 10)
            {
               printf("%lu", e);
            }
            
            //on utilise la table ascii pour les grandes bases
            else
            {
               printf("%c", e + 55);
            }
            
            n = n % p;
            p = p / b;
    }
        printf("\n");
    } 
}

void comptage(unsigned int b) 
{
    unsigned int i;

    i = 0;

    printf("Comptage de 0 a (100)_%u en base %u :\n", b, b);

    while (i <= b*b)
    {
        printf("%u:\t", i);
        conversion(i,b);
        i = i + 1;
    }
}

void encodage_non_signe(unsigned long n, unsigned int nb_octets)
{
    double puissance = 1;
    unsigned int bits;
    unsigned int zeros;
    double i = 1;
    bits = 8 * nb_octets;
    

    while (i <= n)
    {
       puissance = puissance + 1;
       i = i*2;
    }

    zeros = bits - puissance + 1;

    for (int i = 0; i < zeros; i++)
    {
       printf("0");
    }
    conversion(n,2);
}
void encodage_signe(long n, unsigned int nb_octets)
{
    printf("%lu %lu", n, 256-n);
    long unsigned u;
    
    /*if (n >= 0)
    {
      printf("0");
      encodage_non_signe(n, nb_octets);
    }
    else
    {
        u = 256 + n;
        encodage_non_signe(u, nb_octets);
    }*/
    
}