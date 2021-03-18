package a31_projet_puissance_4.connect4;

import a31_projet_puissance_4.connect4.controllers.connectfourstandard.StandardController;
import a31_projet_puissance_4.connect4.controllers.fiveinarow.FiveInController;

public class main {

    public static void main(String[] args) {

        StandardController stdctrl = new StandardController( new String[]{"j1", "j2"} );

        FiveInController fictrl = new FiveInController( new String[]{"j1", "j2"} );
    }

}
