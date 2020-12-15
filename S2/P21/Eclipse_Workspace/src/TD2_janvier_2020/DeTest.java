package TD2_janvier_2020;

public class DeTest {

	public static void main(String[] args)
	{

		int nbLancer = Integer.parseInt(args[0]);
		Dé d = new Dé();
		int resultats[] = new int[6];
	
		
		for (int i = 0 ; i <= nbLancer ; i++)
		{
			d.lancer();
			resultats[d.getValeur()] ++;
		}
		
		
		System.out.println("N/6 : " + nbLancer/6 );
		
		for (int i = 1; i <= 6; i++)
		{
			System.out.println(i + " : " + resultats[i-1] + "\t Différence : " + (resultats[i-1]*100)/((nbLancer/6)) + " %" );
		}

		
	}

}
