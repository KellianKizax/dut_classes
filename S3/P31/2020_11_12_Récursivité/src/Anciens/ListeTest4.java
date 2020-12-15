package Anciens;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.DynamicTest;
import org.junit.jupiter.api.TestFactory;

import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.DynamicTest.dynamicTest;

import java.util.stream.IntStream;
import java.util.stream.Stream;

@DisplayName("Anciens.ListeTest4: Test d'égalité de listes")
public class ListeTest4 
{
    static final int N = 100;
	Liste<String> f;
    Liste<String> g;
    Liste<String> vide1;
    Liste<String> vide2;
    
	@BeforeEach
    public void setUp()
    {
		f = ListeFactory.initListe(N);
        g = ListeFactory.initListe(N/2);
        vide1 = ListeFactory.initListe(0);
        vide2 = ListeFactory.initListe(0);
		
		for (int i = 0; i < N/4; i++)
		{
		    String elem = "" + i;
			f.inserer(f.longueur(), elem);
			g.inserer(g.longueur(), "" + elem);
		}
    }
	
    @Test
    @DisplayName("test de l'identité")
    public void testIdentite()
    {
        assertTrue(f.equals(f));
    }
    
    @Test
    @DisplayName("test égalité entre listes vides")
    public void testEgaliteVide()
    {
        assertTrue(vide1.equals(vide2));
    }

	
    @Test
    @DisplayName("test égalité avec deux listes égales")
    public void testEgalite()
    {
		assertTrue(f.equals(g));
        assertTrue(g.equals(f));
    }
    
    @TestFactory
    @DisplayName("tests d'égalité après suppression puis insertion")
    Stream<DynamicTest> testEgaliteInsSup() {
        return IntStream.range(0, f.longueur())
            .mapToObj(n -> dynamicTest("suppression en " + n, 
                    () -> {
                        String elem = f.elem(n);
                        f.enlever(n);
                        assertFalse(f.equals(g));
                        f.inserer(n, elem);
                        assertTrue(f.equals(g));                        
                    }));
    }
		
	public static <T> void permuter(Liste<T> f, int n)
	{
		int lg = f.longueur();
		if (lg >= 2)
		{
			n = n % lg;
			if (n < 0)
			{
				n = n + lg;
			}			
			for (int i = 0; i < n ; i++)
			{
				T tete = f.elem(0);
				f.enlever(0);
				f.inserer(f.longueur(), tete);
			}
		}
	}
	
    @TestFactory
    @DisplayName("test d'égalité après permutation")
    Stream<DynamicTest> testEgalitePerm1() {
        return IntStream.range(1, f.longueur())
            .mapToObj(n -> dynamicTest("permutation de " + n, 
                    () -> {
                        permuter(f, n);
                        assertFalse(f.equals(g));
                        permuter(f, f.longueur()-n);
                        assertTrue(f.equals(g));
                    }));
    }

    @TestFactory
    @DisplayName("test d'égalité après permutation des 2 listes")
    Stream<DynamicTest> testEgalitePerm2() {
        return IntStream.range(1, f.longueur())
            .mapToObj(n -> dynamicTest("permutation de " + n, 
                    () -> {
                        permuter(f, n);
                        assertFalse(f.equals(g));
                        permuter(g, n);
                        assertTrue(f.equals(g));
                    }));
    }
    
    @Test
    @DisplayName("test d'égalité après suppressions")
    public void testSuppression()
    {
        while (!f.estVide())
        {
            f.enlever(0);
            assertFalse(f.equals(g));
            g.enlever(0);
            assertTrue(f.equals(g));
        }
        assertTrue(g.estVide());
    }
	/**/
    @Test
    @DisplayName("test inégalité avec null")
    public void testInegaliteNull()
    {
        assertFalse(f.equals(null));
    }

    @Test
    @DisplayName("test inégalité avec String")
    public void testInegaliteString()
    {
        assertFalse(f.equals(""));
    }

    @Test
    @DisplayName("test inégalité avec liste vide")
    public void testInegaliteVide()
    {
        assertFalse(f.equals(vide1));
        assertFalse(vide1.equals(f));
    }
    
    @Test
    @DisplayName("test égalité avec liste contenant null")
    public void testEgaliteAvecNull()
    {
        vide1.inserer(0, null);
        vide2.inserer(0, null);
        assertTrue(vide1.equals(vide2));
        assertTrue(vide2.equals(vide1));
    }
    
    @Test
    @DisplayName("test inégalité avec liste contenant null")
    public void testInegaliteAvecNull()
    {
        vide1.inserer(0, null);
        vide2.inserer(0, "");
        assertFalse(vide1.equals(vide2));
        assertFalse(vide2.equals(vide1));
    }
}
