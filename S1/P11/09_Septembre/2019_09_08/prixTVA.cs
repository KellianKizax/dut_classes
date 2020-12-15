//prixTVA.cs : Calcul du prix TTC
//Kellian GOFFIC

using System;

class prixTva
{
    static void Main()
    {

        //Declaration des variables
        //prixHT  : double : prix hors taxes
        //tva     : double : pourcentage de la tva sous la forme 1.xx
        //prixTTC : double : prixHT * tva
        double prixHT;
        double tva;
        double prixTTC;
    
        Console.WriteLine("Quel est le prix hors taxes ?");
        prixHT = double.Parse(Console.ReadLine());
    
        Console.WriteLine("Quelle est la TVA ? 1,xx");
        tva = double.Parse(Console.ReadLine());
        
        //calcul du prixTTC
        prixTTC = prixHT * tva;

        //appel procédure d'affichage
        AffichageResultat(prixTTC);
    }
    
    
    //AffichageResultat : procédure d'affichage : Affiche le resultat attendu
    //Parametres :
    //      Xprix : double : prix ttc calculé plus tot    
    public static void AffichageResultat(double Xprix)
    {
        Console.Write("Le prix TTC est de ");
        Console.Write(Xprix);
        Console.WriteLine(" €.");
    }
}
