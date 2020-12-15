package Anciens;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import org.junit.jupiter.params.provider.NullSource;

import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertAll;
import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.junit.jupiter.api.Assertions.assertEquals;


@DisplayName("Anciens.ListeTest0: Test d'une liste vide")
public class ListeTest0 
{
	ListeTabD<Integer> lib;

	@BeforeEach
    public void setUp()
    {
		//lib = Anciens.ListeFactory.initListe(16);
        lib = new ListeTabD(16);
    }
    
	@Test
	@DisplayName("La liste est vide")
	public void testEstVide()
	{
		assertTrue(lib.estVide());
	}
	
	@Test
    @DisplayName("La liste est de longueur 0")
	public void testLongueur()
	{
		assertEquals(lib.longueur(), 0);
	}
        
	
	
    @DisplayName("On ne peut pas enlever d'élément")
    @ParameterizedTest(name = "Par exemple, enlever({0}) n'est pas permis.")
    @ValueSource(ints = { 0, -1, 1 })
	public void testEnlever(int pos)
	{
	    assertThrows(IndexOutOfBoundsException.class, 
	            () -> lib.enlever(pos));
	}
    
    @DisplayName("On ne peut pas obtenir d'élément")
    @ParameterizedTest(name = "Par exemple, elem({0}) n'est pas permis.")
    @ValueSource(ints = { 0, -1, 1 })
    public void testElem(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.elem(pos));
    }
    
    @DisplayName("On ne peut pas remplacer d'élément")
    @ParameterizedTest(name = "Par exemple, remplacer({0}) n'est pas permis.")
    @ValueSource(ints = { 0, -1, 1 })
    public void testRemplacer(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.remplacer(pos, 0));
    }
    
    @DisplayName("On peut inserer un élément en position 0")
    @ParameterizedTest(name = "Par exemple, inserer(0, {0}).")
    @ValueSource(ints = { 0, 10, -1 })
    @NullSource
    public void testInsererDebut(Integer elem)
    {    
        lib.inserer(0, elem);
        assertAll("insertion en début",
                () -> assertEquals(elem, lib.elem(0)),
                () -> assertEquals(1, lib.longueur())
            );
    }
    
    @DisplayName("On ne peut pas insérer d'élément ailleurs qu'en position 0")
    @ParameterizedTest(name = "Par exemple, inserer({0}, 10) n'est pas permis.")
    @ValueSource(ints = { -1, 1, 2 })
    public void testInserer(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.inserer(pos, 10));
    }
}

