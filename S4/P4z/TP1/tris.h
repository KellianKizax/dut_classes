// author: Kellian GOFFIC       05/02/2021
// file: tris.h

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

/* Effectue un tri par insertion sur le tableau 'A' de taille 'n'.
 *      Il est naturellement utilisé pour trier des cartes à jouer.
 */
void triInsertion( long* A, size_t n );

// ============================================================================

/* Effectue un tri fusion (merge sort) sur le tableau 'A' de taille 'n'.
 *      Il divise en plusieurs morceaux le tableau en entré,
 *      et effectue un tri par fusion entre chaque sous morceaux.
 */
void fusion(long* A,int p,int q,int r);
void sousTriFusion(long* A,int deb,int fin);
void triFusion( long* A, size_t n );

// ============================================================================

/* Effectue un tri rapide (quick sort) sur le tableau 'A' de taille 'n'.
 *      Le tri rapide chosit un un pivot dans le tableau et réorganise
 *      le tableau en placantà gauche du pivot tous les élements plus petits
 *      et à droite tous les éléments plus grands.
 *      Et on effectue de manière récursive sur le deux sous tableaux obtenus.
 */
void triRapide( long* A, size_t n );

// Trie le tableau A[p,r[ en faisant appel à 'partition()'.
void sousTriRapide( long* A, int p, int r );

// Retourne l'indice du pivot après avoir partitioné le sous-tableau.
int partition( long* A, int p, int r );