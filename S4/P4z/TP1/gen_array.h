#include <stddef.h>


/**
 * @brief Remplit le tableau d'entiers aléatoirement.
 * 
 * @param array Pointeur du tableau à remplir.
 * @param size Taille du tableau à obtenir.
 */
void generate_array( long* array, size_t size );

/**
 * @brief Remplit le tableau d'entiers aléatoires partiellement triés.
 * 
 * @param array Pointeur du tableau à remplir.
 * @param size Taille du tableau à obtenir.
 * @param sorted Pourcentage du tableau trié.
 */
void generate_halfsorted_array( long* array, size_t size, float sorted );

/**
 * @brief Remplit le tableau d'entiers trié a l'envers.
 * 
 * @param array Pointeur du tableau à remplir.
 * @param size Taille du tableau à obtenir.
 */
void generate_reversed_array( long* array, size_t size );

/**
 * @brief Tri rapide du tableau 'A' de taille 'n'.
 * 
 * @param A Type long* ; Tableau à trier.
 * @param n Type size_t ; Taille du tableau à trier.
 */
void reversed_quickSort( long* A, size_t n );

/**
 * @brief Trie le tableau A[p,r[ en faisant appel à 'partition()'.
 * 
 * @param A Type long* ; Le tableau à trier.
 * @param p Type int ; Indice de départ de la partition à trier.
 * @param r Type int : Indice de fin de la partition à trier.
 */
void sub_quickSort( long* A, int p, int r );

/**
 * @brief Retourne l'indice du pivot après avoir partitioné le sous-tableau.
 * 
 * @param A Type long* ; Le tableau à trier.
 * @param p Type int ; Indice de départ de la partition.
 * @param r Type int ; Indice de fin de la partition.
 * @return Type int ; Indice du pivot après partition.
 */
int reversed_partition( long* A, int p, int r );

/**
 * @brief Affiche sur l'entrée standard le tableau donné.
 * 
 * @param array Type long* ; Le tableau à afficher.
 * @param size Type size_t ; La taille du tableau.
 */
void print_array( long* array, size_t size );
