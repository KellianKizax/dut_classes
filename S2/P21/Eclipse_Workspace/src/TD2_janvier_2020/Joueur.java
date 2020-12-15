package TD2_janvier_2020;

import java.util.Scanner;

public class Joueur 
{
	private String pseudo;
	private int score;
	
	public Joueur(String pseudo)
	{
		this.pseudo = pseudo;
	}
	
	public String getPseudo()
	{
		return this.pseudo;
	}
	
	public int getScore()
	{
		return this.score;
	}
	
	public String toString()
	{
		return "Joueur : " + this.pseudo + ", Score : " + Integer.toString(this.score);
	}
	
	public void commencerLaPartie()
	{
		this.score = 0;
	}
	
	public void lancer(Dé d)
	{
		d.lancer();
		this.score = this.score + d.getValeur();
	}
	
	public boolean estElimine()
	{
		return (this.score > 15);
	}
	
	public boolean aGagne()
	{
		return (this.score == 15);
	}
	
	public boolean veutArreter()
	{
		Scanner sc = new Scanner(System.in);
		System.out.println("Voulez vous arreter ? (O/N)");
		String reponse = sc.next();
		
		return (reponse == "O");
	}
}
