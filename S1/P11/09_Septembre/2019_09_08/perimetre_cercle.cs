// perimetre_cercle.cs : Calcul du perimetre d'un cercle
// Kellian GOFFIC

using System;

class perimetre
{
    static void Main()
    {
        //Declaration variables
        //rayon : double : longueur du rayon
        //perimetre : double : longueur du perimetre
        double rayon;
        double perimetre;
        
        Console.WriteLine("Rayon ?");
        rayon = double.Parse(Console.ReadLine());
        
        //appel de la fonction CalculPerimetre
        perimetre = CalculPerimetre(rayon);
        
        //appel de la procédure d'affichage AffichageResultat
        AffichageResultat(perimetre);
    }
    
    //CalculPerimetre : fonc : double : calcul le perimetre à partir du rayon
    //Parametre :
    //      Xrayon : double : longueur du rayon
    public static double CalculPerimetre(double Xrayon)
    {
        //perimetre : double : longueur du perimetre
        double perimetre;
        
        //calcul du perimetre
        perimetre = 2 * Math.PI * Xrayon ;
        return perimetre;
    }
    
    //AffichageResultat : proc d'affichage : Affiche le resultat attendu
    //Parametres : 
    //      Xperimetre : double : perimetre du cercle calculé plus tot    
    public static void AffichageResultat(double Xperimetre)
    {
        Console.Write("Le perimetre du cercle est de ");
        Console.WriteLine(Xperimetre);
    }
}
