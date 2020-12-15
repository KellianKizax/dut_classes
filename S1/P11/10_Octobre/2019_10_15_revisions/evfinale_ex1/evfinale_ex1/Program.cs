// exercice 1 : ecrire la fonction seTerminePar(pSuffixe, pMot) qui renvoie un booléen et qui détermine si le mot se termine par le suffixe proposé.
// Kellian GOFFIC

using System;

namespace evfinale_ex1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(seTerminePar("bite", "habite"));
        }

        public static bool seTerminePar(string Xsuffixe, string Xmot)
        {
            bool rep;
            int rep_boucle;

            rep_boucle = 0;
            rep = false;

            for (int i = 0; i < Xsuffixe.Length; i++)
            {
                if (Xmot[Xmot.Length - 1 - i] != Xsuffixe[Xsuffixe.Length - 1 - i])
                {
                    rep_boucle++;
                }
                else { /* Rien */ }

                if (rep_boucle > 0)
                {
                    rep = false;
                }
                else
                {
                    rep = true;
                }
            }
            return rep;
        }
    }
}
