// Croissance_pop_Sims_A_B.cs : Calcule dans combien d'années, la pop de Sims Beta dépassera la pop de Sims Alpha
// Kellian GOFFIC

using System;

namespace Croissance_pop_Sims_A_B
{
    class Program
    {
        static void Main()
        {
            // Déclaration des variables
            // popA : double : population de Sims Alpha
            // popB : double : population de Sims Beta
            // croissA : double : croissance de popA par an
            // croissB : double : croissance de popB par an
            // anneeDepassement : int : l'année ou la popB dépasse popA
            double popA;
            double popB;
            double croissA;
            double croissB;
            int anneeDepassement;

            // Initialisation des variables : demande à l'utilisateur
            Console.Write("Population de A : ");
            popA = double.Parse(Console.ReadLine());
            Console.Write("Croissance par an en nombre d'habitants de la population de A : ");
            croissA = double.Parse(Console.ReadLine());

            Console.Write("Population de B : ");
            popB = double.Parse(Console.ReadLine());
            Console.Write("Croissance par an en pourcentage de la population de B : ");
            croissB = double.Parse(Console.ReadLine());

            // On converti la croissance de pourcentage en décimal
            croissB = 1 + (croissB / 100);

            // Boucle afin de simuler la croissance de chaque population
            // Et obtenir l'année où popB > popA
            for (anneeDepassement = 2; popB <= popA && anneeDepassement < 1000000; anneeDepassement++)
            {
                popA = popA + croissA;
                popB = popB * croissB;
            }

            if (anneeDepassement == 1000000)
            {
                Console.WriteLine(">> Erreur, la simulation dépasse 1 millions d'années.");
            }
            else
            {
                Console.WriteLine(">> La population de Sims Beta dépasse Sims Alpha dans " + anneeDepassement + " années.");
                Console.WriteLine(">> Les populations respectives pour Sims Beta et Sims Alpha sont: " + popB + " habitants, " + popA + " habitants");
            }
        }
    }
}
