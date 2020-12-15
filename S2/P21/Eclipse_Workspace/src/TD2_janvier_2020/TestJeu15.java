package TD2_janvier_2020;

import java.util.ArrayList;

public class TestJeu15 {

	public static void main(String[] args) {
		Joueur joueur1 = new Joueur("j1");
		Joueur joueur2 = new Joueur("j2");
		
		ArrayList<Joueur> listejoueurs = new ArrayList<Joueur>();
		listejoueurs.add(joueur1);
		listejoueurs.add(joueur2);
		
		Jeu15 jeu = new Jeu15(listejoueurs);
		
		jeu.jouerUnePartie();
	}

}
