#include <stdio.h>

//gcc -Wall -c nom_fichier.c

int main(){
    // déclaration du plus grand et plus petit entier de la suite
    int plusGrand;
    int plusPetit;

    //déclaration d'un entier saisi
    int saisi;

    //saisie de l'entier saisi
    printf("saisissez un entier : ");
    scanf("%d", &saisi);

    //initialisation de plusgrand et pluspetit avec le premier element
    plusGrand = saisi;
    plusPetit = saisi;

    //tant que l'utilisateur saisi un entier différent de zero
    while(saisi != 0){
        //si plusgrand est plus petit que saisi
        if(plusGrand < saisi){
            //alors plusgrand devient saisi
            plusGrand = saisi;
        }
        //sinon plusgrand est superieur ou égal a saisi
        else{
            //si plus petit est plus grand que saisi
            if(plusPetit > saisi){
                //alors plus petit devient saisi
                plusPetit = saisi;
            }
        }
    
    //nouvelle saisie d'un entier
    printf("saisissez un entier : ");
    scanf("%d", &saisi);
    } //fin du while
    //affichage de pluspetit et plusgrand
    printf("entier le plus grand = %d et entier le plus petit = %d\n", plusGrand, plusPetit);
    return 0;    
}