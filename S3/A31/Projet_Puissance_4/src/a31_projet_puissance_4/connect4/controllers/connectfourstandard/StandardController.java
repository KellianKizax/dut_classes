package a31_projet_puissance_4.connect4.controllers.connectfourstandard;

import a31_projet_puissance_4.connect4.controllers.Controller;
import a31_projet_puissance_4.connect4.models.*;
import a31_projet_puissance_4.connect4.models.connectfourstandard.ConnectFourStandard;
import a31_projet_puissance_4.connect4.models.connectfourstandard.StandardGame;
import a31_projet_puissance_4.connect4.models.connectfourstandard.StandardGrid;
import a31_projet_puissance_4.connect4.views.connectfourstandard.StandardView;

public class StandardController extends Controller {

	/**
	 * Constructeur
	 * @param playersNames , nom des joueurs
	 */
	public StandardController(String[] playersNames) {
		StandardGame g = this.createGame(playersNames);
		super._strategy = this.createStrategy(g);
		super._strategy.addObserver( this.createView( this ) );
	}

	/**
	 * Créer une partie de la version standard du jeu
	 * 
	 * @param players ,Nom des joueurs
	 * @return StandardGame
	 */
	@Override
	protected StandardGame createGame(String[] players) {
		StandardGame g;

		 if(players.length==2){
             g = new StandardGame( players, new StandardGrid(7,6) );
         }

         else {
             throw new IllegalArgumentException("2 noms de joueurs requis.");
         }

         return g;
	}

	/**
	 * createView
	 * Créé une vue de la version standard du puissance 4.
	 * @param ctrl Controlleur du puissance 4 standard de type 'StandardController'.
	 * @return Vue créé.
	 */
	@Override
	protected StandardView createView( Controller ctrl ) {
		return new StandardView( (StandardController) ctrl );
	}

	/**
	 * Créer et renvoie une strategie pour la verison standard du jeu
	 * 
	 * @param g , Partie actuelle
	 * @return la strategie de jeu
	 */
	@Override
	protected ConnectFourStandard createStrategy( Game g ) {
		return new ConnectFourStandard( (StandardGame) g);
	}

}
