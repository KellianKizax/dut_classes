package a31_projet_puissance_4.connect4.models;

import java.util.ArrayList;

public class Player {

    // Variables globales contenant :

    private final int _id;

    // Nom du joueur.
    private final String _name;

    // Liste des jetons que possède encore le joueur.
    private ArrayList<Disc> _discs = new ArrayList<Disc>();


    /**
     * Constructeur.
     * @param name Nom du joueur.
     */
    public Player( String name, int id ) {
        this._name = name;
        this._id = id;
    }

    /**
     * initDiscs
     * Ajoute aux jetons du joueur, 'nbDiscs' fois le jeton 'disc'.
     * @param nbDiscs Nombre de jetons à ajouter.
     * @param disc Jeton à ajouter.
     */
    public void initDiscs( int nbDiscs, Disc disc ) {
        for ( int i = 0; i < nbDiscs; i++) {
            this._discs.add(disc);
        }
    }

    /**
     * hasDisc
     * Vérifie si le joueur possède le jeton en paramètre.
     * @param disc Jeton à vérifier.
     * @return 'True' si le joueur possède le même jeton, sinon 'False'.
     */
    public boolean hasDisc( Disc disc ) {
        for ( Disc d : this._discs ) {
            if ( d.equals(disc) )
                return true;
        }
        return false;
    }

    /**
     * getDiscs
     * Envoi la liste des jetons possédés actuelle.
     * @return Liste des jetons possédés.
     */
    public ArrayList<Disc> getDiscs() {
        return this._discs;
    }

    /**
     * getName
     * Envoi le nom du joueur.
     * @return Nom du joueur.
     */
    public String getName() {
        return this._name;
    }

    public int getId() {
        return this._id;
    }
}
