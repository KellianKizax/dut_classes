package Anciens;

public interface Liste<T>
{
    int longueur();
    boolean estVide(); 
    T elem(int pos);
    void inserer(int pos, T val); 
    void enlever(int pos);
    void remplacer(int pos, T val);

    static boolean equals( Object obj1, Object obj2 ) {
        boolean res = false;

        if ( obj1 == obj2 )
            res = true;
        else if ( obj1 instanceof Liste<?> && obj2 instanceof Liste<?> ) {
            Liste<?> l_obj1 = (Liste<?>) obj1;
            Liste<?> l_obj2 = (Liste<?>) obj2;

            if ( l_obj1.estVide() && l_obj2.estVide() )
                res = true;
            else if ( !l_obj1.estVide() && !l_obj2.estVide() && l_obj1.longueur() == l_obj2.longueur() ) {
                int differences = 0;
                for ( int i = 0; i < l_obj1.longueur(); i++ ) {
                    if ( l_obj1.elem(i) != l_obj2.elem(i) )
                        differences++;
                }
                if ( differences == 0 )
                    res = true;
            }
        }

        return res;
    }
}