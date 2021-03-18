package a31_projet_puissance_4.connect4;

import java.util.Arrays;

/**
 * Détection d'un alignement de booléens dans un plateau de type Puissance4
 * 
 */
public class FullRowDetection {

	/**
	 * Détecte 4 'true' ou 4 'false' alignés dans une des 4 directions |, _, /, \.
	 * 
	 * Si un élément a la valeur null, tout ce qui est au-dessus est sensé être null.
	 * @param board : un tableau de valeurs de type Boolean ou null
	 * @return les coordonnées des deux extrémités du premier alignement trouvé.
	 */
	public int[] detect( Boolean[][] board ) {

		int l = 4;
		int ll = l - 1;

		int width = board.length;
		int height = board[0].length;


		// South - North
		int h = height - ll;
		for ( int col = 0; col < width; col++ )
			for ( int row = 0; row < l; row++ ) {
				Boolean b = board[col][row];
				if ( b == null )
					break;
				boolean success = true;
				for ( int i = 1; i < l && success; i++ )
					success &= ( board[col][row + i] == b );
				if ( success )
					return new int[] { col, row, col, row + ll };
			}

		
		//  West - East
		int w = width - ll;
		for ( int col = 0; col < w; col++ )
			for ( int row = 0; row < height; row++ ) {
				Boolean b = board[col][row];
				if ( b != null ) {
					boolean success = true;
					for ( int i = 1; i < l && success; i++ )
						success &= ( board[col + i][row] == b );
					if ( success )
						return new int[] { col, row, col + ll, row };
				}
			}


		// SouthWest - NorthEast
		h = height - ll;
		w = width - ll;
		for ( int col = 0; col < w; col++ )
			for ( int row = 0; row < h; row++ ) {
				Boolean b = board[col][row];
				if ( b != null ) {
					boolean success = true;
					for ( int i = 1; i < l && success; i++ )
						success &= ( board[col + i][row + i] == b );
					if ( success )
						return new int[] { col, row, col + ll, row + ll };
				}
			}

		// NorthWest - SouthEast
		w = width - ll;
		for ( int col = 0; col < w; col++ )
			for ( int row = ll; row < height; row++ ) {
				Boolean b = board[col][row];
				if ( b != null ) {
					boolean success = true;
					for ( int i = 1; i < l && success; i++ )
						success &= (board[col + i][row - i ] == b);
					if ( success )
						return new int[] { col, row, col + ll, row - ll };
				}
			}
		
		
		// No connection detected
		return null;
	}
	
	
	// Test
	public static void main( String[] args ) {
		
		int width = 6, height = 5;
		
		boolean r = true; // red
		boolean y = false; // yellow
		
		// *Représentation* du plateau de jeu 
		Boolean[][] tab = {
				{null, 	null, 	null, 	null,   null,   null},
				{   r,  null, 	   r,      y,   null,   null},
				{   r, 	null,	   y,      r,      r,      y},
				{   r,     y,      y,      r,      r,      y},
				{   r,     y,      y,      r,      y,      r}
		};
		
		// On intervertit lignes et colonnes
		Boolean[][] board = new Boolean[width][height];
		for( int i = 0; i < height; i++ )
			for( int j = 0; j < width; j++ )
				board[j][i] = tab[height-i-1][j] ;
		
		
		System.out.println( Arrays.toString( 
				new FullRowDetection().detect( board ) 
				) );

	}

}
