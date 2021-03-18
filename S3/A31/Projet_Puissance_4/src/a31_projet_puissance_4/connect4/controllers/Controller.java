package a31_projet_puissance_4.connect4.controllers;

import a31_projet_puissance_4.connect4.models.*;
import a31_projet_puissance_4.connect4.views.View;


public abstract class Controller {
	
	protected ConnectFour _strategy;
	
	/**
	 * Constructeur
	 */
	public Controller() {}
	
	/**
	 * Créer une partie
	 * @return
	 */
	protected abstract Game createGame(String[] joueurs);
	
	
	/**
	 * Créer la stratégie du jeu
	 * @return
	 */
	protected abstract ConnectFour createStrategy( Game g );
	
	
	/**
	 * Créer la vue du jeu
	 */
	protected abstract View createView(Controller ctrl );
	
	
	/**
	 * Renvoie la strategie utilisée
	 * @return renvoie la strategie
	 */
	public ConnectFour getStrategy() {
		return this._strategy;
	}

}
