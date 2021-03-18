package Semaine_30_nov;

import java.util.List;

public interface Arbin<T> {

    // Racine de l'arbre
    T racine();

    // Sous arbre gauhce
    Arbin<T> ag();

    // Sous arbre droit
    Arbin<T> ad();


    /**
     * Créé un arbre binaire vide.
     * @param <V> Type de l'arbre binaire.
     * @return Arbre binaire vide créé.
     */
    <V> Arbin<V> initArbin();

    /**
     * Créé un arbre binaire non vide.
     * @param v Racine de l'arbre créé.
     * @param g Sous arbre gauche de type V.
     * @param d Sous arbre droit de type V.
     * @param <V> Type de l'arbre binaire.
     * @return Arbre binaire créé.
     */
    <V> Arbin<V> initArbin( V v, Arbin<V> g, Arbin<V> d );

    /**
     * Créé un arbre binaire avec une racine non vide mais avec deux sous arbres vides.
     * @param rac Racine de type V de l'arbre.
     * @param <V> Type de l'arbre binaire.
     * @return Arbre créé.
     */
    default <V> Arbin<V> initArbin(V rac) {
        return initArbin( rac, initArbin(), initArbin() );
    }


    /**
     * Vérifie si l'arbre binaire est vide.
     * @return 'True' si l'arbre est vide, sinon 'False'.
     */
    boolean estVide();

    /**
     * Calcule la taille de l'arbre binaire.
     * @return Taille de l'arbre.
     */
    default int taille() {
        int res = 0;
        if ( racine() != null ) {
            res++;
            if ( ag().estVide() && !ad().estVide() ) {
                res += ad().taille();
            }
            else if ( !ag().estVide() && ad().estVide() ) {
                res += ag().taille();
            }
            else if ( !( ag().estVide() && ad().estVide() ) ) {
                res += ag().taille() + ad().taille();
            }
        }

        return res;
    }

    /**
     * Vérifie si l'arbre actuel est une feuille.
     * @return 'True' si l'arbre est une feuille, sinon 'False'.
     */
    default boolean estFeuille() {
        boolean res = false;

        if ( ag().estVide() && ad().estVide() ) {
            res = true;
        }

        return res;
    }


    /**
     * Calcule le nombre de feuilles présentes dans l'arbre.
     * @return Le nombre de feuilles.
     */
    default int nbFeuilles() {
        int res;

        if ( this.estVide() ) {
            res = 0;
        }
        else if ( !this.estFeuille() ) {
            // On vérifie que le noeud actuel n'est pas une feuille.
            res = ag().nbFeuilles() + ad().nbFeuilles();
        }
        else {
            // le noeud actuel est une feuille
            res = 1;
        }

        return res;
    }

    /**
     * Calcule la profondeur de l'arbre la plus grande.
     * @return Profondeur
     */
    default int profondeur() {
        int res;

        if ( this.estVide() ) {
            res = 0;
        }
        if ( this.estFeuille() ) {
            res = 1;
        }
        else {
            int prof_g = ag().profondeur();
            int prof_d = ad().profondeur();

            if ( prof_g >= prof_d )
                res = 1 + prof_g;
            else // prof_g < prof_d
                res = 1 + prof_d;
        }

        return res;
    }

    /**
     * Verifie si l'abre est filiforme, c'est à dire si tous les noeuds ont au plus un fils.
     * @return 'true' si l'arbre est filiforme, 'false' sinon.
     */
    default boolean estFiliforme() {
        boolean res = false;

        if ( this.estFeuille() )
            res = true;
        else if ( ag().estVide() && !ad().estVide() )
            res = ad().estFiliforme();
        else if ( !ag().estVide() && ad().estVide() )
            res = ag().estFiliforme();

        return res;
    }

