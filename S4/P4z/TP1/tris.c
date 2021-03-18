// author: Thibault CLAUSS - Kellian GOFFIC       05/02/2021
// file: tris.c

#include "tris.h"



/**
 * @brief Tri par insertion du tableau 'A' de taille 'n'.
 * 
 * @param A type long* ; Tableau à trier.
 * @param n type size_t ; Taille du tableau.
 */
void triInsertion( long* A, size_t n ) {
    
    // Vérification que le tableau à une taille suppérieure à 1
    if ( n <= 1 ) {
        // Sinon pas besoin de trier le tableau
        return;
    }

    long i, j, key;

    for ( i = 1; i < n; i++ ) {
        key = A[i];
        j = i - 1;

        while ( j >= 0 && A[j] > key ) {
            A[j+1] = A[j];
            j--;
        }
        A[j+1] = key;
    }
}

// ==================================================================

/**
 * @brief Trie le tableau A[p,r[ en separant le tableau en 2
 * 
 * @param A Type long* ; Le tableau à trier.
 * @param p Type int ; Indice de départ du tableau à trier.
 * @param q Type int ; Indice du milieu du tableau à trier.
 * @param r Type int : Indice de fin du tableau à trier.
 */
void fusion(long* A,int p,int q,int r){

    int n1 = q-p;
    int n2 = r-q;
    long Ag[n1];
    long Ad[n2];
    int compt = 0;
    int j = 0;

    for (j=p; j<q;j++)
    {
        Ag[compt] = A[j];
        compt++;
    }

    compt = 0;
    for (j=q; j<r;j++)
    {
        Ad[compt] = A[j];
        compt++;
    }

    int indg = 0;
    int indd = 0;
    int i = p;

    while (i < r)
    {
        if (indg == n1) 
        {
            A[i] = Ad[indd];
            indd++;
        }
        else if (indd == n2) 
        {
            A[i] = Ag[indg];
            indg++; 
        }
        else if (Ag[indg] < Ad[indd])
        {
            A[i] = Ag[indg];
            indg++; 
        }
        else
        {
            A[i] =Ad[indd];
            indd++;
        }
        i++;
    }
}

/**
 * @brief Trie le tableau A[p,r[ en faisant appel à 'fusion()'.
 * 
 * @param A Type long* ; Le tableau à trier.
 * @param p Type int ; Indice de départ du tableau à trier.
 * @param r Type int : Indice de fin du tableau à trier.
 */

void sousTriFusion(long* A,int p,int r){
    
    if (p < (r-1))
    {
        int q = (p+r)/2;
        sousTriFusion(A,p,q);
        sousTriFusion(A,q,r);
        fusion(A,p,q,r);
    }
}

/**
 * @brief Tri fusion du tableau 'A' de taille 'n'.
 * 
 * @param A Type long* ; Tableau à trier.
 * @param n Type size_t ; Taille du tableau à trier.
 */

void triFusion(long* A, size_t n ) {
    
    sousTriFusion(A,0,n);
}

// ==================================================================

/**
 * @brief Tri rapide du tableau 'A' de taille 'n'.
 * 
 * @param A Type long* ; Tableau à trier.
 * @param n Type size_t ; Taille du tableau à trier.
 */
void triRapide( long* A, size_t n ){

    // Vérification que le tableau à une taille suppérieure à 1.
    if ( n <= 1 ) {
        // Sinon pas besoin de trier le tableau.
        return;
    }

    sousTriRapide( A, 0, n );
}


/**
 * @brief Trie le tableau A[p,r[ en faisant appel à 'partition()'.
 * 
 * @param A Type long* ; Le tableau à trier.
 * @param p Type int ; Indice de départ de la partition à trier.
 * @param r Type int : Indice de fin de la partition à trier.
 */
void sousTriRapide( long* A, int p, int r ) {

    if ( p < r-1 ) {
        int q = partition( A, p, r );

        sousTriRapide( A, p, q );
        sousTriRapide( A, q+1, r );
    }
}


/**
 * @brief Retourne l'indice du pivot après avoir partitioné le sous-tableau.
 * 
 * @param A Type long* ; Le tableau à trier.
 * @param p Type int ; Indice de départ de la partition.
 * @param r Type int ; Indice de fin de la partition.
 * @return Type int ; Indice du pivot après partition.
 */
int partition( long* A, int p, int r ) {

    long pivot, tmp;
    int i;

    pivot = A[r-1];
    i = p;

    for( int j = p; j < r-1; j++ ) {
        if ( A[j] <= pivot ) {
            tmp = A[i];
            A[i] = A[j];
            A[j] = tmp;

            i++;
        }
    }
    tmp = A[i];
    A[i] = A[r-1];
    A[r-1] = tmp;

    return i;
}
