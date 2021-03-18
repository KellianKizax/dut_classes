
;;;;  
;;  Regles de developpement d'un noeud
;;;;

(defrule Genere-voisins
    (declare (salience 300))
    (phase devol)  
  	(noeud (nom ?p)  (status actif)  (g ?g))
	;; on prend une ville dans la liste de ses voisins
  	(ville (nom ?p) (cout ?c) (voisins $? ?v $?))
	;; on cherche son estimation
  	(H (ville ?v) (h ?h))
	;; et sa distance
  	(VtoV (ville1 ?p) (ville2 ?v) (dist ?d))
=> 
  	(assert (noeud (nom ?v) (status open) (pere ?p)
				(g =(+ ?c (+ ?g ?d)))
				(h ?h)
				(f =(+ (+ ?c (+ ?g ?d)) ?h))
			)
	)
)


;;;; regle pour fermer le noeud actif ;; 

(defrule fermer-noeud  
  	(declare (salience 200))
  	?P <- (phase devol)
  	?N <- (noeud (status actif)) 
=> 
  	(modify ?N (status closed))
	(retract ?P)
	(assert (phase activation)) 
)


;;;; Regle pour chercher les noeuds doublons et fermer celui avec l'estimation la plus grande

(defrule RechercheDoublons
	(declare (salience 290))
	(phase devol)
	?N1 <- (noeud (nom ?v) (f ?f1) )
	?N2 <- (noeud (nom ?v) (f ?f2 &:(< ?f2 ?f1)) ) ;; on enregistre f2 que si f2 est < a f1
=>
	(retract ?N1)	;; on supprime N1 car un autre noeud existe d'estimation inferieure
)

(defrule RechercheNoeudMin
	(declare (salience 100))
	(phase activation)
	?N <- (noeud (status open) (f ?f))
	(not (noeud (status open) (f ?ff &:(> ?f ?ff))))  ;; cherche si un noeud est plus petit que l'actuel (si oui, le premier n'est pas le plus petit)
	(not (noeud (status actif)))
=>
	(modify ?N (status actif))
)
