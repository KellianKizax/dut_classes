package Anciens;// author : Kellian Goffic

import java.util.Objects;

public class ListeR<T> implements Liste<T> {

    private T premier = null;
    private ListeR<T> suivants = null;

    /**
     * Constructor
     * @param elem  One element of the list
     * @param suite Next elements of the list
     */
    ListeR( T elem, ListeR<T> suite ) {
        premier = elem;
        suivants = suite;
    }

    /**
     * Calculate the number of elements in the lsit
     * @return Number of elements
     */
    @Override
    public int longueur() {
        int size = 0;
        if ( premier != null )
            size +=1;
        if ( suivants != null )
            size += suivants.longueur();

        return size;
    }

    /**
     * Check if the list is empty
     * @return Empty
     */
    @Override
    public boolean estVide() {
        return premier == null;
    }

    /**
     * Give the element of the list for an index
     * @param pos Index of the element
     * @return Element at this index
     * @throws IndexOutOfBoundsException If the index is inferior at zero, superior to the size of the list, or the list is empty.
     */
    @Override
    public T elem(int pos)
    throws IndexOutOfBoundsException {

        if ( pos < 0 || this.estVide() || pos >= this.longueur() )
            throw new IndexOutOfBoundsException("Index out of range");

        T res;

        if ( pos == 0 )
            res = premier;
        else
            res = suivants.elem( pos - 1 );

        return res;
    }

    /**
     * Insert an element to an index in the list
     * @param pos   Index of the new element
     * @param val   Element to insert
     */
    @Override
    public void inserer(int pos, T val) {
        if ( pos < 0 || estVide() || pos >= this.longueur() )
            throw new IndexOutOfBoundsException("Index out of range");

        if ( pos == 0 ) {
            suivants = new ListeR<>( premier, suivants );
            premier = val;
        }
        else {
            suivants.inserer( pos-1, val );
        }
    }

    /**
     * Delete an element at an index of the list
     * @param pos Index of the element
     * @throws ArrayIndexOutOfBoundsException If the index is inferior at zero, superior to the size of the list, or the list is empty.
     */
    @Override
    public void enlever(int pos)
    throws ArrayIndexOutOfBoundsException {
        if ( pos < 0 || this.estVide() || pos >= this.longueur() )
            throw new ArrayIndexOutOfBoundsException("index < 0");

        if ( pos == 0 ) {
            premier = suivants.premier;
            suivants = suivants.suivants;
            // on se supprime pas le "suivant" car le garbage collector s'en occupera (plus de références au suivant)
        }
        else
            suivants.enlever(pos-1);
    }

    /**
     * Replace an element by another at an index in the list
     * @param pos   The index of the element to be replaced.
     * @param val   The new element
     */
    @Override
    public void remplacer(int pos, T val) {
        if ( pos < 0 || this.estVide() || pos >= this.longueur() )
            throw new ArrayIndexOutOfBoundsException("index < 0");

        if ( pos == 0 )
            this.premier = val;
        else
            suivants.remplacer( pos-1, val );
    }

    /**
     * Check if the two objects are equals
     * @param obj Second object to test.
     * @return Equals
     */
    @Override
    public boolean equals( Object obj ) {
        boolean res = false;

        if ( this == obj )
            res = true;
        else if ( obj instanceof ListeR<?>) {
            ListeR<?> l_obj = (ListeR<?>) obj;
            if ( this.estVide() && l_obj.estVide() )
                res = true;
            else if ( !this.estVide() && !l_obj.estVide() )
                res = Objects.equals( this.premier, l_obj.premier ) && this.suivants.equals(l_obj.suivants);
        }

        return res;
    }


    public String toStringR() {
        String res = "";
        if (!estVide()) {
            if (!suivants.estVide())
                res += premier.toString() + ", " + suivants.toStringR();
            else
                res += premier.toString();
        }

        return res;
    }


    public void insert(int pos, T elt) {
        if ( pos < 0 || estVide() || pos >= this.longueur() )
            throw new IndexOutOfBoundsException("Index out of range");

        if ( pos == 0 ) {
            suivants = new ListeR<>( premier, suivants );
            premier = elt;
        }
        else {
            int i = 1; //position actuelle
            ListeR<T> tmp = this.suivants;

            while(i < pos) {
                tmp = tmp.suivants;
                i++;
            }

            ListeR<T> suiv = new ListeR<>(tmp.premier, tmp.suivants);
            tmp.premier = elt;
            tmp.suivants = suiv;
        }
    }



}
