package Anciens;

import java.util.Arrays;

public class ListeTabD<T> extends ListeTab<T> {

    private static final int INCREMENT_PAR_DEFAUT = 10;

    /**
     * Constructor
     * @param taille Size of the array.
     */
    public ListeTabD(int taille) {
        super(taille);
    }

    /**
     * Insert an element at an index in the array.
     * @param pos   Index of the element.
     * @param val   Element to insert.
     */
    @Override
    public void inserer(int pos, T val) {
        if ( super.nbVal == super.eVal.length ) {
            // Le tableau est rempli, il faut en recréer un plus grand
            int taille = super.eVal.length + INCREMENT_PAR_DEFAUT;
            super.eVal = Arrays.copyOf( super.eVal, taille );
        }
        super.inserer( pos, val );
    }

    /**
     * Convert the list to String
     * @return
     */
    @Override
    public String toString() {
        StringBuilder res = new StringBuilder("[ ");

        if ( nbVal == 0 )
            res.append("]");
        else {
            for ( int i = 0; i < nbVal-1; i++){
                res.append(eVal[i].toString());
                res.append(", ");
            }
            res.append(eVal[nbVal]);
            res.append(" ]");
        }

        return res.toString();
    }
}
