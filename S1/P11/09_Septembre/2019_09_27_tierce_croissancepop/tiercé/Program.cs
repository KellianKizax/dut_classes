// tiercé.cs : Permet de connaitre ses chances de gagner au tiercé, quarté, quinté...
// Kellian GOFFIC

using System;
using K_GOFFIC_Library;

namespace tiercé
{
    class Program
    {
        static void Main()
        {
            // Déclaration des variables
            // n :      int :    nombre de chevaux partants
            // p :      int :    nombre de chevaux sur le podium
            // factN :  int  :   factoriel de n
            // factP :  int :    factoriel de p
            // factNP : int :    factoriel de n-p
            // x :      double : dans l'ordre une chance sur x de gagner
            // y :      double : dans le désordre une chance sur y de gagner
            // prctX :  double : (1/x) * 100
            // prctY :  double : (1/y) * 100
            int n;
            int p;
            double x;
            double y;
            double prctX;
            double prctY;
            int factN;
            int factP;
            int factNP;

            // Initialisation des variables : demande à l'utilisateur
            Console.Write("Quel est le nombre de chevaux partants ? : ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Quel est le nombre de chevaux sur le podium ? : ");
            p = int.Parse(Console.ReadLine());
            
            // Initialisation des factoriels
            factN = K_GOFFIC_Library.Library.Factoriel(n);
            factP = K_GOFFIC_Library.Library.Factoriel(p);
            factNP = K_GOFFIC_Library.Library.Factoriel(n - p);

            // Calcul des données
            x = CalculX(factN, factNP);
            y = CalculY(factN, factP, factNP);
            prctX = (1 / x) * 100;
            prctY = (1 / y) * 100;

            // Affichage des résultats
            Console.Write("Dans l'ordre, vous avez une chance sur " + x + " de gagner, soit " + prctX + " %.");
            Console.Write("Dans le désordre, vous avez une chance sur " + y + " de gagner, soit " + prctY + " %.");
        }
        

        //CalculX : fonc : double : calcule x par la formule donnée
        //Parametres :
        //      XfactN : int : factoriel de n
        //      XfactNP : int : factoriel de n-p
        //Retour :
        //      resX : double : resultat X
        public static double CalculX(int XfactN, int XfactNP)
        {
            double resX;
            
            resX = XfactN / XfactNP;

            return resX;
        }


        //CalculY : fonc : double : calcule y par la formule donnée
        //parametres :
        //      XfactN : int : factoriel de n
        //      XfactP : int : factoriel de p
        //      XfactNP: int : factoriel de n-p
        //Retour :
        //      resY : double : resultat y
        public static double CalculY(int XfactN, int XfactP, int XfactNP)
        {
            double resY;

            resY = XfactN / (XfactNP * XfactP);

            return resY;
        }
    }
}