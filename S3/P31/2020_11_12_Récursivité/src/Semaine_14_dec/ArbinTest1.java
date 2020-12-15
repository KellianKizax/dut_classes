package Semaine_14_dec;

import static org.junit.jupiter.api.Assertions.*;

import Semaine_30_nov.Arbin;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Nested;
import org.junit.jupiter.api.Test;

@DisplayName("ArbinTest1: Tests d'arbres binaires simples (1, 2, 3 noeuds)")
public class ArbinTest1
{
    private static Arbin<Integer> proto = ArbinFactory.<Integer>getInstance();
    private static Arbin<Integer> a;
    private static final int val = 1;
        
    @DisplayName("Test d'un arbre binaire feuille (1 noeud)")
    @Nested
    public class ArbinTest_1
    {        
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(val);
        }

        @Test
        @DisplayName("L'arbre binaire n'est pas vide")
        public void testEstVide()
        {
            assertFalse(a.estVide());
        }
        
        @Test
        @DisplayName("Le sous-arbre gauche est vide")
        public void testAg()
        {
            assertTrue(a.ag().estVide());
        }

        @Test
        @DisplayName("Le sous-arbre droit est vide")
        public void testAd()
        {
            assertTrue(a.ad().estVide());
        }
                
        @Test
        @DisplayName("La racine de l'arbre est valide")
        public void testRacine()
        {
            assertEquals(java.util.Optional.of(val), a.racine());
        }
        
        @Test
        @DisplayName("Le nombre de noeuds est 1")
        public void testTaille()
        {
            assertEquals(1, a.taille());
        }

        @Test
        @DisplayName("Le nombre de feuilles de l'arbre binaire est 1")
        public void testNbFeuilles()
        {
            assertEquals(1, a.nbFeuilles());
        }
                
        @Test
        @DisplayName("L'arbre binaire est filiforme")
        public void testEstFiliforme()
        {
            assertTrue(a.estFiliforme());
        }
        
        @Test
        @DisplayName("L'arbre binaire est homogène")
        public void testEstHomogene()
        {
            assertTrue(a.estHomogene());
        }
        
        @Test
        @DisplayName("L'arbre binaire est équilibré")
        public void testEstEquilibre()
        {
            assertTrue(a.estEquilibre());
        }
        
        @Test
        @DisplayName("L'arbre binaire est complet")
        public void testEstComplet()
        {
            assertTrue(a.estComplet());
        }
        
        @Test
        @DisplayName("L'arbre binaire est parfait")
        public void testEstParfait()
        {
            assertTrue(a.estParfait());
        }
                
