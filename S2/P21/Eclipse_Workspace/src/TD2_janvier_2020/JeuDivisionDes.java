package TD2_janvier_2020;

public class JeuDivisionDes {

	public static void main(String[] args)
	{
		Dé d1 = new Dé();
		Dé d2 = new Dé();
		
		int d1valeur;
		int d2valeur;
		
		int somme;
		int diviseur;
		
		d1.lancer();
		d2.lancer();
		
		d1valeur = d1.getValeur()+1;
		d2valeur = d2.getValeur()+1;
		
		System.out.println("d1 => " + d1valeur);
		System.out.println("d2 => " + d2valeur);
		
		somme = d1valeur + d2valeur;
		
		System.out.println(d1valeur + " + " + d2valeur + " => " + somme);
		
		d1.lancer();
		
		diviseur = d1.getValeur()+1;
		
		System.out.println("d1 => " + diviseur);
		
		if (somme%diviseur == 0)
		{
			// gagné
			System.out.println(diviseur + " divise " + somme + " : Gagné !");
			
		}
		else
		{
			// perdu
			System.out.println(diviseur + " ne divise pas " + somme + " : Perdu !");
		}
	}

}
