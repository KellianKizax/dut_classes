package Anciens;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import org.junit.jupiter.params.provider.NullSource;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertAll;
import static org.junit.jupiter.api.Assertions.assertTrue;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertEquals;


@DisplayName("Anciens.ListeTest1: Test d'une liste avec 1 élément")
public class ListeTest1
{
	ListeTabD<Integer> lib;
	int elem;
	
	@BeforeEach
    public void setUp()
    {
		elem = 10;
		lib = new ListeTabD(16);
        lib.inserer(0, elem);
    }
    
	@Test
    @DisplayName("La liste n'est pas vide")
	public void testEstVide()
	{
		assertFalse(lib.estVide());
	}
	
	@Test
    @DisplayName("La liste est de longueur 1")
	public void testLongueur()
	{
		assertEquals(1, lib.longueur());
	}    
	
	@Test
    @DisplayName("On peut enlever l'élément de position 0")
    public void testEnlever()
    {
		lib.enlever(0);
	    assertAll("enlever(0)",
	                () -> assertTrue(lib.estVide()),
	                () -> assertEquals(0, lib.longueur()),
	                () -> assertThrows(IndexOutOfBoundsException.class,
	                        () -> lib.elem(0)));      
    }
	    
	@Test
    @DisplayName("On peut obtenir l'élément de position 0")
	public void testElem()
	{
		int elem0 = lib.elem(0);
	    assertAll("elem(0)",
	            () -> assertEquals(elem, elem0),
	            () -> assertFalse(lib.estVide()),
	            () -> assertEquals(1, lib.longueur()));
	}
	
    @DisplayName("On peut remplacer l'élément de position 0")
    @ParameterizedTest(name = "Par exemple, remplacer(0, {0}).")
    @ValueSource(ints = { 0, 20, -1 })
    @NullSource
	public void testRemplacer(Integer val)
	{
		lib.remplacer(0, val);
	    assertAll("remplacer(0)",
                () -> assertFalse(lib.estVide()),
                () -> assertEquals(1, lib.longueur()),
                () -> assertEquals(val, lib.elem(0)));
	}
	
    @DisplayName("On ne peut pas enlever d'élément ailleurs qu'en 0")
    @ParameterizedTest(name = "Par exemple, enlever({0}) n'est pas permis.")
    @ValueSource(ints = { -1, 1, 2 })
    public void testEnlever(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.enlever(pos));
    }
    
    @DisplayName("On ne peut pas obtenir d'élément ailleurs qu'en 0")
    @ParameterizedTest(name = "Par exemple, elem({0}) n'est pas permis.")
    @ValueSource(ints = { -1, 1, 3 })
    public void testElem(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.elem(pos));
    }
	
    @DisplayName("On ne peut pas remplacer d'élément ailleurs qu'en 0")
    @ParameterizedTest(name = "Par exemple, remplacer({0}) n'est pas permis.")
    @ValueSource(ints = { -1, 1, 2 })
    public void testRemplacer(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.remplacer(pos, 0));
    }
    
    @DisplayName("On peut inserer un élément en position 0 ou 1")
    @ParameterizedTest(name = "Par exemple, inserer({0}, {1}).")
    @CsvSource(value = {
                "0, 10",
                "1, 10",
                "0, ", // 0, null
                "1, "  // 1, null
            })
    public void testInserer(int pos, Integer elem)
    {   
        Integer elem0 = lib.elem(0);
        lib.inserer(pos, elem);
        assertAll("insertion en début",
                () -> assertEquals(elem, lib.elem(pos)),
                () -> assertEquals(2, lib.longueur()),
                () -> assertEquals(elem0, lib.elem((pos+1)%2))
            );
    }
    
    @DisplayName("On ne peut pas insérer d'élément ailleurs qu'en position 0 et 1")
    @ParameterizedTest(name = "Par exemple, inserer({0}, 10) n'est pas permis.")
    @ValueSource(ints = { -1, 2, 3 })
    public void testInserer(int pos)
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.inserer(pos, 10));
    }

}
