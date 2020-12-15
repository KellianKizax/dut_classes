package TD1_janvier_2020;
import java.util.Scanner;

public class YearTest {

	public static void main(String[] args)
	{
		// bissextile - nombre de jours - année bissextile suivante precedente
		Scanner sc = new Scanner(System.in);
		
		// Demande à l'utilisateur une année
		System.out.print("Entez une année : ");
		Year annee = Year.parse(sc.next());
		
		sc.close();
		
		// Affiche si l'année est bissextile et le nombre de jours de l'année
		System.out.println("Bissextile : " + annee.isLeap());
		System.out.println("Nombre de jours : " + annee.length());
		
		// Cherche l'année bissextile suivante
		Year anneeSuiv = Year.of(annee.getValue() + 1);
		int i = 1;
		while (i<=4 && !anneeSuiv.isLeap())
		{
			anneeSuiv = Year.of(annee.getValue() + i);
			i++;
		}
		System.out.println("Annee bissextile suivante : " + anneeSuiv.getValue());


		// Cherche l'année bissextile précédente
		Year anneePrec = Year.of(annee.getValue() - 1);
		i = 1;
		while (i<=4 && !anneePrec.isLeap())
		{
			anneePrec = Year.of(annee.getValue() - i);
			i++;
		}
		System.out.println("Annee bissextile precedente : " + anneePrec.getValue());

	}

}
