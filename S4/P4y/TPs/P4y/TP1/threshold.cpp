//
// Created by kgoffic on 25/01/2021.
//

#include <unistd.h>
#include <cstdlib>
#include <iostream>
#include <cstdint>
#include "image.h"
#include "fileio.h"

int main(int argc, const char * argv[]) {

    // threshold

    if(argc !=4) {
        std::cout << "Usage : " << argv[0] << " <input.pgm> <output.pgm> <seuil> \n";
        exit(EXIT_FAILURE);
    }

    if ( atoi(argv[3]) < 0 || atoi(argv[3]) > 255 ) {
        std::cout << "Valeur seuil doit être comprise entre 0 et 255";
        exit(EXIT_FAILURE);
    }

    Image<uint8_t> image = readPGM(argv[1]);

    image.threshold( atoi(argv[3]) );

    writePGM(image, argv[2]);



    return 0;
}
