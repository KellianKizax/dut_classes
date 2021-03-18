// normalize.cpp
// Created by kgoffic on 02/02/2021.
//

#include <unistd.h>
#include <cstdlib>
#include <iostream>
#include <cstdint>
#include "image.h"
#include "fileio.h"

int main(int argc, const char * argv[]) {

    if( argc != 5 ) {
        std::cout << "Usage : " << argv[0] << " <input.pgm> <output.pgm> <min> <max>\n";
        exit(EXIT_FAILURE);
    }

    Image<uint8_t> image = readPGM(argv[1]);

    image.normalize( atoi(argv[3]), atoi(argv[4]) );

    writePGM( image, argv[2] );

    return 0;
}
