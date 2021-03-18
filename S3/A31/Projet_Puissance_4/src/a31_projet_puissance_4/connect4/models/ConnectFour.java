package a31_projet_puissance_4.connect4.models;

import a31_projet_puissance_4.connect4.observators.Observer;

import static java.lang.Math.abs;

public abstract class ConnectFour {

	// Variables globales :

	// Joueur courant.
	protected Player _currentPlayer;

	// Joueur gagnant.
	protected Player _winner = null;

	// Jeton courant.
	protected Disc _currentDisc = null;

	// Position courante du jeton.
	private int _currentPosition = -1;

	// Partie courante.
	protected Game _game;


	/**
	 * Constructeur
	 * @param game Partie du jeu.
	 */
	public ConnectFour(Game game) {
		this._game = game;
		this._currentPlayer = this._game.getPlayers().get(0);
	}

	/**
	 * forward
	 * Effectue un tour de la partie et applique la stratégie du jeu.
	 */
	public void forward() {
		if ( this._winner != null )
			return;

		// On vérifie si le joueur possède encore le jeton.
		if ( !this._currentPlayer.hasDisc( this._currentDisc ) ) {

			// Si il ne le possède plus, on vérifie qu'il lui reste encore un quelconque jeton.
			if ( this._currentPlayer.getDiscs().size() == 0 ) {

				// On recupère l'index du joueur courant dans la liste des joueurs.
				int indexCurrentPlayer = this._game.getPlayers().indexOf( this._currentPlayer );

				// On calcule donc l'index du second joueur dans la liste
				// 		Les deux indexs possibles sont 0 ou 1, donc avec la valeur absolue de l'un des deux indexs -1,
				//		on obtient le second index.
				int indexOtherPlayer = abs(indexCurrentPlayer-1);

				// Si il ne lui reste plus aucun jeton, on vérifie que l'autre joueur lui reste encore des jetons.
				if ( this._game.getPlayers().get(indexOtherPlayer).getDiscs().size() != 0 ) {

					// Si il reste encore des jetons au second joueur, on lui donne la main.
					this._currentPlayer = this._game.getPlayers().get(indexOtherPlayer);
				}
				else {

					// Si il ne reste pas non plus de jetons au second joueur, la partie est finie, les deux joueurs sont ex aequo.
					this._winner = new Player("Ex aequo", -1 );
				}
			}
			// Sinon il reste encore d'autres jetons au joueur courant, on lui laisse la main jusqu'à ce qu'il joue un jeton possédé.
		}
		else {

			// Le joueur courant possède le jeton selectionné

			// On essaye alors de placer le jeton à la position selectionnée
			if ( this.playDisc( this._currentPosition, this._currentDisc) ) {

				// Si le jeton à pû être placé, alors on vérifie si il y a un gagnant.

				Player temp = this.checkWin();
				if ( temp != null ) {
					// On a alors un gagnant
					this._winner = temp;
				}
				else {
					// Si il n'y a pas de gagnant, on donne la main au second joueur.
					// et on reinitialise les variables globales
					this._currentPosition = -1;
					this._currentDisc = null;

					// On recupère l'index du joueur courant dans la liste des joueurs.
					int indexCurrentPlayer = this._game.getPlayers().indexOf( this._currentPlayer );

					// On calcule donc l'index du second joueur dans la liste
					// 		Les deux indexs possibles sont 0 ou 1, donc avec la valeur absolue de l'un des deux indexs -1,
					//		on obtient le second index.
					int indexOtherPlayer = abs(indexCurrentPlayer-1);

					this._currentPlayer = this._game.getPlayers().get(indexOtherPlayer);
				}
			}
			// Si le jeton ne peut être placé, on laisse la main au joueur courant (la colonne est certainement pleine).

			// On notifie toutes les vues
			this._game.notifyObservers();
		}
	}

	/**
	 * playDisc
	 * Applique la stratégie de jeu lorsqu'on pose un jeton à un emplacement.
	 *
	 * @param posX Emplacement du jeton.
	 * @param disc Jeton à placer.
	 * @return 'True' si le jeton a pû être placé, 'False' sinon.
	 */
	public abstract boolean playDisc( int posX, Disc disc );

	/**
	 * checkWin
	 * vérifie si quelqu'un a gagné.
	 * @return Joueur qui a gagné, sinon 'null'.
	 */
	public abstract Player checkWin();

	/**
	 * setCurrentDisc
	 * Enregistre le jeton selectionné par le joueur.
	 * Appelé par la vue.
	 * @param discName Nom du jeton selectionné par le joueur.
	 */
	public abstract void setCurrentDisc( String discName );

	/**
	 * setCurrentPosition
	 * Enregistre la position selectionné par le joueur.
	 * Appelé par la vue.
	 * @param posX Position selectionné par le joueur.
	 */
	public void setCurrentPosition( int posX ) {
		this._currentPosition = posX;
	}

	/**
	 * getWinner
	 * Envoi le gagnant de la partie si il en a un, sinon null.
	 * @return Gagnant de la partie.
	 */
	public Player getWinner() {
		return this._winner;
	}

	/**
	 * addObserver
	 * Ajoute une vue parmi la liste des 'Observer'
	 * @param obs Une vue.
	 */
	public void addObserver( Observer obs ) {
		this._game.addObserver(obs);
	}

	public Disc[][] getDiscsGrid() {
		return this._game.getGrid().getGrid();
	}
	
	
}
