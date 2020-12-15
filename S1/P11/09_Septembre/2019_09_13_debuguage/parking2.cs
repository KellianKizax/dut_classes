using System;

namespace test_debugage_fonction
{
    class Program
    {
        static void Main()
        {
            //Déclaration
            int heure_arrivee;
            int heure_depart;
            int minute_arrivee;
            int minute_depart;

            int temps_reste;

            //Initialisations indirectes
            Console.WriteLine("Entrer votre heure d'arrivée :");
            heure_arrivee = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrer votre minute d'arrivée :");
            minute_arrivee = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrer votre heure de départ :");
            heure_depart = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrer votre minute de départ :");
            minute_depart = int.Parse(Console.ReadLine());

            //Calcul des informations
            temps_reste = calcul_temps_reste(heure_arrivee, minute_arrivee, heure_depart, minute_depart);

            //Affichage du résultat
            affichage_temps_reste(temps_reste);

        }

        /*
            Definition de la procédure affichage_temps_reste
            affichage_temps_reste : proc : int
                affiche le temps resté dans le parking

            parametre :
                xTemps : int : heure

            retour :

            local :

        */
        public static void affichage_temps_reste(int xTemps)
        {
            Console.WriteLine("Vous êtes restés :");
            Console.WriteLine(xTemps);
            Console.WriteLine(" minutes :");
        }
        /*
            Definition de la fonction conversion_en_minute
            conversion_en_minute : fonct : int
                convertit 2 entiers heure,minute en nombre de minute
                depuis 0h00

            parametre :
                xH : int : heure
                xM : int : minute

            retour :
                nb_minutes : int : nombre de minutes écoulées depuis 0h00

            local :

        */
        public static int conversion_en_minute(int xH, int xM)
        {
            //Déclaration
            int nb_minutes;

            //Calcul de la conversion
            nb_minutes = xH * 60 + xM;

            return nb_minutes;
        }

        /*
            Definition de la fonction calcul_temps_reste
            calcul_temps_reste : fonct : int
                calcule le temps resté dans un parking

            parametre :
                xH_arrivee : int : heure d'arrivée
                xM_arrivee : int : minute d'arrivée
                xH_depart : int : heure de départ
                xM_depart : int : minute de départ

            retour :
                nb_minutes_reste : int : nombre de minutes écoulées entre les 2 créneaux

            local :
                conversion_arrivee : int : nombre de minutes écoulées entre l'heure d'arrivée et minuit
                conversion_depart : int : nombre de minutes écoulées entre l'heure de départ et minuit


        */
        public static int calcul_temps_reste(int xH_arrivee, int xM_arrivee, int xH_depart, int xM_depart)
        {
            //Déclaration
            int conversion_arrivee;
            int conversion_depart;
            int nb_minutes_reste;

            //Calcul
            conversion_arrivee = conversion_en_minute(xH_arrivee, xM_arrivee);
            conversion_depart = conversion_en_minute(xH_depart, xM_depart);

            nb_minutes_reste = conversion_depart - conversion_arrivee;

            return nb_minutes_reste;
        }
    }

}