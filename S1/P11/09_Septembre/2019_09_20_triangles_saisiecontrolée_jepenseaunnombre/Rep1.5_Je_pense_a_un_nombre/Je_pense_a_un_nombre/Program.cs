// Je pense à un nombre : joue au juste nombre avec l'ordinateur
// Kellian GOFFIC

using System;

namespace Je_pense_a_un_nombre
{
    class Program
    {
        static void Main()
        {
            // Declaration des variables
            // random : Random : créer une sentence random
            // nbr_choisi : int : nombre tiré au hasard [0;100]
            // nbr_entre : int : nombre entré par l'utilisateur
            // tours : int : nombre de tours joués
            Random random = new Random();
            int nbr_choisi = random.Next(101);
            int nbr_entre;
            int tours;

            // Initialisation des variables
            // tours = 0 pour le premier tour
            // nbr_entre = -1 afin qu'il ne soit pas dans l'intervalle
            tours = 0;
            nbr_entre = -1;
            while (nbr_choisi != nbr_entre)
            {
                Console.Write("Choisissez un nombre entre 0 et 100 : ");
                nbr_entre = int.Parse(Console.ReadLine());

                // On test la supériorité / infériorité des deux nombres
                if (nbr_entre > nbr_choisi)
                {
                    Console.WriteLine(">> le nombre cherché est plus petit.");
                }
                else if (nbr_entre < nbr_choisi)
                {
                    Console.WriteLine(">> le nombre cherché est plus grand.");
                }
                else
                {
                    //ne fais rien
                }
                tours = tours + 1;
            }
            Console.WriteLine("");
            Console.WriteLine(">> Bravo ! Nombre de tours joués : " + tours);
        }
    }
}
