package whist.whistmodel;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Random;

/**
 * Modélise une partie de Whist.
 */
public class Partie {
	
	private Couleur atout;
	private Joueur[] joueur = new Joueur[4];

	
	/**
	 * Constructeur d'une partie de Whist avec les joueurs dont 
	 * les noms sont donnés en argument.
	 * 
	 * L'ordre des joueurs détermine leur placement : le premier
	 *  de la liste est le joueur à gauche du donneur et le dernier est le donneur
	 * @param nomJoueurs nom des joueurs (optionnel)
	 */
	public Partie(String ... nomJoueurs) {
		Equipe[]  eq =  {new Equipe(), new Equipe()} ;
		int position = 0;
		for (; position < nomJoueurs.length; position++ ) 
			joueur[position] = new Joueur(nomJoueurs[position], eq[position%2] );
		for (; position < 4; position++ )
			joueur[position] = new Joueur( eq[position%2] );
	}

	/**
	 * Distribue les cartes aux joueurs.
	 * 
	 * Un paquet de carte est instancié et ses cartes 
	 * sont affectées aléatoirement aux joueurs.
	 * @return la couleur d'atout
	 */
	public Couleur distribuerCartes() {
		PaquetDeCartes paquetdecartes = new PaquetDeCartes();
		Carte c = null ;
		
		for( int i = 0; i < 13; i++) {
			for( int j = 0; j < 4; j++ ) {
				c = paquetdecartes.donnerCarte( );
				joueur[ j ].recevoirCarte( c );
			}
		}
		atout = c.getCouleur();
		return atout;	
	}

	/**
	 * Renvoie l'équipe gagnante.
	 * 
	 * @return Le numéro de l'équipe gagnante et son score
	 */
	public Equipe resultat() {
		int indexVainqueur = joueur[0].getEquipe().getPoints() > 0 ? 0 : 1;
		return joueur[indexVainqueur].getEquipe();
	}


	
	/**
	 * Renvoie la liste ordonnée des joueurs (donneur en dernière position)
	 * @return la liste des joueurs
	 */
	public List<Joueur> getJoueurs() {
		return Arrays.asList( joueur );
	}

	/**
	 * Renvoie l'atout.
	 * @return la couleur d'atout
	 */
	public Couleur getAtout() {
		return atout;
	}

	
};
