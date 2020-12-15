using System;

namespace test_debugage
{
    class Program
    {
        static void Main()
        {
            int h1;
            int h2;
            int m1;
            int m2;

            int d1;
            int d2;

            int res;

            h1 = 1;
            m1 = 47;

            h2 = 2;
            m2 = 32;

            d1 = h1 * 60 + m1;
            d2 = h2 * 60 + m2;

            res = d2 - d1;


            Console.WriteLine("Vous êtes restés :");
            Console.WriteLine(res);
            Console.WriteLine(" minutes :");

        }
    }

}
