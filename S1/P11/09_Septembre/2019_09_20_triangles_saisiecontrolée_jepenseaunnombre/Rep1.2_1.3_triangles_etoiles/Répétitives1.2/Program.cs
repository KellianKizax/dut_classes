using System;

namespace Répétitives1._2
{
    class Program
    {
        static void Main()
        {
            int h;
            int i;

            for (h=1; h<=3; h=h+1)
            {
                for (i=1; i<=h; i=i+1)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }


            int h2;
            int i2;
            int e2;

            for (h2=1; h2<=3; h2=h2+1)
            {
                for (e2=3-h2; e2>0; e2=e2-1)
                {
                    Console.Write(" ");
                }
                for (i2=1; i2<=h2-1; i2=i2+1)
                {
                    Console.Write("**");
                }
                Console.Write("*");
                for (e2=3-h2; e2>0; e2=e2-1)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }
    }
}
