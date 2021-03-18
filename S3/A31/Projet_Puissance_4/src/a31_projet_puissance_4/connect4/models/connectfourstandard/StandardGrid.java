package a31_projet_puissance_4.connect4.models.connectfourstandard;

import a31_projet_puissance_4.connect4.models.Disc;
import a31_projet_puissance_4.connect4.models.Grid;

public class StandardGrid extends Grid {

    /**
     * Constructeur.
     *
     * @param length Longueur de la grille.
     * @param heigh  Hauteur de la grille.
     */
    public StandardGrid(int length, int heigh) {
        super(length, heigh);
    }

    /**
     * putDisc
     * Place un jeton dans la grille à un emplacement donné.
     *
     * @param disc Jeton à placer.
     * @param posX Emplacement du jeton à placer.
     * @return 'True' si le jeton a pû être placé, sinon 'False'.
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
