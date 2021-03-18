package a31_projet_puissance_4.connect4.models.connectfourstandard;

import a31_projet_puissance_4.connect4.models.Game;
import a31_projet_puissance_4.connect4.models.Grid;

public class StandardGame extends Game {

    /**
     * Constructeur
     * Créé une partie à partir du nom des deux joueurs et d'une grille.
     *
     * @param playersName Tableau comportant les deux noms des joueurs.
     * @param grid        Grille de jeu.
     * @throws IllegalArgumentException Si le nombre de joueur est différent de 2 ; Si le nom de l'un des joueurs est vide.
     */
    public StandardGame(String[] playersName, Grid grid) throws IllegalArgumentException {
        super(playersName, grid);
        this.distributeDiscs();
    }

    /**
     * distributeDiscs
     * Distribue les jetons aux deux joueurs.
     */
    @Override
    protected void distributeDiscs() {
        super.getPlayers().get(0).initDiscs(21, new StandardDisc(super.getPlayers().get(0)));
        super.getPlayers().get(1).initDiscs(21, new StandardDisc(super.getPlayers().get(1)));
    }
}
