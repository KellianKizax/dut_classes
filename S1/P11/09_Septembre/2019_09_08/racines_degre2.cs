// racines_degre2.cs : Calcul des racines d'une fonction du second degré
// Kellian GOFFIC

using System;

class racines
{
    static void Main()
    {
        //Definition des variables
        //Tel que :
        //a*x*x + b*x + c
        //delta : double : stock la valeur du discriminant
        double a;
        double b;
        double c;
        double delta;
        double x1;
        double x2;
        
        Console.Write("a=?");
        a = double.Parse(Console.ReadLine());
        
        Console.Write("b=?");
        b = double.Parse(Console.ReadLine());
        
        Console.Write("c=?");
        c = double.Parse(Console.ReadLine());
        
        //Appel de la fonc Discriminant
        delta = Discriminant(a,b,c);
        
        if (delta>0)
            x1 = (-b + Math.Sqrt(delta)) / (2*a);
            x2 = (-b - Math.Sqrt(delta)) / (2*a);
            
            Affichage2racines(x1,x2);
        if (delta==0)
            x1 = (-b) / (2*a);
            Affichage1racine(x1);
        
    }
   
   
    //Discriminant : fonc : double : calcule le discriminant
    //parametres :
    //      X1,X2,X3 : double : tel que X1*x*x + X2*x + X3
    //Local :
    //      delta : double : valeur du discriminant
    public static double Discriminant(double X1, double X2, double X3)
    {
        double delta;
        delta = X2*X2 - 4*X1*X3;
        return delta;
    }
   
   
    //Affichage2racines : proc : Affiche 2 resultats
    //parametres :
    //      X1,X2 : double : résultats
    public static void Affichage2racines(double X1, double X2)
    {
        Console.Write("Les racines sont ");
        Console.Write(X1);
        Console.Write(" et ");
        Console.WriteLine(X2);
    }
   
   
    //Affichage1racine : proc : Affiche 1 resultat
    //parametres :
    //      X1 : double : résultat
    public static void Affichage1racine(double X1)
    {
        Console.Write("Les racines sont ");
        Console.Write(X1);
    }
}
