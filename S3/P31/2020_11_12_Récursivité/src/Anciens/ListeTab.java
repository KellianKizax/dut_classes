package Anciens;

public class ListeTab<T> implements Liste<T>
{
    Object[] eVal;
    int nbVal;
    
    public ListeTab(int taille) {
        if (taille < 0)
            throw new IllegalArgumentException( "Anciens.ListeTab : taille négative " + taille );
        nbVal = 0;
        eVal = new Object[taille];
    }

    @Override
    public int longueur()
    {
        return nbVal;
    }

    @Override
    public boolean estVide()
    { 
        return nbVal == 0;
    }
    
    @SuppressWarnings("unchecked")
    @Override
    public T elem(int pos)
    {
        if (pos < 0 || pos >= nbVal)
        {
            throw new IndexOutOfBoundsException( "elem : mauvais index " + pos );
        }
        return (T) eVal[pos];
    }

    
    @Override
    public void inserer( int pos, T val )
    {
        if (pos < 0 || pos > nbVal)
        {
            throw new IndexOutOfBoundsException( "inserer : mauvais index " + pos );
        }
        if (nbVal >= eVal.length)
        {
            throw new IllegalStateException("inserer: Anciens.Liste Pleine");
        }
        for (int i = nbVal; i > pos; i--)
        {   
            eVal[i] = eVal[i-1];
        }
        eVal[pos] = val;
        nbVal++;
    }

    @Override
    public void enlever(int pos) 
    {
        if (pos < 0 || pos >= nbVal)
        {
            throw new IndexOutOfBoundsException(
                "enlever : mauvais index " + pos);
        }
        for (int i = pos + 1; i < nbVal; i++)
        {   
            eVal[i-1] = eVal[i];
        }
        nbVal--;
    }

    @Override
    public void remplacer(int pos, T val)
    {
        if (pos < 0 || pos >= nbVal)
        {
            throw new IndexOutOfBoundsException(
                "remplacer : mauvais index " + pos);
        }   
        eVal[pos] = val;
    }
        
    public static void main(String[] args)
    {
        Liste<String> li_Str = new ListeTab<String>(10);
        Liste<Integer> li_Int = new ListeTab<Integer>(10);

        li_Str.inserer(0,"abcdef");
        li_Int.inserer (0, 5);      // Auto_boxing

        String s = li_Str.elem(0);
        int i = li_Int.elem(0);     // Auto_unboxing

//       li_Str.inserer(1, 6);           // ERREUR à la compilation
//       String t = li_Int.elem(0);  // ERREUR à la compilation
    }
}
