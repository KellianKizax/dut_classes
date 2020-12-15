using System;

namespace stringTOdouble
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Entrez un nombre à virgule au format : ' 'xx,xx' ' : ");
            Console.Write(StringToint(Console.ReadLine()));
        }

        // StringToint : fonc : converti une chaine de charactère en un nombre à virgule
        // Paramètre : Xentree      : string    : nombre à virgule sous forme de chaine de charactères
        // Local :  nombre          : double    : contient le nombre a virgule final
        //          denominateur    : int       : permet d'ajouter les decimaux à nombre
        //          nouvelle_valeur : int       : contient le chiffre en cours de traitement
        //          i               : int       : indice de l'emplacement actuel du charactère traité dans la chaine 'Xentree'
        // Retour : nombre          : double : contient le nombre a virgule final
        public static double StringToint(string Xentree)
        {
            // Declaration des variables
            double nombre;
            int denominateur;
            double nouvelle_valeur;
            int i;

            // Initialisation des variables
            denominateur = 10;
            i = 0;
            nombre = 0;

            // On incremente l'indice jusqu'à obtenir un charactère différent de l'esapce
            while (Xentree[i] == ' ')
            {
                i++;
            }

            // Traitement des charactères jusqu'à la virgule
            while (Xentree[i] != ',')
            {
                nouvelle_valeur = int.Parse(Xentree[i].ToString());
                nombre = nombre * 10 + nouvelle_valeur;
                i++;
            }

            // Pour passer la virgule
            i++;

            // Traitement des charactères après la virgule jusqu'à un espace
            while (Xentree[i] != ' ')
            {
                nouvelle_valeur = int.Parse(Xentree[i].ToString());
                nombre = nombre + nouvelle_valeur / denominateur;
                denominateur = denominateur * 10;
                i++;
            }

            return nombre;
        }
    }
}
