using System;

namespace exercices_tab_2D
{
    class Program
    {
        static void Main()
        {
            
        }

        public static void AffichageTab2D(int[,] Xtab)
        {
            for (int i = 0; i < Xtab.GetLength(1); i++)
            {
                Console.Write("[");
                for (int y = 0; y < Xtab.GetLength(0); y++)
                {
                    Console.Write(" " + Xtab[y, i]);
                }
                Console.WriteLine(" ]");
            }
        }

        public static int[,] RandomTab2D()
        {
            int colonnes, lignes, min, max;
            Console.WriteLine(">> Entrez le nombres de colonnes, lignes puis les valeurs min et max");
            colonnes = int.Parse(Console.ReadLine());
            lignes = int.Parse(Console.ReadLine());
            min = int.Parse(Console.ReadLine());
            max = int.Parse(Console.ReadLine());

            int[,] tab = new int[colonnes, lignes];
            Random rd = new Random();

            for (int i = 0; i < tab.GetLength(1); i++)
            {
                for (int y = 0; y < tab.GetLength(0); y++)
                {
                    tab[y, i] = rd.Next(min, max + 1);
                }
            }
            AffichageTab2D(tab);
            return tab;
        }
    }
}
