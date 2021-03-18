package a31_projet_puissance_4.connect4.views;


import java.awt.event.ActionEvent;


import javax.swing.*;

import a31_projet_puissance_4.connect4.controllers.Controller;
import a31_projet_puissance_4.connect4.observators.Observer;


public abstract class View extends JFrame implements Observer {

	protected Controller _controller;
	
	public View( Controller ctrl, String title ) {
		super(title);
		this._controller = ctrl;
	}

	protected abstract void eventPlayDisc( ActionEvent event );

	public abstract void update();
	
}
