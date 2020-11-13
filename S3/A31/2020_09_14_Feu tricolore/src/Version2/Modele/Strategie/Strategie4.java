package Version2.Modele.Strategie;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Strategie4 implements Strategie {

    public static String changer(String couleur) {
        List<String> couleurs = new ArrayList<>(Arrays.asList("Rouge1", "Orange1","Vert1", "Orange2"));
        couleur = couleurs.get((couleurs.indexOf(couleur)+1)%4);
        return couleur;
    }
}
