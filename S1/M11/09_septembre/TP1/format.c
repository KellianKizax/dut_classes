#include <stdio.h>

int main()
{
    int aint;
    aint = -15;
    // entier : ok
    // entier non signé : 2puiss32-15
    // float : sort 0.00000
    printf("entier %d entier non signé %u flottant %f \n", aint, aint, aint);

    float bint;
    bint = 15.1;
    // entier : completement aleatoire
    // entier non signé : completement aleatoire
    // float : ok
    printf("entier %d entier non signé %u flottant %f \n", bint, bint, bint);

    return 0;
}