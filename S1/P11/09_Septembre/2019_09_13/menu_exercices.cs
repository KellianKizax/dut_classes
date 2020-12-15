// menu_exercices.cs : affiche un menu permettant de choisir l'execution d'un exercices
// Kellian GOFFIC

using System;
using System.Diagnostics;

class Menu
{
    static void Main()
    {
        // Déclaration des variables :
        // reponse : int : choix de l'exercice par l'utilisateur :
        int reponse;

        // Affichage à l'utilisateur des différents choix
        Console.WriteLine("Bonjour !  Quel exercices souhaitez vous executer ?");
        Console.WriteLine("Exercice 1 : majeur ou mineur ?");
        Console.WriteLine("Exercice 2 : Impots Zorglub");
        Console.WriteLine("Exercice 3 : Montant frais d'adhésion association sportive");
        Console.WriteLine("1/2/3 ? =");
        
        // Initialisation de la variable par l'utilisateur
        reponse = int.Parse(Console.ReadLine());

        // Action en fonction du choix de l'utilisateur
        if (reponse == 1)
        {
            // Demarre le programme testage.exe
            Process.Start("testage.exe");
        }
        else if (reponse == 2)
        {
            // Demarre le programme impots_Zorglub.exe
            Process.Start("impots_Zorglub.exe");
        }
        else if (reponse == 3)
        {
            // Demarre le programme asso_sportive.exe
            Process.Start("asso_sportive.exe");
        }
        else
        {
            Console.WriteLine("Réponse inatendue. Appuyez sur une touche pour fermer la fenetre.");
            Console.ReadLine();
        }
    }
}