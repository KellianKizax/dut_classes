package TD1_janvier_2020;
import java.util.HashMap;
import java.util.Scanner;

public class Quizz_JO_hiver {

	public static void main(String[] args)
	{
		HashMap<String, Year> jos = JeuxOlympiques();
		Object[] cles = jos.keySet().toArray();
		
		int longueur = cles.length;
		int indice = (int) (Math.random() * longueur);
		
		int value = jos.get(cles[indice]).getValue();
		
		System.out.println("En quelle années les JO de " + cles[indice] + " ont-ils eu lieu ?");
		
		Scanner sc = new Scanner(System.in);
		int reponse = (Year.parse(sc.next())).getValue();
		sc.close();
		
		if (value != reponse)
		{
			System.out.print("Perdu !");
		}
		else
		{
			System.out.print("Gagné !");
		}

	}
	
	public static HashMap<String, Year> JeuxOlympiques()
	{
		HashMap<String, Year> jos = new HashMap<String, Year>();
		jos.put("Chamonix", Year.of(1924));
        jos.put("Saint-Moritz", Year.of(1928));
        jos.put("Lake Placid", Year.of(1932));
        jos.put("Garmisch-Partenkirchen", Year.of(1936));
        jos.put("Saint-Moritz", Year.of(1948));
        jos.put("Oslo", Year.of(1952));
        jos.put("Cortina d'Ampezzo", Year.of(1956));
        jos.put("Squaw Valley", Year.of(1960));
        jos.put("Innsbruck", Year.of(1964));
        jos.put("Grenoble", Year.of(1968));
        jos.put("Sapporo", Year.of(1972));
        jos.put("Innsbruck", Year.of(1976));
        jos.put("Lake Placid", Year.of(1980));
        jos.put("Sarajevo", Year.of(1984));
        jos.put("Calgary", Year.of(1988));
        jos.put("Albertville", Year.of(1992));
        jos.put("Lillehammer", Year.of(1994));
        jos.put("Nagano", Year.of(1998));
        jos.put("Salt Lake City", Year.of(2002));
        jos.put("Turin", Year.of(2006));
        jos.put("Vancouver", Year.of(2010));
        jos.put("Sotchi", Year.of(2014));
        jos.put("PyeongChang", Year.of(2018));
		return jos;
	}

}
