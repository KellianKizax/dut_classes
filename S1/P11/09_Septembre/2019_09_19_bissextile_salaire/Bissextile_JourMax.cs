// Bissextile_JourMax.cs : calcule le nombre de jours max dans une annee
// Kellian GOFFIC

using System;

internal class Bissextile_JoursMax
{
    static void Main()
    {
        // Declaration des variables
        // annee :  int :   Annee (YYYY)
        // nbrJours :   int :   Nombre de jours max dans l'annee
        int annee;
        int nbrJours;


        Console.WriteLine("Entrez une année (YYYY) : ");
        annee = int.Parse(Console.ReadLine());

        nbrJours = JoursMax(annee);

        Console.WriteLine("Il y a " + nbrJours + " jours en " + annee + ".");

    }


    /* Bissextile : fonc : bool : determine si l'annee est bissextile (true) ou non (false)
     * Parametres :
     *          Xannee : int : Annee
     * Locales :
     *          restediv4 : double : reste de la division de l'annee par 4
     *          restediv100 : double : reste de la division de l'annee par 100
     * Retour :
     *          resultat : bool : True si l'annee est bissextile
     */
    public static bool Bissextile(int Xannee)
    {
        // Declaration des variables locales
        bool resultat;
        double restediv4;
        double restediv100;

        // On calcule le reste des divisions de l'annee par 4 et 100
        restediv4 = Xannee % 4;
        restediv100 = Xannee % 100;

        // On teste les restes des divisions de l'annee par 4 et 100
        if (restediv4 == 0)
        {
            if (restediv100 != 0)
            {
                resultat = true;
            }
            else
            {
                resultat = false;
            }
        }
        else
        {
            resultat = false;
        }
        return resultat;
    }


    /* JoursMax : fonc : int : calcule le nombre de jours max par annee
     * Parametres :
     *          Xannee : int : Annee
     * Locales :
     *          anneeBiss : bool : True si l'annee est bissextile
     * Retour :
     *          nbrJours : int : nombre de jour max dans l'annee
     */
    public static int JoursMax(int Xannee)
    {
        // Declaration des variables locales
        bool anneeBiss;
        int nbrJours;

        anneeBiss = Bissextile(Xannee);

        // On teste la vérité de anneeBiss
        if ( anneeBiss == true )
        {
            nbrJours = 366;
        }
        else
        {
            nbrJours = 365;
        }
        return nbrJours;
    }


}