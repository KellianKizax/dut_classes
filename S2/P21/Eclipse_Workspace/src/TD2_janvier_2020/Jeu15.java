package TD2_janvier_2020;

import java.util.ArrayList;

public class Jeu15 {

	private ArrayList<Joueur> lesJoueurs;
	private Dé leDe;
	
	public Jeu15(ArrayList<Joueur> desJoueurs)
	{
		this.lesJoueurs = desJoueurs;
		Dé d = new Dé();
		this.leDe = d;
	}
	
	public ArrayList<Joueur> getJoueurs()
	{
		return this.lesJoueurs;
	}
	
	public void faireJouerUnePartie(Joueur j)
	{
		boolean stop = false;
		while (!stop)
		{	
			System.out.println(j.toString() + ", a vous de jouer !");
			j.lancer(this.leDe);
			System.out.println(j.toString());
			stop = j.veutArreter();
		}
	}
	
	public void jouerUnePartie()
	{
		for (Joueur joueur : this.lesJoueurs)
		{
			this.faireJouerUnePartie(joueur);
		}
	}
	
	public ArrayList<Joueur> lesGagnants()
	{
		ArrayList<Joueur> gagnants = new ArrayList<Joueur>();
		int scoreMax = -1;
		Joueur joueurScoreMax = null;
		for (Joueur joueur : this.lesJoueurs)
		{
			if (joueur.getScore() > scoreMax)
			{
				scoreMax = joueur.getScore();
				joueurScoreMax = joueur;
			}
			
			if (joueur.aGagne())
			{
				gagnants.add(joueur);
			}
		}
		
		if (gagnants.size() == 0)
		{
			gagnants.add(joueurScoreMax);
		}
		
		return gagnants;
	}
}
