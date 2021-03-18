
;;;; 
;;;; affecter le depart et le but;; 


(defrule Affecter-depart 
    (declare (salience 9000))
    ?A <- (phase init)
    ?D <- (depart (ville ?n) ) 
    (ville (nom ?n) (cout ?c) ) 
    (H (ville ?n) (h ?h))
=> 
    (assert (noeud (nom ?n) (status actif) 
                (h ?h) 
                (g 0)
		        (f ?h)
			)
	)
  	(retract ?A)
  	(assert (phase devol))
  
)


;;;;  
;;  Regles de developpement d'un noeud --> PHASE DEVOL
;; A la fin passer à la PHASE ACTIVATION
;;;;



;;;
;;   Regles permettant de choisir le noeud d'estimation minimale 
;;      et régles d'arret  -->  PHASE ACTIVATION
;;  Si on est au but --> PHASE FINALE   sinon retour en --> PHASE DEVOL
;;;

;;;; 
;;
;;  Affichage des deux listes --> PHASE FINALE  
;;  
;;;;;;


;;;;;;;;;;;;;;;;;;;;  BONUS ;;;;;;;;;;;;;;;;;;;
;;
;;
;;   Regles pour construire et afficher le chemin 
;;
;;
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
