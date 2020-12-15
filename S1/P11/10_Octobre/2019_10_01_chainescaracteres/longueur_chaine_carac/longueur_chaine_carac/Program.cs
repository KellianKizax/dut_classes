// longueur.cs : demande d'entrer une chaine de caractere et en affiche la longueur
// Kellian GOFFIC

using System;

namespace longueur_chaine_carac
{
    class Program
    {
        static void Main()
        {
            // Declaration des variables
            // chaine : string
            // longueur : int
            string chaine;
            int longueur;

            // Initialisation des variables : chaine : demande à l'utilisateur
            Console.Write("Entrez une chaîne de caractère : ");
            chaine = Console.ReadLine();
            
            // calcul de l'information
            longueur = chaine.Length;

            Console.WriteLine("Longueur = " + longueur);
        }
    }
}
