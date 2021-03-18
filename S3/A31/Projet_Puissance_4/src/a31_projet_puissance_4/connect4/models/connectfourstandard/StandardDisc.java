package a31_projet_puissance_4.connect4.models.connectfourstandard;

import a31_projet_puissance_4.connect4.models.Disc;
import a31_projet_puissance_4.connect4.models.Player;

public class StandardDisc extends Disc {

    /**
     * Constructeur
     *
     * @param owner , Joueur qui possede le jeton
     */
    public StandardDisc(Player owner) {
        super(owner, 1);
    }

    @Override
    public boolean equals(Object o) {
        boolean res = false;

        if ( o instanceof StandardDisc ) {

            StandardDisc sd = (StandardDisc) o;

            if ( sd.getOwner().getName().equals( this.getOwner().getName() ) )
                res = true;
        }

        return res;
    }
}
