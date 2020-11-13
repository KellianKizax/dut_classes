package whist.whistmodel;

import java.util.ArrayList;
import java.util.Random;

/**
 * 
 */
public class PaquetDeCartes {
	
	private static final Random r = new Random();
	private final ArrayList<Carte> cartes = new ArrayList<>( 4 * 13 );
	
	/**
	 * Construit un paquet de 52 cartes.
	 * 
	 */
	public PaquetDeCartes() {
		for( Couleur c: Couleur.values() )
			for( int i = 0; i < 13; i++)
				cartes.add( new Carte(c, i) );
	}

	/**
	 * Renvoie une carte tirée aléatoirement dans le jeu.
	 * 
	 * @return une carte du jeu
	 */
	public Carte donnerCarte( ) {
		return cartes.remove( r.nextInt( cartes.size() ) );
	}
};
