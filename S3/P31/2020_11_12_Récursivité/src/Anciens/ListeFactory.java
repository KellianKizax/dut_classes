package Anciens;//import p31_20_listes_bilateres.ListeBilatere;
//import p31_20_recursivite.Anciens.ListeR;

public interface ListeFactory
{    
    static <T> Liste<T> initListe(int n)
    {
        return new ListeTab<T>(n);
//        return new Anciens.ListeR<T>();
//        return new ListeBilatere<T>();    
    }
}
