package TD2_janvier_2020;

public class DeTest2Des {

	public static void main(String[] args)
	{
		int nbLancer = Integer.parseInt(args[0]);
		Dé d1 = new Dé();
		Dé d2 = new Dé();
		int resultats[][]= new int[6][6];
	
		
		for (int i = 0 ; i <= nbLancer ; i++)
		{
			d1.lancer();
			d2.lancer();
			resultats[d1.getValeur()][d2.getValeur()] ++;
		}
		
		
		System.out.println("N/36 : " + nbLancer/36 );
		
		for (int i = 1; i <= 6; i++)
		{
			for (int y = 1; y<= 6; y++)
			{
				System.out.println("(" +i+ "," +y+ ") : " + resultats[i-1][y-1] + " \t Difference : " + (resultats[i-1][y-1]*100)/(nbLancer/36) + " %");
			}
		}

	}

}
