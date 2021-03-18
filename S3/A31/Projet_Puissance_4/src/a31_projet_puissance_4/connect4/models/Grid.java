package a31_projet_puissance_4.connect4.models;

public abstract class Grid {

    // Variables globales contenant :

    // nombre de ligne de la grille / sa hauteur.
    private final int _nbRows;

    // nombre de colonnes de la grille / sa largeur.
    private final int _nbColumns;

    // contenu de la grille / tableau de jetons
    protected Disc[][] _discs;


    /**
     * Constructeur.
     * @param length Longueur de la grille.
     * @param heigh Hauteur de la grille.
     */
    public Grid( int length, int heigh ) {
        this._nbRows = heigh;
        this._nbColumns = length;
        this._discs = new Disc[length][heigh];

        for ( int i = 0; i < length; i++) {
            for ( int ii = 0; ii < heigh; ii++) {
                this._discs[i][ii] = null;
            }
        }

    }

    /**
     * putDisc
     * Place un jeton dans la grille à un emplacement donné.
     * @param disc Jeton à placer.
     * @param posX Emplacement du jeton à placer.
     */
    public abstract boolean putDisc( Disc disc, int posX );

    /**
     * removeDisc
     * Retire un jeton de la grille à un emplacement donné.
     * @param posX Numéro de la colonne.
     * @param posY Numéro de la ligne.
     */
    public void removeDisc( int posX, int posY ) {

        // boucle remplacant le disque courant par le disque du dessus,
        // jusqu'à avoir descendu tous les jetons d'un cran de la colonne.
        for ( int i = posY; (i+1 < this._nbRows) && (this._discs[posX][i+1] != null) ; i++ ) {
            this._discs[posX][i] = this._discs[posX][i+1];
        }
    }

    /**
     * removeLowerDisc
     * Retire le disque le plus bas d'une colonne.
     * @param posX Numéro de la colonne.
     */
    public void removeLowerDisc( int posX ) {
        this.removeDisc( posX, 0);
    }

    /**
     * changeOwner
     * Remplace le propriétaire d'un jeton par un autre.
     * @param posX Numéro de la colonne du jeton.
     * @param posY Numéro de la ligne du jeton.
     * @param owner Nouveau propriétaire du jeton.
     */
    public void changeOwner( int posX, int posY, Player owner ) {
        this._discs[posX][posY].setOwner(owner);
    }

    /**
     * getGrid
     * Envoi la grille complète actuelle.
     * @return Grille des jetons.
     */
    public Disc[][] getGrid() {
        return this._discs;
    }

}
