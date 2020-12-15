package Anciens;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

@DisplayName("Anciens.ListeTest2: Test d'insertions de séquence")
public class ListeTest2
{
    static final int N = 100;
    
    Liste<Integer> lib;
    
    @BeforeEach
    public void setUp()
    {
        lib = ListeFactory.initListe(N);
    }
    
    @DisplayName("insertions en fin")
    @ParameterizedTest(name = "Par exemple, {0} éléments sont insérés.")
    @ValueSource(ints = { N/2, N, 2*N })
    public void testInsererSequenceFin(int n)
    {
        for (int elem = 1; elem <= n; elem++)
        {
            int fin = lib.longueur();
            lib.inserer(fin, elem);
            assertEquals(elem, (int) lib.elem(fin));
            assertEquals(elem, lib.longueur());
        }
        
        verifSequence(n);
    }
    
    private void verifSequence(int n)
    {
        assertEquals(n , lib.longueur());
        for (int i = 0; i < n ; i++)
        {
            assertEquals(i+1, (int) lib.elem(i));
        }
        
        assertEquals(n, lib.longueur());
        for (int i = n - 1; i >= 0 ; i--)
        {
            assertEquals(i+1, (int) lib.elem(i));
        }
        assertEquals(n, lib.longueur());        
    }
    

    
    @DisplayName("insertions au début")
    @ParameterizedTest(name = "Par exemple, {0} éléments sont insérés.")
    @ValueSource(ints = { N/2, N, 2*N })
    public void testInsererSequenceDebut(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            int elem = n+1 - i;
            lib.inserer(0, elem);

            assertEquals(elem, (int) lib.elem(0));
            assertEquals(i, lib.longueur());
        }
        
        verifSequence(n);
    }
    
    @DisplayName("insertions au milieu")
    @ParameterizedTest(name = "Par exemple, {0} éléments sont insérés.")
    @ValueSource(ints = { N/2, N, 2*N })
    public void testInsererSequenceMilieu(int n)
    {
        for (int elem = 1; elem <= n; elem = elem + 2)
        {
            int pos = elem/2;
            lib.inserer(pos, elem);
            assertEquals(elem, (int) lib.elem(pos));
        }
        
        for (int elem = 2; elem <= n; elem = elem + 2)
        {
            int pos = elem-1;
            lib.inserer(pos, elem);
            assertEquals(elem, (int) lib.elem(pos));
        }
        
        verifSequence(n);
    }

}
