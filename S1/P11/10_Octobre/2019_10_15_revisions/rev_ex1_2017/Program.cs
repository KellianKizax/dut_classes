// prime_employes.cs : calcule la prime de chaque employé et le total versé pour tous les employés
// Kellian GOFFIC

using System;

namespace rev_ex1_2017
{
    class Program
    {
        static void Main()
        {
            // Déclaration des variables
            // emp_n     : int    : nombre d'employés
            // s         : double : salaire
            // m         : int    : nombre de mois travaillés
            // t         : int    : nombre de jours d'arrêt
            // prime_tot : double : total de toutes les primes
            // t_tot     : int    : nombre total de tous les jours d'arrêt
            int emp_n;
            double s;
            int m;
            int t;
            double prime_tot;
            int t_tot;

            // Initialisation des variables
            prime_tot = 0;
            t_tot = 0;

            Console.Write("Nombre d'employés ? : ");
            // Initialisation de la variable par l'utilisateur
            emp_n = int.Parse(Console.ReadLine());

            if (emp_n > 0)
            {
                // Boucle de calcul de la prime pour chaque employé
                for (int i = 1; i <=emp_n; i++)
                {
                    Console.Write("Salaire ? : ");
                    s = double.Parse(Console.ReadLine());
                    Console.Write("Nombre de mois travaillés ? : ");
                    m = int.Parse(Console.ReadLine());
                    Console.Write("Nombre de jours d'arrêt de travail ? : ");
                    t = int.Parse(Console.ReadLine());

                    prime_tot = prime_tot + Prime(s, m, t);
                    Console.WriteLine("n°"+i+" | sal: "+s+ " | nbr mois travaillés: " + m+ " | nbr de jours d'arrêt: " + t+ " | prime:" + Prime(s,m,t));
                    t_tot = t_tot + t;
                }
                // Affichage des derniers resultats
                Console.WriteLine("Prime totale versée : " + prime_tot);
                Console.WriteLine("Nombre de jours total d'arrêt de travail : " + t_tot);
                Console.WriteLine("Nombre moyen de jours d'arrêt de travail : " + t_tot / emp_n);
            }
        }

        // prime : fonc : calcule la prime en fonction du salaire, du nombre de mois travaillés et du nombre de jours d'arrêt de travail
        // Paramètres :
        //      Xs  : double    : salaire de base
        //      Xm  : int       : nombre de mois travaillés
        //      Xt  : int       : nombre de jours d'arrêt de travail
        // Local / Retour :
        //      Prime   : double    : valeur de la prime
        static public double Prime(double Xs, int Xm, int Xt)
        {
            double prime;

            if (Xm >= 10)
            {
                prime = Xs;
            }
            else
            {
                prime = (Xs * Xm) / 12;
            }

            if (Xt > 10)
            {
                prime = prime * 0.25;
            }
            else if (Xt < 3)
            {
                prime = prime * 2;
            }
            else
            {
                prime = prime * 0.5;
            }

            return prime;
        }
    }
}
