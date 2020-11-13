#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <time.h>


// Fonctions utiles à la simulation
// --------------------------------------------------------------------------------

// genererVAExpo(double _lambda) -> float va_expo
//      Tire un U_n aléatoire compris dans [0,1],
//      A partir de celui ci, créé la valeur d'une variable aléatoire exponentielle de paramètre 'lambda'
// PARAMETRE :
//      _lambda :   double :    paramètre lambda de la loi Exponentielle de la variable aléatoire retournée
// RETOUR :
//      va_expo :    float :     valeur d'une variable aléatoire suivant une loi exponentielle de paramètre 'lambda'
float genererVAExpo( double _lambda ) {
        double U_n;
        float va_expo;

        if( _lambda < 0.0 ) {
            printf( "ERREUR : lambda ne peut pas être inférieur à 0 ! \n(lambda = %f)\n", _lambda );
            exit(EXIT_FAILURE);
        }

        // 0 <= U_n <= 1
        U_n = (float)rand() / (float)RAND_MAX; 
        va_expo = -( 1 / _lambda ) * log( U_n );

        return va_expo;
}

// ecrireCSV(int _nbr_simulations, [...])
//      Ecrit dans un fichier csv toutes les données générées lors de la simulation stockées dans les tableaux _tab_val_sim 1 à 4.
void ecrireCSV(int _nbr_simulations, float *_tab_val_sim1, float *_tab_val_sim2, float *_tab_val_sim3, float *_tab_val_sim4) 
{ 
    printf( "Enregistrement des données dans 'data.csv'.\n" );

    FILE *f = fopen("data.csv", "w");

    if (f == NULL)
        exit(EXIT_FAILURE);

    for ( int i = 0; i <= _nbr_simulations; i++ ) {
        fprintf(f, "%d;%f\n", i, _tab_val_sim1[i]); 
    }
    fclose(f); 

    printf( "Enregistrement terminé.\n" );
}


// Programme de simulation
// ---------------------------------------------------------------------------------

// PARAMETRES :
//      argv[1] :   valeur de lambda pour la loi exponentielle
//      argv[2] (optionnel) :   nombre de simulations par série
//          SI pas renseigné = 1 000 000
int main( int argc, char* argv[] ) {

    // Initialisation et vérification des paramètres
    double lambda;
    int nbr_simulations = 1000000;

    
    if ( argc == 2 )
        lambda = atof( argv[1] );
    else if ( argc == 3 ) {
        lambda = atof( argv[1] );
        nbr_simulations = atoi( argv[2] );
    }
    else {
        printf( "SYNTAXE : %s <lambda> {<nombre de simulations par série>} ; avec lambda > 0.\n", argv[0] );
        exit( EXIT_FAILURE );
    }


    // Initialisation des variables
    long double tab_esperance[4];

    float *tab_val_sim1 = (float*) malloc( (nbr_simulations+1) * sizeof(float) );
    float *tab_val_sim2 = (float*) malloc( (nbr_simulations+1) * sizeof(float) );
    float *tab_val_sim3 = (float*) malloc( (nbr_simulations+1) * sizeof(float) );
    float *tab_val_sim4 = (float*) malloc( (nbr_simulations+1) * sizeof(float) );

    long double if_min;
    long double if_max;
    

    printf( "===================================================================================\n" );
    printf( "Lambda : %f\n", lambda );
    printf( "Nombre de simulation par série : %i\n", nbr_simulations );
    printf( "===================================================================================\n" );


    srand( time(NULL) );


    // Génération par série du nombre de v.a. souhaité
    for ( int x = 0; x < 4; x++ ) {
        printf( "Génération de la série %i.\n", (x+1) );
        long double moy_empirique = 0;
        
        for ( int y = 0; y <= nbr_simulations; y++ ) {
            
            // Génération de la valeur
            float valeur = genererVAExpo( lambda );

            // Stockage de la valeur
            switch( x ) {
                case 0 : tab_val_sim1[y] = valeur; break;
                case 1 : tab_val_sim2[y] = valeur; break;
                case 2 : tab_val_sim3[y] = valeur; break;
                case 3 : tab_val_sim4[y] = valeur; break;
            }
            // Calcul dynamique de la moyenne empirique
            moy_empirique += valeur;

        }
        // Calcul et stockage de la valeur empirique
        tab_esperance[x] = moy_empirique / nbr_simulations;
    }


    printf( "===================================================================================\n" );
    printf( "Résultats :\n\n\n" );

    printf( "Espérance théorique (1/lambda) : %f\n\n", (1/lambda) );

    printf( "Espérance par série :\n" );
    printf( "(moyenne empirique de l'échantillon)\n\n" );

    printf( "N° série || Espérance \n" );
    printf( "======================\n" );
    
    for (int x  = 0; x < 4; x++) {
        long double esperance = tab_esperance[x];
        printf( "%i        || %Lf \n", (x+1), esperance );
    }

    printf( "\n\n" );
    printf( "Intervalles de fluctuation :\n" );


    for ( int x = 0; x < 4; x++ ) {
        long double esperance = tab_esperance[x];
        long double somme_diff = 0;
        long double ecart_type;

        for ( int y = 0; y <= nbr_simulations; y++ ) {

            float valeur;
            
            switch( x ) {
                case 0 : valeur = tab_val_sim1[y]; break;
                case 1 : valeur = tab_val_sim2[y]; break;
                case 2 : valeur = tab_val_sim3[y]; break;
                case 3 : valeur = tab_val_sim4[y]; break;
            }

            somme_diff += ( valeur - esperance ) * ( valeur - esperance );
        }


        ecart_type = sqrt( (somme_diff / nbr_simulations) );
        if_min = esperance - 1.96 * ( ecart_type / sqrt(nbr_simulations) );
        if_max = esperance + 1.96 * ( ecart_type / sqrt(nbr_simulations) );
        
        printf("Série %d : [ %Lf < %Lf < %Lf ],\n\tTaille de l'intervalle : %Lf,\n\n", x, if_min, esperance, if_max, (if_max-if_min) );
        
    }
    printf("\n\n");


    ecrireCSV( nbr_simulations, tab_val_sim1, tab_val_sim2, tab_val_sim3, tab_val_sim4 );
}