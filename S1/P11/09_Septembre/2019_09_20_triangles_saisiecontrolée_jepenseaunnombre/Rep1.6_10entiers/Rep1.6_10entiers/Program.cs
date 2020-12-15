using System;

namespace Rep1._6_10entiers
{
    class Program
    {
        static void Main()
        {
            // Declaration des variables
            // entiers : int : somme des 10 entiers
            // nbr_entiers : int : boocle for 10 iterations
            int somme_entiers;
            int nbr_entiers;

            // initialisation de la variable
            somme_entiers = 0;

            // boucle for : demande et additionne les 10 entiers
            for (nbr_entiers=1; nbr_entiers <= 10; nbr_entiers = nbr_entiers + 1)
            {
                Console.WriteLine("Entrez l'entier n°" + nbr_entiers);
                somme_entiers = somme_entiers + int.Parse(Console.ReadLine());
            }

            // Affichage de la somme des 10 entiers
            Console.Write(">> La somme des 10 entiers est de " + somme_entiers);
        }
    }
}
