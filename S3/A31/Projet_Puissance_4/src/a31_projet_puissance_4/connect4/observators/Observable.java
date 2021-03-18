package a31_projet_puissance_4.connect4.observators;

import java.util.ArrayList;
import java.util.List;

public class Observable {
	
	private List<Observer> myObservers = new ArrayList<>();
	
	/**
	 * Notifie les observateurs en cas de MAJ 
	 *
	 */
	public void notifyObservers() {
		
			for( int i = 0; i < myObservers.size(); i++ )
				myObservers.get(i).update();
		
	}

	/**
	 * Permet d'ajouter un observateur
	 * 
	 * @param o
	 */
	public void addObserver( Observer o) {
		myObservers.add(o);
	}
	
	/**
	 * Permet de retirer un observateur
	 *
	 * @param o
	 */
	public void removeObserver ( Observer o) {
		myObservers.remove(o);
	}
}

