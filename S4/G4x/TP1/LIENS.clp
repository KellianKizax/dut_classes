
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; 
;; Liste des faits 
;;
;;  Sémantiquement" Un fait (Rel A B) peut se traduire pas : A Rel B
;;
;; Exemple : (genre Alain Masculin) ==> Alain genre Masculin
;; Exemple :  (mereDe Nina Maya) ==> Nina mereDe Maya
;; Exemple :  (APourSoeur  Ariane Anne ) ==> Ariane APourSoeur Anne
;;
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

(deffacts Liens
;; (genre Alain Masculin)
 (mereDe Nina Maya)
 (epouseDe Michele Marc) 
 (nom Paule)
;; (genre Maya Feminin )
 (mereDe Maya Piotr)
 (APourFrere Alain Albert)
 (pereDe  Alain  Monique)
 (pereDe Alain  Marc)
 (famille Alain  Dit)
 (famille Albert  Dit)
 (APourSoeur Anne Ariane )
 (mereDe Ariane Bradley)
 (epouxDe Andre  Anne )
 (pereDe Andre Oscar)
 (pereDe Andre Nina)
 (famille Ariane Cink)
 (pereDe Lucas Louis  )
 (mereDe Monique Pascale )
 (mereDe Ariane Lucas)
 (epouseDe Louise Oscar  )
;; (genre Andre Masculin)
 (famille Andre  Santoké)
 (epouxDe Bradley Nina  )
 (epouxDe Louis Pascale)
 (famille Anne  Aloogy)
 (mereDe Nina Michele)
 (pereDe Alphonse Alain)
 (mereDe  Nina Monique)
 (mereDe Michele Paule )
 (pereDe Alain  Louise)
)

(deffacts listeNoms
  (listeNomsMasculins Andre Antoine Oscar Lucas Paul Bradley Piotr Louis Pascal Patrick Alain Marc Albert Alphonse)
  (listeNomsFeminins Aurore Zoe Monique Louise Anne Ariane Nina Pascale Michele Louise Nina Monique Maya Paule Pia)
)

(deftemplate membre
  (slot nom (type STRING) (default ’’NoName ’’)) ;; Personne
  (slot genre (default nil) (allowed-values Masculin Feminin));; Son genre
  (slot nomFamille (default nil))
  ;; Son nom de famille
  (multislot pereDe)
  ;; Liste de ses enfants
  (multislot mereDe)
  ;; Liste de ses enfants
  (slot epouxDe (default nil))
  ;; Nom de son épouse
  (slot epouseDe (default nil))
  ;; Nom de son époux
  (multislot APourFrere)
  ;; Liste des personnes dont elle est frère
  (multislot APourSoeur) ;; Liste des personnes dont elle est soeur
)