        @Test
        @DisplayName("La profondeur de l'arbre binaire est 1")
        public void testProfondeur()
        {
            assertEquals(1, a.profondeur());
        }

    }
    
    @DisplayName("Test d'un arbre binaire de 2 noeuds avec ad vide")
    @Nested
    public class ArbinTest2g extends ArbinTest_1
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(
                    val,
                    proto.initArbin(val),
                    proto.initArbin());
        }
        
        @Test
        @DisplayName("Le nombre de noeuds est 2")
        public void testTaille()
        {
            assertEquals(2, a.taille());
        }
        
        @Test
        @DisplayName("La profondeur de l'arbre binaire est 2")
        public void testProfondeur()
        {
            assertEquals(2, a.profondeur());
        }
        
        @Test
        @DisplayName("Le sous-arbre gauche n'est pas vide")
        public void testAg()
        {
            assertFalse(a.ag().estVide());
            assertEquals(java.util.Optional.of(val), a.ag().racine());
        }
        
        @Test
        @DisplayName("L'arbre binaire n'est pas homogène")
        public void testEstHomogene()
        {
            assertFalse(a.estHomogene());
        }

        @Test
        @DisplayName("L'arbre binaire n'est pas complet")
        public void testEstComplet()
        {
            assertFalse(a.estComplet());
        }
    }
    
    @DisplayName("Test d'un arbre binaire de 2 noeuds avec ag vide")
    @Nested
    public class ArbinTest2d extends ArbinTest2g
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(
                    val,
                    proto.initArbin(),
                    proto.initArbin(val));
        }
        
        @Test
        @DisplayName("Le sous-arbre gauche est vide")
        public void testAg()
        {
            assertTrue(a.ag().estVide());
        }
        
        @Test
        @DisplayName("Le sous-arbre droit n'est pas vide")
        public void testAd()
        {
            assertFalse(a.ad().estVide());
            assertEquals(java.util.Optional.of(val), a.ad().racine());
        }
        
        @Test
        @DisplayName("L'arbre binaire n'est pas parfait")
        public void testEstParfait()
        {
            assertFalse(a.estParfait());
        }
    }
    
    @DisplayName("Test d'un arbre binaire de 3 noeuds (/)")
    @Nested
    public class ArbinTest3a extends ArbinTest2g
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(val,
                    proto.initArbin(val,
                        proto.initArbin(val),
                        proto.initArbin()),
                    proto.initArbin());
        }
        @Test
        @DisplayName("Le nombre de noeuds est 3")
        public void testTaille()
        {
            assertEquals(3, a.taille());
        }
        
        @Test
        @DisplayName("La profondeur de l'arbre binaire est 3")
        public void testProfondeur()
        {
            assertEquals(3, a.profondeur());
        }
        
        @Test
        @DisplayName("L'arbre binaire n'est pas équilibré")
        public void testEstEquilibre()
        {
            assertFalse(a.estEquilibre());
        }
        
        @Test
        @DisplayName("L'arbre binaire n'est pas parfait")
        public void testEstParfait()
        {
            assertFalse(a.estParfait());
        }
        
    }
    
    @DisplayName("Test d'un arbre binaire de 3 noeuds (<)")
    @Nested
    public class ArbinTest3b extends ArbinTest3a
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(val,
                    proto.initArbin(val,
                        proto.initArbin(),
                        proto.initArbin(val)),
                    proto.initArbin());
        }
    }
    
    @DisplayName("Test d'un arbre binaire de 3 noeuds (>)")
    @Nested
    public class ArbinTest3c extends ArbinTest3a
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(val,
                    proto.initArbin(),
                    proto.initArbin(val,
                        proto.initArbin(val),
                        proto.initArbin())
                    );
        }
        
        @Test
        @DisplayName("Le sous-arbre gauche est vide")
        public void testAg()
        {
            assertTrue(a.ag().estVide());
        }
        
        @Test
        @DisplayName("Le sous-arbre droit n'est pas vide")
        public void testAd()
        {
            assertFalse(a.ad().estVide());
            assertEquals(java.util.Optional.of(val), a.ad().racine());
        }

    }
    @DisplayName("Test d'un arbre binaire de 3 noeuds (\\)")
    @Nested
    public class ArbinTest3d extends ArbinTest3c
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(val,
                    proto.initArbin(),
                    proto.initArbin(val,
                        proto.initArbin(),
                        proto.initArbin(val))
                    );
        }
    }
    
    @DisplayName("Test d'un arbre binaire de 3 noeuds complet(/\\)")
    @Nested
    public class ArbinTest3e extends ArbinTest_1
    {
        @BeforeEach
        public void setUp() 
        {
            a = proto.initArbin(val,
                    proto.initArbin(val),
                    proto.initArbin(val)
                    );
        }
        @Test
        @DisplayName("Le nombre de noeuds est 3")
        public void testTaille()
        {
            assertEquals(3, a.taille());
        }
        
        @Test
        @DisplayName("La profondeur de l'arbre binaire est 2")
        public void testProfondeur()
        {
            assertEquals(2, a.profondeur());
        }
        
        @Test
        @DisplayName("Le nombre de feuilles de l'arbre binaire est 2")
        public void testNbFeuilles()
        {
            assertEquals(2, a.nbFeuilles());
        }
                
        @Test
        @DisplayName("L'arbre binaire n'est pas filiforme")
        public void testEstFiliforme()
        {
            assertFalse(a.estFiliforme());
        }
        
        @Test
        @DisplayName("Le sous-arbre gauche n'est pas vide")
        public void testAg()
        {
            assertFalse(a.ag().estVide());
            assertEquals(java.util.Optional.of(val), a.ag().racine());
        }
        
        @Test
        @DisplayName("Le sous-arbre droit n'est pas vide")
        public void testAd()
        {
            assertFalse(a.ad().estVide());
            assertEquals(java.util.Optional.of(val), a.ad().racine());
        }

    }
}
