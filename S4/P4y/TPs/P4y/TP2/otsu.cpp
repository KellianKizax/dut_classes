#include <unistd.h>
#include <cstdlib>
#include <iostream>
#include <cstdint>
#include "image.h"
#include "fileio.h"

// author: Kellian GOFFIC       11/02/2021
// usage: otsu <input.pgm> <output.pgm>
/* ==============================================
Calcule le seuil optimal par l'algorithme
d'Otsu, l'affiche sur la sortie standard et
effectue le seuillage de l'image.
*/

int main(int argc, const char * argv[]) {

     if (argc != 3) {
        std::cout << "Usage : " << argv[0] << " <input.pgm> <output.pgm> \n";
        exit(EXIT_FAILURE);
    }

    Image<uint8_t> image = readPGM(argv[1]);

    image.otsu();

    writePGM(image, argv[2]);

    return 0;
}
