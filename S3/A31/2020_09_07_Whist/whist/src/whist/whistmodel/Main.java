/*package whist.whistmodel;

public class Main {

	public static void main(String[] args) {

		Partie w = new Partie( "A", "B", "C", "D" );
		
		w.distribuerCartes();
		
		// Affichage des cartes des joueurs
		for( int i = 0; i < 4; i++ ){
			System.out.println( w.getJoueurs().get(i).getCartes() );
		}
		
		// Affichage de l'atout
		System.out.println( w.getAtout() );
		
		// Premier tour de table ( sans faire attention à la règle du jeu ! )
		Pli p = new Pli();
		Carte c ;
		for( Joueur j: w.getJoueurs() ) {
			c = j.getCartes().get(0);
			j.jouer( c );
			p.add(c);
		}
		
		// Affichage du pli
		System.out.println( p );
		
		// Calcul du vainqueur
		Joueur gagnant = w.getJoueurs().get( p.indexGagnante( w.getAtout() ) );
		System.out.println( "pli remporté par " + gagnant.getNom() );
		
		// Ajout du pli à l'équipe gagnante
		gagnant.getEquipe().ajouterPli( p );
		
		// Deuxième tour de table
		p = new Pli();
		c = null; 
		Joueur joueurCourant = gagnant;
		for( int i = 0; i < 4; i++ ) {
			c = joueurCourant.getCartes().get(0);
			joueurCourant.jouer( c );
			p.add(c);
			joueurCourant = w.getJoueurs().get( ( w.getJoueurs().indexOf(joueurCourant) + 1 ) % 4 );
		}
		
		// Affichage du pli
		System.out.println( p );
		
		// Calcul du vainqueur
		gagnant = w.getJoueurs().get( w.getJoueurs().indexOf(joueurCourant) + p.indexGagnante( w.getAtout() ) );
		System.out.println( "pli remporté par " + gagnant.getNom() );
		
		// Ajout du pli à l'équipe gagnante
		gagnant.getEquipe().ajouterPli( p );
		
		// etc.
	}

}
*/