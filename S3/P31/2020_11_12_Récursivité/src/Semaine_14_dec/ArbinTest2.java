package Semaine_14_dec;

import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertEquals;

import Semaine_30_nov.Arbin;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;

@DisplayName("ArbinTest2: Test d'un petit arbre binaire et de ses sous-arbres.")
public class ArbinTest2 
{
    Arbin<Integer> a0;
    Arbin<Integer> a1;
    Arbin<Integer> a2;
    Arbin<Integer> a3;
    Arbin<Integer> a4;
   
    @BeforeEach
    public void setUp() 
    {
        a0 = ArbinFactory.getInstance();
        a1 = a0.initArbin(6);
        a2 = a0.initArbin(8, a1, a0);
        a3 = a0.initArbin(13);
        a4 = a0.initArbin(12, a2, a3);
    }
    
    @Test
    @DisplayName("Les arbres binaires ne sont pas vides.")
    public void testEstVide()
    {
        assertTrue(a0.estVide());
        assertFalse(a1.estVide());
        assertFalse(a2.estVide());
        assertFalse(a3.estVide());
        assertFalse(a4.estVide());
    }
    
    @Test
    @DisplayName("Les arbres gauches sont valides.")
    public void testAg()
    {
        assertEquals(a1.ag(), a0);
        assertEquals(a2.ag(), a1);
        assertEquals(a3.ag(), a0);
        assertEquals(a4.ag(), a2);
    }
    
    @Test
    @DisplayName("Les arbres droits sont valides.")
    public void testAd()
    {
        assertEquals(a1.ag(), a0);
        assertEquals(a2.ad(), a0);
        assertEquals(a3.ag(), a0);
        assertEquals(a4.ad(), a3);
    }
    
    @Test
    @DisplayName("Les racines sont valides.")
    public void testRacine()
    {
        assertEquals(java.util.Optional.of(6), a1.racine());
        assertEquals(java.util.Optional.of(8), a2.racine());
        assertEquals(java.util.Optional.of(13), a3.racine());
        assertEquals(java.util.Optional.of(12), a4.racine());
    }
    
    @Test
    @DisplayName("Les tailles sont valides.")
    public void testTaille()
    {
        assertEquals(1, a1.taille());
        assertEquals(2, a2.taille());
        assertEquals(1, a3.taille());
        assertEquals(4, a4.taille());
    }
    
    @Test
    @DisplayName("Les profondeurs sont valides.")
    public void testProfondeur()
    {
        assertEquals(1, a1.profondeur());
        assertEquals(2, a2.profondeur());
        assertEquals(1, a3.profondeur());
        assertEquals(3, a4.profondeur());
    }
    
    @Test
    @DisplayName("Les nombres de feuilles sont valides.")
    public void testNbFeuilles()
    {
        assertEquals(1, a1.nbFeuilles());
        assertEquals(1, a2.nbFeuilles());
        assertEquals(1, a3.nbFeuilles());
        assertEquals(2, a4.nbFeuilles());
    }
    
    @Test
    @DisplayName("La propriété filiforme est valide.")
    public void testEstFiliforme()
    {
        assertTrue(a1.estFiliforme());
        assertTrue(a2.estFiliforme());
        assertTrue(a3.estFiliforme());
        assertFalse(a4.estFiliforme());
    }
    
    @Test
    @DisplayName("La propriété homogène est valide.")
    public void testEstHomogene()
    {
        assertTrue(a1.estHomogene());
        assertFalse(a2.estHomogene());
        assertTrue(a3.estHomogene());
        assertFalse(a4.estHomogene());
    }
    
    @Test
    @DisplayName("La propriété équilibré est valide.")
    public void testEstEquilibre()
    {
        assertTrue(a1.estEquilibre());
        assertTrue(a2.estEquilibre());
        assertTrue(a3.estEquilibre());
        assertTrue(a4.estEquilibre());
    }
    
    @Test
    @DisplayName("La propriété complet est valide.")
    public void testEstComplet()
    {
        assertTrue(a1.estComplet());
        assertFalse(a2.estComplet());
        assertTrue(a3.estComplet());
        assertFalse(a4.estComplet());
    }
    
	@Test
    @DisplayName("La propriété parfait est valide.")
    public void testEstParfait()
    {
        assertTrue(a1.estParfait());
        assertTrue(a2.estParfait());
        assertTrue(a3.estParfait());
        assertTrue(a4.estParfait());
    } 
}
