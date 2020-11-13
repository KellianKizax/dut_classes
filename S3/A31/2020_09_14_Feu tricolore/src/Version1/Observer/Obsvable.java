package Version1.Observer;

import java.util.ArrayList;

public class Obsvable {
    public ArrayList<Obsver> observers = new ArrayList<>();

    public void addObs(Obsver o){
        observers.add(o);
    }

    public void notif(){
        for(Obsver o : observers){
            o.updat();
        }
    }
}
