package Semaine_14_dec;

import Semaine_30_nov.Arbin;

public class ArbinR<T> implements Arbin<T> {

    // Racine de l'arbre binaire
    T _racine;

    // Sous-arbre gauche
    ArbinR<T> _fg;

    // Sous-arbre droit
    ArbinR<T> _fd;


    /**
     * Renvoi la racine de l'arbre binaire.
     *
     * @return La racine.
     */
    @Override
    public T racine() {
        return _racine;
    }

    /**
     * Renvoi le sous-arbre gauche.
     *
     * @return Le sous-arbre gauche.
     */
    @Override
    public Arbin<T> ag() {
        return _fg;
    }

    /**
     * Renvoi le sous-arbre droit.
     *
     * @return Le sous-arbre droit.
     */
    @Override
    public Arbin<T> ad() {
        return _fd;
    }


    /**
     * Créé une instance de l'arbre vide
     *
     * @return Un arbre vide.
     */
    public static <T> ArbinR<T> getInstance() {
        return new ArbreVide<>();
    }

    /**
     * Créé un arbre binaire vide.
     *
     * @return Arbre binaire vide créé.
     */
    @Override
    public <V> Arbin<V> initArbin() {
        return new ArbreVide<>();
    }

    /**
     * Créé un arbre binaire non vide.
     *
     * @param v Racine de l'arbre créé.
     * @param g Sous arbre gauche de type V.
     * @param d Sous arbre droit de type V.
     * @return Arbre binaire créé.
     */
    @Override
    public <V> Arbin<V> initArbin(V t, Arbin<V> g, Arbin<V> d) {

    }

    /**
     * Vérifie si l'arbre binaire est vide.
     *
     * @return 'True' si l'arbre est vide, sinon 'False'.
     */
    @Override
    public boolean estVide() {
        return false;
    }



    public static class ArbreVide<T> extends ArbinR<T> {

        ArbreVide() {}

        /**
         * Vérifie si l'arbre binaire est vide.
         *
         * @return True.
         */
        @Override
        public boolean estVide() {
            return true;
        }

    }

}
