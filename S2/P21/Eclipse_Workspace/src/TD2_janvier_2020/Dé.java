package TD2_janvier_2020;
import java.util.Random;

public class Dé {

	private final Random rd = new Random() ;
	private int valeur;
	
	public Dé() {
		this.valeur = -1;
	}
	
	public int getValeur() {
		return this.valeur;
	}
	
	public int getValeurCachee() {
		return (7-this.getValeur() );
	}
	
	public void lancer() {
		this.valeur = rd.nextInt(6);
	}
	
	public String toString() {
		return Integer.toString(this.valeur) ;
	}
}