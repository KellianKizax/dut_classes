package TD2_janvier_2020;

public class DeTest5Des {

	public static void main(String[] args)
	{
		int nbLancer = Integer.parseInt(args[0]);
		Dé d1 = new Dé();
		Dé d2 = new Dé();
		Dé d3 = new Dé();
		Dé d4 = new Dé();
		Dé d5 = new Dé();
		int resultats[][][][][] = new int[6][6][6][6][6];
	
		
		for (int i = 0 ; i <= nbLancer ; i++)
		{
			d1.lancer();
			d2.lancer();
			d3.lancer();
			d4.lancer();
			d5.lancer();
			resultats[d1.getValeur()] [d2.getValeur()] [d3.getValeur()] [d4.getValeur()] [d5.getValeur()] ++;
		}
		
		
		System.out.println("N/7776 : " + nbLancer/(6*6*6*6*6) );
		
		for (int a = 1; a <= 6; a ++)
		{
			for (int b = 1; b <= 6; b ++)
			{
				for (int c = 1; c <= 6; c ++)
				{
					for (int d = 1; d <= 6 ; d ++)
					{
						for (int e = 1; e <= 6 ; e ++)
						{
							System.out.println("(" +a+ "," +b+ "," +c+ "," +d+ "," +e+ ") : " + resultats[a-1][b-1][c-1][d-1][e-1] + " \t Difference : " + ((resultats[a-1][b-1][c-1][d-1][e-1])*100)/(nbLancer/7776) + " %");
						} // e
					} // d
				} // c
			} // b
		} // a

	}

}
