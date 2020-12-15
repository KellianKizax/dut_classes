using System;

namespace SaisieControlée
{
    class Program
    {
        static void Main()
        {
            // Declaration des variables
            // VALDEFAUT :  char : const : Valeur par defaut de la réponse attendue
            // valChar :    char :      Réponse de l'utilisateur
            // i            int : boucle while : 3 essais pour l'utilisateur de rentrer une réponse
            const char VALDEFAUT = 'N';
            char valChar;
            int MAXERR;
            MAXERR = 1;

            valChar = 'F';
            while (valChar!='O' && valChar!='N' && MAXERR<=3)
            {
                Console.Write("Oui ou Non (O/N) ? :");
                valChar = char.ToUpper(char.Parse(Console.ReadLine()));
                MAXERR = MAXERR + 1;
            }
            valChar = VALDEFAUT;
        }
    }
}
