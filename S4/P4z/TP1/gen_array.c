// author: Thibault CLAUSS - Kellian GOFFIC       05/02/2021
// file: gen_array.c

#include "gen_array.h"
#include "tris.h"

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <time.h>



/**
 * @brief Remplit le tableau d'entiers aléatoirement.
 * 
 * @param array Pointeur du tableau à remplir.
 * @param size Taille du tableau à obtenir.
 */
void generate_array( long* array, size_t size ) {

    array = calloc( size, sizeof(long) );

    srand( time(NULL) );
    for ( size_t i = 0; i < size; i++ ) {
        array[i] = rand();
    }
}


/**
 * @brief Remplit le tableau d'entiers aléatoires partiellement triés.
 * 
 * @param array Pointeur du tableau à remplir.
 * @param size Taille du tableau à obtenir.
 * @param sorted Pourcentage du tableau trié.
 */
void generate_halfsorted_array( long* array, size_t size, float sorted ) {

    array = calloc( size, sizeof(long) );

    if ( array < 0 ) {
        perror("Erreur : calloc \n");
        return;
    }

    // On calcule le nombre d'element à générer qui seront triés.
    size_t nb_element_sorted = size * sorted;

    srand( time(NULL) );
    for( size_t i = 0; i < size; i++ ) {

        // Si il reste des entiers triés a entrer,
        // On choisit au hasard (1/2) si on entre ceux-ci ou
        // une section aléatoire
        if ( (nb_element_sorted != 0) && ((rand() % 2) == 0) ) {
            // On choisit aléatoirement le nombre d'élément dans cette section
            size_t nb_elt = rand() % nb_element_sorted;

            if ( nb_elt != 0 ) {
                // on soustrait au nombre total d'element restant triés
                // le nombre d'éléments dans cette section
                nb_element_sorted -= nb_elt;

                // On génère et tri ce sous tableau
                long* sub_array = malloc(sizeof(long));
                generate_array( sub_array, nb_elt );
                triRapide( sub_array, nb_elt );

                // on insère ce tableau dans le tableau principal à la position courante
                for ( size_t ii = 0; ii < nb_elt; ii++ ) {
                    array[i+ii] = sub_array[ii];
                }

                // On incrémente le compteur principal
                i += nb_elt;

                // on libère l'espace mémoire
                free(sub_array);

            }
        }
        else {
            // Sinon on génère une section d'entiers aléatoires non-triés.

            // On choisit de manière aléatoire la taille de cette section
            //      On s'assure que cette section ne soit pas trop grande
            //      pour respecter le pourcentage donné.
            size_t nb_elt = rand() % (size - i - nb_element_sorted);

            for ( size_t ii = 0; ii < nb_elt; ii++ ) {
                array[i+ii] = random();
            }

            // On incrémente le compteur principal
            i += nb_elt;
        }

    }
    
}


/**
 * @brief Remplit le tableau d'entiers trié a l'envers.
 * 
 * @param array Pointeur du tableau à remplir.
 * @param size Taille du tableau à obtenir.
 */
void generate_reversed_array( long* array, size_t size ) {

    array = calloc( size, sizeof(long) );

    for (size_t i = 0; i < size; i++)
    {
        array[i] = size - i;
    }
}


/**
 * @brief Affiche sur l'entrée standard le tableau donné.
 * 
 * @param array Type long* ; Le tableau à afficher.
 * @param size Type size_t ; La taille du tableau.
 */
void print_array( long* array, size_t size ) {
    printf("[  ");

    for( size_t i = 0; i < size; i++ ) {
        printf(" %li,   ", array[i] );
    }
    
    printf( "]\n");
}
