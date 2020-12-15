//dix_entiers_somme.cs : demande l'entrée de 10 entiers à l'utilisateur et calcule leur somme

using System;

namespace dix_entiers_somme
{
    class Program
    {
        static void Main()
        {
            // déclaration des variables :
            // nb : int : nombre entré
            // somme : int : somme des entiers entrés
            int nb;
            int somme;

            // initialisation de la variable somme
            somme = 0;

            // boucle for : demande des 10 entiers et calcul de leur somme
            for (int i = 1; i<=10; i++)
            {
                Console.Write("Entrez votre nombre entier numéro " +i+ " : ");
                nb = int.Parse(Console.ReadLine());
                somme = somme + nb;
            }
            Console.WriteLine("Somme : " + somme);
        }
    }
}
