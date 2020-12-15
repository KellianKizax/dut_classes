// dix_entiers_minimum_occurences : Demande 10 entiers à l'utilisateur, retourne le plus petit d'entre eux et son nombre d'occurences
// Kellian GOFFIC

using System;

namespace dix_entiers_minimum_occurences
{
    class Program
    {
        static void Main()
        {
            // déclaration des variables
            // nbentier :   int : nombre entré
            // nbmin :      int : nombre minimum
            // occ :        int : nombre d'occurences du nombre le plus petit
            // occPrem :    int : numéro de l'entier le plus petit à sa premiere apparition
            // occDern :    int : numero de l'entier le plus petit à sa derniere apparition
            int nbentier;
            int nbmin;
            int occ;
            int occPrem;
            int occDern;

            Console.Write("Entrez l'entier numéro 1 : ");
            nbmin = int.Parse(Console.ReadLine());
            occ = 1;
            occPrem = 1;
            occDern = 1;

            for (int i = 2; i <= 10; i++)
            {
                Console.Write("Entrez l'entier numéro " + i + " : ");
                nbentier = int.Parse(Console.ReadLine());

                if (nbmin == nbentier)
                {
                    occ = occ + 1;
                    occDern = i;
                }
                else if (nbmin > nbentier)
                {
                    occ = 1;
                    occPrem = i;
                    occDern = i;
                    nbmin = nbentier;
                }
                else { } // rien
            }
            Console.WriteLine("Le nombre le plus petit est : " + nbmin);
            Console.WriteLine("Le nombre d'occurences est : " + occ);
            Console.WriteLine("La première occurence apparait à l'entier : " + occPrem);
            Console.WriteLine("La dernière occurence apparait à l'entier : " + occDern);
        }

    }
}
