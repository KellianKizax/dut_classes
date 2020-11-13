package whist.whistmodel;

import java.util.ArrayList;

/**
 * Modélise une équipe dans une partie de Whist.
 */
public class Equipe {

	// Les plis remportés par l'équipe
	private ArrayList<Pli> plis =  new ArrayList<>(13);
	
	


	/**
	 * Ajoute un pli au tas des plis remportés par l'équipe.
	 * 
	 * @param pli le pli à ajouter
	 */
	public void ajouterPli(Pli pli) {
		plis.add(pli);
	}


	/**
	 * Renvoie les points remportés par l'équipe à la fin de la partie.
	 * 
	 * @return les points de l'équipe
	 */
	public int getPoints() {
		return Math.max( plis.size() - 6, 0 );
	}
	
	
	/**
	 * Renvoie la liste des plis de l'équipe sous forme de chaîne de caractères.
	 *
	 * @return Une chaîne détaillant les cartes des plis remportés par this.
	 */
	@Override
	public String toString() {
		return plis.toString();
	}

};
