package a31_projet_puissance_4.connect4.controllers.fiveinarow;

import a31_projet_puissance_4.connect4.controllers.Controller;
import a31_projet_puissance_4.connect4.models.Game;
import a31_projet_puissance_4.connect4.models.fiveinarow.ConnectFourFiveIn;
import a31_projet_puissance_4.connect4.models.fiveinarow.FiveInGame;
import a31_projet_puissance_4.connect4.models.fiveinarow.FiveInGrid;

import a31_projet_puissance_4.connect4.views.fiveinarow.FiveInView;

public class FiveInController extends Controller {

    /**
     * Constructeur
     * @param playersNames , nom des joueurs
     */
    public FiveInController(String[] playersNames) {
        FiveInGame g = this.createGame(playersNames);
        super._strategy = this.createStrategy(g);
        super._strategy.addObserver( this.createView( this ) );
    }

    /**
     * createGame
     * Créer une partie
     * @param players Nom des joueurs
     * @return FiveInGame
     */
    @Override
    protected FiveInGame createGame(String[] players) {
        FiveInGame g;

        if(players.length==2){
            g = new FiveInGame( players, new FiveInGrid(9,6) );
        }

        else {
            throw new IllegalArgumentException("2 noms de joueurs requis.");
        }

        return g;
    }

    /**
     * Créer la stratégie du jeu
     *
     * @param g
     * @return
     */
    @Override
    protected ConnectFourFiveIn createStrategy(Game g) {
        return new ConnectFourFiveIn( (FiveInGame) g);
    }

    /**
     * Créer la vue du jeu
     *
     * @param ctrl
     */
    @Override
    protected FiveInView createView(Controller ctrl) {
        return new FiveInView( (FiveInController) ctrl );
    }
}
