package TD1_janvier_2020;
import java.util.Scanner;

public class EssaiPuissance {

	public static void main(String[] args)
	{
		int nbParams = args.length;
		int x = 0;
		int y = 0;
				
		if (nbParams == 2)
		{
			x = Integer.parseInt(args[0]);
			y = Integer.parseInt(args[1]);
		}
		else
		{
			Scanner sc = new Scanner(System.in);
			
			System.out.println("x = ?");
			x = sc.nextInt();
			
			System.out.println("y = ?");
			y = sc.nextInt();
			
			sc.close();
		}
		
		System.out.println(x + " puissance " + y + " = " + puissance(x, y));
	}
	
	public static long puissance(int a, int k)
	{
		long res = 1;
		long p = a;
		for (int i = k; i > 0; i = i/2)
		{
			if (i % 2 == 1)
			{
				res = res * p;
			}
			
			p = p * p;
		}
		
		return res;
	}

}
