// Salaire.cs : calcule le salaire d'un representant
// Kellian GOFFIC

using System;

namespace Salaire
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Declaration des variables
             * ca :                 double :    chiffre d'affaire mensuel
             * cv :                 int :       puissance fiscale du vehicule
             * km :                 double :    distance deplacement
             * nouv_clients :       int :       nombre de nouveaux clients
             * charges_sociales :   double :    4.25% => 0.9575
             * primeCA :            double :    prime de chiffre d'affaire mensuel
             * frais_depl :         double :    frais de deplacement en fonction cv/km
             * prime_excep :        double :    prime en fonction du nombre de nouveaux clients
             * salaire :            double :    salaire
             */
            double ca;
            int cv;
            double km;
            int nouv_clients;
            double charges_sociales;
            double primeCA;
            double frais_depl;
            double prime_excep;
            double salaire;

            // Initialisation des varaibles
            charges_sociales = 0.9575;
            Console.Write("Chiffre d'affaire du mois ? = ");
            ca = double.Parse(Console.ReadLine());
            Console.Write("Puissance fiscale de votre vehicule en CV ? = ");
            cv = int.Parse(Console.ReadLine());
            Console.Write("Distance parcourue ce mois ? = ");
            km = double.Parse(Console.ReadLine());
            Console.Write("Nombre de nouveaux clients ce mois ? = ");
            nouv_clients = int.Parse(Console.ReadLine());

            // Appel de la fonction Prime
            primeCA = Prime(ca);

            // Appel de la fonction Frais
            frais_depl = Frais(cv, km);

            // Appel de la fonction PrimeExcep
            prime_excep = PrimeExcep(nouv_clients);

            // Appel de la fonction Salaire
            salaire = Salaire(primeCA, prime_excep, frais_depl, charges_sociales);

            // Appel de la procedure d'afficahe du bulletin de paie
            AffichageSalaire(primeCA, prime_excep, frais_depl, charges_sociales, salaire);
        }
              


        /* Prime : fonc : calcule le montant de la prime sur le CA
         * Parametres :
         *      Xca : double : chiffre d'affaire mensuel
         * Locales :
         *      primeCA : double : montant de la prime
         * Retour : primeCA : double
         */
         public static double Prime( double Xca)
        {
            // Declaration de la variable locale
            double primeCA;
            
            // Teste du montant du CA mensuel
            if ( Xca < 3000)
            {
                primeCA = 0;
            }
            else if ( 3000<=Xca && Xca<5000)
            {
                primeCA = 90;
            }
            else if ( 5000<=Xca && Xca<10000)
            {
                primeCA = 180;
            }
            else
            {
                primeCA = 225;
            }
            return primeCA;
        }



        /* Frais : fonc : double : calcule les frais de deplacement
         * Parametres :
         *      Xcv : int : chevaux fiscaux du vehicule
         *      Xkm : double : km parcourus
         * Locales :
         *      frais : double : frais rembourses
         * Retour : frais : double
         */
         public static double Frais(int Xcv, double Xkm)
        {
            // Declaration de la variable locale
            double frais;

            // On teste le kilometrage parcouru puis la puissance fiscale du vehicule
            if (Xkm < 3000)
            {
                if (Xcv == 4  &&  Xcv ==5)
                {
                    frais = 0.25 * Xkm;
                }
                else if (Xcv == 6  && Xcv == 7)
                {
                    frais = 0.30 * Xkm;
                }
                else if (Xcv == 8 && Xcv == 9)
                {
                    frais = 0.33 * Xkm;
                }
                else
                {
                    frais = 0.35 * Xkm;
                }

            }
            else if (Xkm >= 3000)
            {
                if (Xcv == 4 && Xcv == 5)
                {
                    frais = 0.23 * Xkm;
                }
                else if (Xcv == 6 && Xcv == 7)
                {
                    frais = 0.27 * Xkm;
                }
                else if (Xcv == 8 && Xcv == 9)
                {
                    frais = 0.30 * Xkm;
                }
                else
                {
                    frais = 0.31 * Xkm;
                }

            }
            else
            {
                frais = 0;
            }

            return frais;
        }



        /* PrimeExcep : fonc : double : calcule la prime en fonction des nouveaux clients
         * Parametres :
         *      Xclients : int : Nombre de nouveaux clients
         * Locales :
         *      prime : double : prime
         * Retour : prime : double
         */
        public static double PrimeExcep(int Xclients)
        {
            // Declaration de la variable locale
            double prime;

            // On teste le nombre de nouveaux clients
            if (Xclients>=1)
            {
                prime = 75 + 35 * (Xclients - 1);
            }
            else
            {
                prime = 0;
            }

            return prime;
        }



        /* Salaire : fonc : double : calcule le salaire
        * Parametres :
        *      Xprime1 : double
        *      Xprime2 : double
        *      Xfrais : double
        *      Xcharges : double
        * Locales :
        *      salaire : double :
        * Retour : salaire : double
        */
        public static double Salaire(double Xprime1, double Xprime2, double Xfrais, double Xcharges)
        {
            // Declaration de la variable locale
            double salaire;
            salaire = 1500 + Xprime1 + Xprime2 + Xfrais;
            salaire = salaire * Xcharges;

            return salaire;
        }


        /* AfficahgeSalaire : proc : Affiche le bulletin de paie
        * Parametres :
        *      Xprime1 : double : CA
        *      Xprime2 : double : primeExcep
        *      Xfrais : double : frais deplacement
        *      Xcharges : double : charges sociales
        *      Xsalaire : double : salaire net
        * Locales :
        *      salaire : double :
        *      totalca : double :
        *      totalex : double :
        *      totalfrais : double :
        */
        public static void AffichageSalaire(double Xprime1, double Xprime2, double Xfrais, double Xcharges, double Xsalaire)
        {
            // Declaration des variables
            double totalca;
            double totalex;
            double totalfrais;

            totalca = 1500 + Xprime1;
            totalex = totalca + Xprime2;
            totalfrais = totalex + Xfrais;

            Console.WriteLine("============================  Bulletin de paie  ==============================");
            Console.WriteLine("=                                                                            =");
            Console.WriteLine("= Le salaire brut est de 1500 euros.                                         =");
            Console.WriteLine("= La prime de chiffre d'affaire mensuel est de " + Xprime1 + " euros.  | " + totalca + "      euros =");
            Console.WriteLine("= La prime exceptionnelle est de " + Xprime2 + " euros.                | " + totalex + "      euros =");
            Console.WriteLine("= Les frais de deplacement sont de " + Xfrais + " euros.             | " + totalfrais + "      euros =");
            Console.WriteLine("= Les charges sociales sont de 4.25%.                      | " + Xsalaire + " euros =");
            Console.WriteLine("==============================================================================");
            Console.WriteLine("Appuyez sur entrée pour quitter.");
            Console.ReadLine();
        }
    }
}
