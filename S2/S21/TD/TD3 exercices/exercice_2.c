#include <stdio.h>

int main(){
    printf("Calcul factorielle\n");
    // Déclaration des variables
    int saisi;
    int resultat = 1;

    // Saisie par l'utilisateur de l'entier saisi;
    printf("Saisissez un entier : ");
    scanf("%d", &saisi);

    if( saisi > 9 || saisi < 0){
        return (-1);
    }

    for(int i = 2; i <= saisi; i++){
        resultat = resultat * i;
    }

    printf("%d! = %d\n", saisi, resultat);
    return 0;
}