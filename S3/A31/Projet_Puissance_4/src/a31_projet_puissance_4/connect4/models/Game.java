package a31_projet_puissance_4.connect4.models;

import a31_projet_puissance_4.connect4.observators.Observable;

import java.util.ArrayList;

public abstract class Game extends Observable {

    // Variables globales :

    // Grille du jeu.
    private Grid _grid;

    // Liste des joueurs.
    private ArrayList<Player> _players = new ArrayList<Player>();


    /**
     * Constructeur
     * Créé une partie à partir du nom des deux joueurs et d'une grille.
     * @param playersName Tableau comportant les deux noms des joueurs.
     * @param grid Grille de jeu.
     * @throws IllegalArgumentException Si le nombre de joueur est différent de 2 ; Si le nom de l'un des joueurs est vide.
     */
    public Game(String[] playersName, Grid grid)
    throws IllegalArgumentException {

        // On vérifie que le nombre de joueurs est égal à 2.
        if ( playersName.length != 2 ) {
            throw new IllegalArgumentException("Le nombre de joueur doit être égal à 2.");
        }

        // On vérifie que le nom des deux joueurs est bien rempli.
        if ( playersName[0].isEmpty() || playersName[1].isEmpty() ) {
            throw new IllegalArgumentException("Le nom des joueurs ne doit pas être vide.");
        }

        this._players.add( new Player(playersName[0], 0) );
        this._players.add( new Player(playersName[1], 1) );

        this._grid = grid;
    }

    /**
     * distributeDiscs
     * Distribue les jetons aux deux joueurs.
     */
    protected abstract void distributeDiscs();

    /**
     * getGrid
     * Envoi la grille actuelle du jeu.
     * @return Grille du jeu.
     */
    public Grid getGrid() {
        return this._grid;
    }

    /**
     * getPlayers
     * Envoi la liste des joueurs.
     * @return Liste des joueurs.
     */
    public ArrayList<Player> getPlayers() {
        return this._players;
    }

}
