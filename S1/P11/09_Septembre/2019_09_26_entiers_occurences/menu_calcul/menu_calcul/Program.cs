// menu_calcul.cs : Affiche et demande à l'utilisateur différentes oppérations possiblent sur un nombre de base = 0
// Kellian GOFFIC

using System;

namespace menu_calcul
{
    class Program
    {
        static void Main()
        {
            // Déclaration des variables
            // x : int : valeur par défaut = 0
            // rep : int : Numéro de l'opération choisie par l'utilisateur
            int x;
            int rep;

            // Initialisation des variables
            x = 0;
            rep = 0;
            
            // Boucle de demandes et d'opérations
            while ( rep != 4 )
            {
                Console.WriteLine(">>Le chiffre actuel vaut : " + x + "; que souhaitez vous faire ? ( répondre par le numéro des choix )");
                Console.WriteLine("1. Ajouter 1");
                Console.WriteLine("2. Multiplier par 2");
                Console.WriteLine("3. Soustraire 4");
                Console.WriteLine("4. Quitter");
                rep = int.Parse(Console.ReadLine());

                // Test de la réponse
                if ( rep == 1)
                {
                    x = x + 1;
                }
                else if ( rep == 2)
                {
                    x = x * 2;
                }
                else if ( rep == 3)
                {
                    x = x - 4;
                }
                else if ( rep == 4)
                {
                    // Rien ( pour eviter le message d'erreur lors de la sortie )
                }
                else
                {
                    Console.WriteLine(">> ERREUR : La valeur entrée est incorrecte.");
                }
            }
        }
    }
}
