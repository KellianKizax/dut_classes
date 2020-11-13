package Version2.Modele.Strategie;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Strategie3 implements Strategie {

    public static String changer(String couleur) {
        List<String> couleurs = new ArrayList<>(Arrays.asList("Rouge1", "Vert1", "Orange1"));
        couleur = couleurs.get((couleurs.indexOf(couleur)+1)%3);
        return couleur;
    }
}
