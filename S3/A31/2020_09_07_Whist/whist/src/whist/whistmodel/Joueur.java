package whist.whistmodel;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

/**
 * Modélise un joueur d'une partie de whist.
 */
public class Joueur {
	
	private final String nom;
	private final ArrayList<Carte> cartes = new ArrayList<>(13);
	private final Equipe equipe;
	
	
	/**
	 * Construit un joueur dont le nom et l'équipe sont passés en argument.
	 * 
	 * @param nom nom du joueur
	 * @param equipe équipe à laquelle appartient le joueur
	 */
	public Joueur(String nom, Equipe equipe) {
		this.equipe = equipe;
		this.nom = nom;
	}
	/**
	 * Construit un joueur dont l'équipe est passée en argument.
	 * 
	 * Le joueur reçoit comme nom par défaut la chaîne renvoyée par 
	 * la méthode toString de la classe Object
	 * @param equipe équipe à laquelle appartient le joueur
	 */

	public Joueur(Equipe equipe) {
		this.equipe = equipe;
		this.nom = super.toString();
	}
	
	
	
	
	/**
	 * Ajoute une carte dans la main du joueur.
	 * 
	 * Utilisé lors de la distribution des cartes
	 * @param c la carte à ajouter à la main du joueur
	 */
	public void recevoirCarte( Carte c) {
		cartes.add( c );
	}
	

	/**
	 * Renvoie la main du joueur.
	 * 
	 * @return la main du joueur
	 */
	public ArrayList<Carte> getCartes() {
		return new ArrayList<>( cartes );
	}
	


	/**
	 * Supprime la carte passée en argument de la main du joueur.
	 * 
	 * @param c carte à retirer de la main de this
	 */
	public void jouer( Carte c ) {
		cartes.remove( c );
	}
	
	/**
	 * Renvoie l'équipe à laquelle appartient le joueur.
	 * 
	 * @return l'équipe de this
	 */
	public Equipe getEquipe() {
		return equipe;
	}


	/**
	 * Renvoie le nom du joueur.
	 * 
	 * @return le nom de this
	 */
	public String getNom() {
		return nom;
	}
	
};
