package Anciens;

import java.util.ArrayList;

public class Hanoi {

    ArrayList<Integer> l1 = new ArrayList<>();
    ArrayList<Integer> l2 = new ArrayList<>();
    ArrayList<Integer> l3 = new ArrayList<>();

    /**
     * Initialise la partie au début du jeu
     * @param n Le nombre de disques à placer sur la tour de départ dans l'ordre croissant
     */
    public Hanoi( int n )
    {
        for (int i = 0; i < n; i++)
        {
            l1.add(n-i);
        }
    }

    /**
     * Résoud par appel récursif Les Tours de Anciens.Hanoi
     * @param n Numéro du disque courant
     * @param t_courante lors du premier appel, tour de départ
     * @param t_intermediaire lors du premier appel, tour intermediaire
     * @param t_destination lors du premier appel, tour finale
     */
    public void hanoi(int n, ArrayList<Integer> t_courante, ArrayList<Integer> t_intermediaire, ArrayList<Integer> t_destination )
    {
        if (n > 0)
        {
            // appel récursif jusqu'au disque courant 1 : disque : courant => intermediaire
            hanoi( n - 1, t_courante, t_destination, t_intermediaire );

            // On déplace le disque courant de la tour courante vers la tour de destination
            t_destination.add( t_courante.remove( t_courante.size() - 1 ) );

            // affichage du contenu des tours
            System.out.println( l1 );
            System.out.println( l2 );
            System.out.println( l3 );
            System.out.println( "Disque déplacé : " + n + "\n" );

            // appel recursif : disque : intermediaire => final
            hanoi(n-1, t_intermediaire, t_courante, t_destination);
        }
    }

    /**
     * Procédure de demarrage
     */
    public void start()
    {
        hanoi(l1.size(), l1, l2, l3);
    }

    public static void main( String[] args ) {

        new Hanoi(5).start();

    }

}
