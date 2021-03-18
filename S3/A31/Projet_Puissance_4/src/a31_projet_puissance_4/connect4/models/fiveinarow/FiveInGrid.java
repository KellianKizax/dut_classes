package a31_projet_puissance_4.connect4.models.fiveinarow;

import a31_projet_puissance_4.connect4.models.Disc;
import a31_projet_puissance_4.connect4.models.Grid;
import a31_projet_puissance_4.connect4.models.Player;
import a31_projet_puissance_4.connect4.models.connectfourstandard.StandardDisc;

public class FiveInGrid extends Grid {

    /**
     * Constructeur.
     *
     * @param length Longueur de la grille.
     * @param heigh  Hauteur de la grille.
     */
    public FiveInGrid(int length, int heigh) {
        super(length, heigh);

        for ( int i = 0; i < heigh; i++) {
            if ( i % 2 == 0 ) {
                super._discs[0][i] = new StandardDisc( new Player("", 1));
                super._discs[length-1][i] = new StandardDisc( new Player("", 0));
            }
            else {
                super._discs[0][i] = new StandardDisc( new Player("", 0));
                super._discs[length-1][i] = new StandardDisc( new Player("", 1));
            }

        }
    }

    /**
     * putDisc
     * Place un jeton dans la grille à un emplacement donné.
     *
     * @param disc Jeton à placer.
     * @param posX Emplacement du jeton à placer.
     * @return 'True' si le jeton à pû être placé, sinon 'False'.
     */
    @Override
    public boolean putDisc(Disc disc, int posX) {

        boolean placed = false; //Confirme si le disque a ete pose ou non
        int i = 0; //Compteur

        //Boucle avec pour condition i > taille d'une colonne et que le disque est encore en main
        while ( i < 6 && !placed ) {
            //On vérifie si il y a une place dans la colonne selectione , si oui on place le disque
            if(super._discs[posX][i] == null) {
                super._discs[posX][i] = disc;
                placed = true;
            }
            i = i+1; //On incrémente le compteur
        }

        return placed;
    }
}
