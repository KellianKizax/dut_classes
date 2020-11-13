package Version1;

import Version1.Modele.Feu;
import Version1.View.VueGraphique;
import Version1.View.VueText;

public class Main {
    public static void main(String[] args){

        Feu f = new Feu(false);
        VueText vt = new VueText(f);
        VueGraphique vg = new VueGraphique(f);
        f.addObs(vt);
        f.addObs(vg);
    }
}
