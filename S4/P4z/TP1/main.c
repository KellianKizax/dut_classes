// author: Kellian GOFFIC       05/02/2021
// file: main.c

#include "gen_array.h"
#include "tris.h"

#include <string.h>
#include <time.h>


void usage() {
    printf("Usage : ./main <nb elements> <random|partlysorted|reversed> <percent sorted> <insertion|merge|quick>\n");
    exit(EXIT_FAILURE);
}


int main(int argc, char *argv[]){

    if ( argc < 4 )
        usage();

    size_t size = atoi(argv[1]);
    clock_t start, end;
    double cpu_time_used;


    long* tab = calloc( size, sizeof(long) );

    if ( strcmp(argv[2], "random") == 0 ) {

        // generation        
        generate_array(tab, size);

        /*
        // display
        printf(">>> tableau non-trié : \n");
        print_array( tab, size );
        */

        // sorting
        if ( strcmp(argv[3], "insertion") == 0 ) {
            start = clock();
            triInsertion( tab, size );
            end = clock();
        }
        
        else if ( strcmp(argv[3], "merge") == 0 ) {
            start = clock();
            triFusion( tab, size );
            end = clock();
        }
        
        else if ( strcmp(argv[3], "quick") == 0 ) {
            start = clock();
            triRapide( tab, size );
            end = clock();
        }
        
        else
            usage();

    }
    else if ( strcmp(argv[2], "partlysorted") == 0 ) {

        if ( argc == 5 ) {
            
            // generation
            generate_halfsorted_array( tab, size, atoi(argv[3]) );

            /*
            // display
            printf(">>> tableau non-trié : \n");
            print_array( tab, size );
            */

            // sorting
            if ( strcmp(argv[4], "insertion") == 0 ) {
                start = clock();
                triInsertion( tab, size );
                end = clock();
            }
        
            else if ( strcmp(argv[4], "merge") == 0 ) {
                start = clock();
                triFusion( tab, size );
                end = clock();
            }
        
            else if ( strcmp(argv[4], "quick") == 0 ) {
                start = clock();
                triRapide( tab, size );
                end = clock();
            }
            
            else
                usage();
        }
        else
            usage();

    }


    else if ( strcmp(argv[2], "reversed") == 0 ) {
        
        // generation reversed from random array
        generate_reversed_array( tab, size );

        /*
        // display
        printf(">>> tableau non-trié : \n");
        print_array( tab, size );
        */

        // sorting
        if ( strcmp(argv[3], "insertion") == 0 ) {
            start = clock();
            triInsertion( tab, size );
            end = clock();
        }

        else if ( strcmp(argv[3], "merge") == 0 ) {
            start = clock();
            triFusion( tab, size );
            end = clock();
        }

        else if ( strcmp(argv[3], "quick") == 0 ) {
            start = clock();
            triRapide( tab, size );
            end = clock();
        }
        
        else
            usage();
            
    }
    else
        usage();

    /*
    // display
    printf(">>> Tableau trié : \n");
    print_array( tab, size );
    */

    cpu_time_used = ((double) (end - start)) / CLOCKS_PER_SEC;

    printf("%f\t", cpu_time_used);

    free(tab);
    return(EXIT_SUCCESS);
}
