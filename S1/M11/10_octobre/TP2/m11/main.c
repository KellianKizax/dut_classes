#include <stdio.h>
#include "m11.h"

int main() {
    //unsigned long n = 59;//nombre a convertir
    //unsigned int b = 2;//en base
    //conversion(n, b);
    
    //unsigned int c = 2;//base dans laquelle compter jusqu'a 100
    //comptage(c);
    
    unsigned long u = 252;//entier non signé à coder
    unsigned int nb_octets = 1;//nombre octets
    encodage_non_signe(u, nb_octets);

    long w = -1;//entier signé à coder
    unsigned int wnb_octets = 1;//nombre octets
    encodage_non_signe(w, wnb_octets);
    
    return 0;
}