    /**
     * Verifie si l'arbre est homogène, c'est à dire si chaque noeud admet 0 ou 2 fils.
     * @return 'true' si l'arbre est homogène, 'false' sinon.
     */
    default boolean estHomogene() {
        boolean res = false;

        if ( this.estFeuille() )
            res = true;
        else if ( ( ag().estVide() && !ad().estVide() ) || ( !ag().estVide() && ad().estVide() ) )
            res = false; // le noeud actuel admet uniquement 1 fils
        else {
            boolean res_g = ag().estHomogene();
            boolean res_d = ad().estHomogene();
            if ( res_g && res_d )
                res = true;
        }

        return res;
    }

    /**
     * Verifie si l'arbre est équilibré, c'est à dire si la différence entre les profondeurs
     * de deux sous-arbres différents ne diffère pas plus de 1, quel que soit le noeud père.
     * @return 'true' si l'arbre est équilibré, 'false' sinon.
     */
    default boolean estEquilibre() {
        boolean res = false;

        if (this.estFeuille())
            res = true;
        else if ( ag().estVide() && !ad().estVide() ) {
            if ( ad().profondeur() == 1 )
                res = true;
        }
        else if ( !ag().estVide() && ad().estVide() ) {
            if ( ag().profondeur() == 1 )
                res = true;
        }
        else {
            int difference = ag().profondeur() - ad().profondeur();
            if ( difference == 1 || difference == -1 )
                res = true;
        }

        return res;
    }

    /**
     * Verifie si l'arbre est parfait, c'est à dire si chaque noeud sauf les feuilles, a 2 fils
     * @return 'true' si l'arbre est parfait, 'false' sinon.
     */
    default boolean estComplet() {
        boolean res = false;

        if ( this.estFeuille() )
            res = true;
        else if ( ( ag().estVide() && !ad().estVide() ) || ( !ag().estVide() && ad().estVide() ) )
            res = false; // le noeud actuel admet uniquement 1 fils
        else {
            if ( ag().profondeur() == ad().profondeur() ) {
                boolean res_g = ag().estComplet();
                boolean res_d = ad().estComplet();
                if ( res_g && res_d )
                    res = true;
            }
        }

        return res;
    }

    /**
     * Verifie si l'arbre est parfait, c'est à dire si tous les niveaux hormis le dernier sont complets,
     * et si le dernier n'est pas complets, que tous les noeuds soient vers la gauche.
     * @return 'true' si l'arbre est parfait, 'false' sinon.
     */
    default boolean estParfait() {
       boolean res = false;

       if ( this.estFeuille() )
           res = true;
       else if ( !ag().estVide() && ad().estVide() ) {
           res = true;
       }
       else if ( !ag().estVide() && !ad().estVide() ) {
           boolean res_g = ag().estParfait();
           boolean res_d = ad().estParfait();
           if ( res_g && res_d ) {
               if ( ag().profondeur() <= 2 ) {
                   if ( ag().estComplet() && !ad().estComplet() ) {
                       res = true;
                   }
               }
               else {
                   res = true;
               }
           }

       }

       return res;
    }

    /**
     * 06/01/2021
     * creerArbinPreInf
     * Créé un arbre binaire à partir d'une liste préfixée et une liste infixée de cet arbre.
     * @param lpre Liste préfixée de l'arbre.
     * @param linf Liste infixée de l'arbre.
     * @return Arbre binaire représenté par les deux listes.
     */
    default Arbin<T> creerArbinPreInf( List<T> lpre, List<T> linf ) {

        Arbin<T> res;

        if ( lpre.isEmpty() ) {
            res = initArbin();
        }
        else {
            T racine = lpre.get(0);

            int ix = linf.indexOf(racine);

            List<T> lpreg = lpre.subList(1, ix+1);
            List<T> linfg = linf.subList(0, ix);
            List<T> lpred = lpre.subList(ix+1, lpre.size());
            List<T> linfd = linf.subList(ix+1, lpre.size());

            Arbin<T> gauche = creerArbinPreInf( lpreg, linfg );
            Arbin<T> droite = creerArbinPreInf( lpred, linfd );

            res = initArbin( racine, gauche, droite );

        }

        return res;
    }

}
