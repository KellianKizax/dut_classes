package Anciens;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.junit.jupiter.api.Assertions.assertThrows;

@DisplayName("ListTest3: Tests d'accès, de suppressions et de remplacements")
public class ListeTest3 
{
    Liste<Integer> lib;
    int n; // n > 0

    @BeforeEach
    public void setUp()
    {
        lib = ListeFactory.initListe(16);
        n = 12;
        for (int i = 0; i < n; i++)
        {
            lib.inserer(lib.longueur(), i * 10);
        }
    }
    
    @Test
    public void testElem()
    {
        for (int i = 0; i < lib.longueur() ; i++)
        {
            assertEquals(i * 10, (int) lib.elem(i));
        }
        
        for (int i = n - 1; i >= 0 ; i--)
        {
            assertEquals(i * 10, (int) lib.elem(i));
        }
        
        for (int i = 0; i < n ; i = i + 2)
        {
            assertEquals(i * 10, (int) lib.elem(i));
        }
        
        for (int i = 0; i < n ; i = i + 3)
        {
            assertEquals(i * 10, (int) lib.elem(i));
        }
        
        for (int i = 0; i < n ; i = i + 5)
        {
            assertEquals(i * 10, (int) lib.elem(i));
        }
    }
	

    @Test
    public void testEnleverDebut()
    {
        int n0 = lib.longueur();
        int val0 = lib.elem(0);
    	lib.enlever(0);
        assertEquals(n0 - 1, lib.longueur());

        for (int i = 0; i < lib.longueur(); i++)
        {
            assertEquals(val0 + 10, (int) lib.elem(i));
            val0 = lib.elem(i);
        }
        
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.elem(n0-1));
    }
    
    @Test
    public void testEnleverToutDebut()
    {
        for (int i = 0; i < n; i++)
        {
            testEnleverDebut();
        }
        assertTrue(lib.estVide());        
    }
    
    @Test
    public void testEnleverMilieu()
    {
        // on enleve tous les pairs
        for (int i = 0; i < lib.longueur(); i++)
        {
            int val = lib.elem(i);
            lib.enlever(i);
            assertEquals(n - i - 1, lib.longueur());
            assertEquals(val + 10, (int) lib.elem(i));
            if (i > 0)
            {
                assertEquals(val - 10, (int) lib.elem(i - 1));
            }
            assertThrows(IndexOutOfBoundsException.class, 
                    () -> lib.elem(lib.longueur()));
        }
        for (int i = 0; i < lib.longueur(); i++)
        {
            assertEquals((2*i+1) * 10, (int) lib.elem(i));
        }
    }
	
    @Test
    public void testEnleverDernier()
    {
        int n = lib.longueur();
        lib.enlever(n-1);
        assertEquals(n-1, lib.longueur());
        
        if (n > 1)
        {
            assertEquals((n-2) * 10, (int) lib.elem(n - 2));
        }
        
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.elem(n-1));
    }
    
    @Test
    public void testEnleverToutDernier()
    {
        for (int i = 0; i < n; i++)
        {
            testEnleverDernier();
        }        
        assertTrue(lib.estVide());        
    }

    @Test	
    public void testRemplacerDebut()
    {
        for (int i = 0; i < n; i++)
        {
        	int val = lib.elem(i);
            lib.remplacer(i, val + 1);
            assertEquals(val + 1, (int) lib.elem(i));
            assertEquals(n, lib.longueur());
        }
        
        for (int i = 0; i < n; i++)
        {
            assertEquals((i * 10) + 1, (int) lib.elem(i));
        }
    }

    @Test
    public void testRemplacerFin()
    {
        for (int i = n - 1; i >= 0 ; i--)
        {
            int val = lib.elem(i);
            lib.remplacer(i, val + 1);
            assertEquals(val + 1, (int) lib.elem(i));
            assertEquals(n, lib.longueur());
        }

        for (int i = n - 1; i >= 0 ; i--)
        {
            assertEquals((i * 10) + 1, (int) lib.elem(i));
        }
    }
	
    @Test
    public void testIndexElem()
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.elem(lib.longueur()));
    }
	
    @Test
    public void testIndexEnlever()
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.enlever(lib.longueur()));
    }
	
    @Test
    public void testIndexRemplacer()
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.remplacer(lib.longueur(), 0));
    }
	
    @Test
    public void testIndexInserer()
    {
        assertThrows(IndexOutOfBoundsException.class, 
                () -> lib.inserer(1 + lib.longueur(), 0));
    }
}
