#include <unistd.h>
#include <cstdlib>
#include <iostream>
#include <cstdint>
#include "image.h"
#include "fileio.h"

int main(int argc, const char * argv[]) {

    /*
    // Prise en main : Partie 1

     if(argc !=2) {
        std::cout << "Usage : " << argv[0] << " <input.pgm> <output.pgm> \n";
        exit(EXIT_FAILURE);
    }

    Image<uint8_t> image=readPGM(argv[1]);

    image.print_info();

    //writePGM(image, argv[2]);
    */


    // =======================================================================
    // Prise en main : Partie 2

     if (argc != 3 || atoi(argv[1]) <= 0 || atoi(argv[2]) <= 0 ) {
        std::cout << "Usage : " << argv[0] << " <largeur> <hauteur> \n";
        exit(EXIT_FAILURE);
    }

    Image<uint8_t> image(atoi(argv[1]), atoi(argv[2]) );

    image.set_pxl_offset();

    image.print();


    return 0;
}
