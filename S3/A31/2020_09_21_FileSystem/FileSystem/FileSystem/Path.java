package filesystem;

import java.util.ArrayList;

public abstract class Path {

	private String _name;
	private Path _parent = null;
	private int _size = 4096;
	private ArrayList<Path> _children = new ArrayList<>();
	private String _object;



	// Constructeur Root
	Path(String name){
		_name = name;
	}

	// Constructeur Directory
	Path(String name, Path parent){
		_name = name;
		_parent = parent;
		if(!parentHaveChild(parent, this))
			parent.addChild(this);
	}

	// Constructeur File
	Path(String name, Path parent, String object) {
		_name = name;
		_parent = parent;
		if(!parentHaveChild(parent, this))
			parent.addChild(this);
		_object = object;
		_size = object.length();
	}



	public String getName() {
		return _name;
	}

	public Path getParent() {
		return _parent;
	}

	public int getSize() {
		return _size;
	}

	public void setName(String name){
		_name = name;
	}

	public void setParent(Path parent){
		_parent = parent;
		if(parent != null)
			// on vérifie si le père contient l'objet courant comme enfant, sinon on l'ajoute
			if(!parentHaveChild(parent, this))
				parent.addChild(this);
	}

	public ArrayList<Path> getChildren() {
		return _children;
	}

	public void setChildren(ArrayList<Path> children){
		_children = children;
		for(Path element : children){
			// on vérifie si les enfants de l'objet courant l'ont en tant que parent, sinon on l'ajoute
			if(!childHaveParent(element, this))
				element.setParent(this);
		}
	}

	public void addChild(Path child){
		_children.add(child);
		// on verifie si le nouvel enfant de l'objet courant le possède en tant que parent, sinon on l'ajoute
		if(!childHaveParent(child, this))
			child.setParent(this);
	}

	public void removeChild(Path child){
		_children.remove(child);
	}

	public String getObjet(){
		return _object;
	}

	public void setObject(String object){
		_object = object;
		_size = _object.length();
	}

	// retourne True si le parent contient bien l'enfant donné en paramètre
	public static boolean parentHaveChild(Path parent, Path child){
		boolean result = false;
		if(parent.getChildren().contains(child))
			result = true;

		return result;
	}

	// retourne True si l'enfant contient le parent donné en paramètre
	public static boolean childHaveParent(Path child, Path parent){
		boolean result = false;
		if(child.getParent().equals(parent))
			result = true;

		return result;
	}

	// on supprime toutes les références à l'objet courant
	public void delete(){
		this.getParent().removeChild(this);
		if(this instanceof Directory)
			for(Path child : this.getChildren())
				child.setParent(null);
	}
}