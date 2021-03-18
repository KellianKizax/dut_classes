
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
