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

    // compute_histo

    if(argc !=2) {
        std::cout << "Usage : " << argv[0] << " <input.pgm> \n";
        exit(EXIT_FAILURE);
    }

    Image<uint8_t> image = readPGM(argv[1]);

    image.compute_histo();


    return 0;
}
