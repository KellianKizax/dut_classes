package a31_projet_puissance_4.connect4.models.connectfourstandard;

import a31_projet_puissance_4.connect4.models.ConnectFour;
import a31_projet_puissance_4.connect4.models.Disc;
import a31_projet_puissance_4.connect4.models.Player;

public class ConnectFourStandard extends ConnectFour {

    /**
     * Constructeur
     *
     * @param game Partie du jeu.
     */
    public ConnectFourStandard(StandardGame game) {
        super(game);
    }

    /**
     * playDisc
     * Applique la stratégie de jeu lorsqu'on pose un jeton à un emplacement.
     *
     * @param posX Emplacement du jeton.
     * @return 'True' si le jeton a pû être placé, 'False' sinon.
     */
    @Override
    public boolean playDisc(int posX, Disc disc ) {
        // Dans la version standard du jeu, quand on pose un jeton rien d'autre ne se passe.
        return super._game.getGrid().putDisc( disc, posX );
    }

    /**
     * checkWin
     * vérifie si quelqu'un a gagné.
     *
     * @return Joueur qui a gagné, sinon 'null'.
     */
    @Override
    public Player checkWin() {
        Disc[][] discs = super._game.getGrid().getGrid();

        // variables temporaires pour verifier la suite de 4 jetons identiques
        Player currentOwner;
        int currentLineLength = 0;

        // vérification lignes verticales / bas -> haut
        for (Disc[] disc : discs) {
            for (int row = 0; row < 3; row++) {

                // si il n'y a pas de jeton à l'emplacement actuel, il n'y en aura pas plus haut
                if (disc[row] == null)
                    break;

                currentOwner = disc[row].getOwner();
                currentLineLength = 1;

                // on vérifie si les 3 autres jetons suivants, si ils ne sont pas nuls, ont le même propriétaire
                for (int i = 1; i < 4; i++) {

                    if (disc[row + i] != null) {
                        if (disc[row + i].getOwner() == currentOwner)
                            currentLineLength++;
                    }

                }

                // si on a atteint 4 jetons identiques de suite, alors on a un gagnant
                if (currentLineLength == 4)
                    return currentOwner;
            }

        }



        // vérification lignes horizontales / gauche -> droite
        for( int row = 0; row < discs[0].length; row++ ) {
            for ( int col = 0; col < 4; col++ ) {

                // on vérifie que l'emplacement actuel n'est pas vide
                if ( discs[col][row] != null ) {

                    currentOwner = discs[col][row].getOwner();
                    currentLineLength = 1;

                    // on vérifie que les 3 jetons suivants dans la même ligne ont le même propriétaire
                    // que le précédent
                    for ( int i = 1; i < 4; i++) {

                        if ( discs[col+i][row] != null ) {
                            if ( discs[col+i][row].getOwner() == currentOwner )
                                currentLineLength++;
                        }

                    }

                    // si on a 4 jetons identiques de suite, on a un gagnant
                    if (currentLineLength == 4)
                        return currentOwner;
                }

            }
        }


        // vérification lignes diagonales / bas gauche -> haut droite
        for ( int col = 0; col < 4/*discs[0].length*/; col++ ) {
            for ( int row = 0; row < 3; row++ ) {

                // on vérifie que l'emplacement actuel n'est pas vide
                if (discs[col][row] != null) {

                    currentOwner = discs[col][row].getOwner();
                    currentLineLength = 1;

                    // on vérifie que les 3 jetons suivants dans la diagonale ont le même propriétaire
                    for (int i = 1; i < 4; i++) {

                        if (discs[col+i][row+i] != null) {
                            if (discs[col+i][row+i].getOwner() == currentOwner)
                                currentLineLength++;
                        }

                    }

                    // si on a une suite de 4 jetons identiques, alors on a un gagnant
                    if (currentLineLength == 4)
                        return currentOwner;
                }
            }
        }

        return null;
    }

    /**
     * setCurrentDisc
     * Enregistre le jeton selectionné par le joueur.
     * Appelé par la vue.
     *
     * @param discName Nom du type de jeton à enregister.
     */
    @Override
    public void setCurrentDisc( String discName )
    throws IllegalArgumentException {
        if ( discName.equals("StandardDisc") )
            super._currentDisc = new StandardDisc( super._currentPlayer );
        else
            throw new IllegalArgumentException("Mauvais nom de jeton");
    }
}
