package Version2;

import Version2.Modele.Feu;
import Version2.View.VueGraphique;
import Version2.View.VueText;

public class Main {
    public static void main(String[] args){

        Feu f = new Feu(false);
        VueText vt = new VueText(f);
        VueGraphique vg = new VueGraphique(f);
        f.addObs(vt);
        f.addObs(vg);
    }
}
