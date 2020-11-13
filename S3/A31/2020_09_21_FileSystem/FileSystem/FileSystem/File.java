package filesystem;

import java.util.ArrayList;

public class File extends Path {

    // constructeur hérité de Path à 2 paramètres
	File(String name, Path parent, String object) {
		super(name, parent, object);
	}



	// 3 méthodes suivantes sont overrides pour empecher des actions sur les enfants de fichiers
	@Override
	public ArrayList<Path> getChildren() {
		return null;
	}

	@Override
	public void setChildren(ArrayList<Path> children) {}

	@Override
	public void addChild(Path child) {}
}