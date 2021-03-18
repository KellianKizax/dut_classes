package a31_projet_puissance_4.connect4.models;

public abstract class Disc {
	
	/**
	 * 
	 * Modelise un jeton de puissance 4
	 * 
	 */
	
	private int sizeX = 1;
	private int sizeY = 1;
	private Player owner;
	
	/**
	 * 
	 * Constructeur
	 * 
	 * @param owner , Joueur qui possede le jeton
	 * @param size , taille du jeton
	 * 
	 */
	
	public Disc (Player owner , int size) {
		this.owner = owner;
		this.sizeX = size;
		this.sizeY = size;
	}
	
	/**
	 * 
	 * Constructeur
	 * 
	 * @param owner , Joueur qui possede le jeton
	 * @param sizeX , largeur du jeton
	 * @param sizeY , longueur du jeton
	 */
	public Disc (Player owner, int sizeX , int sizeY) {
		this.owner = owner;
		this.sizeX = sizeX;
		this.sizeY = sizeY;
	}
	
	/**
	 * Renvoie le propriétaire du jeton
	 * 
	 * @return le propriétaire du jeton
	 */
	public Player getOwner() {
		return owner;
	}
	
	/**
	 * Permet au controleur d'indiquer le propriétaire du jeton
	 * 
	 * @param owner
	 */
	public void setOwner(Player owner) {
		this.owner = owner;
	}
	
	/**
	 * Renvoie la largeur du jeton
	 * 
	 * @return la largeur du jeton
	 */
	public int getSizeX() {
		return sizeX;
	}
	
	/**
	 * Permet au controleur d'indiquer la largeur du jeton
	 * 
	 * @param sizeX
	 */
	public void setSizeX(int sizeX) {
		this.sizeX = sizeX;
	}
	
	/**
	 * 
	 * Renvoie la longueur du jeton
	 * 
	 * @return la longueur du jeton 
	 */
	public int getSizeY() {
		return sizeY;
	}
	
	/**
	 * Permet au controleur d'indiquer la longeur du jeton
	 * 
	 * @param sizeY
	 */
	public void setSizeY(int sizeY) {
		this.sizeY = sizeY;
	}

	public abstract boolean equals( Object o );
	

}
