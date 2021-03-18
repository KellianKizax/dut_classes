;; EXERCICE 2

;; Assertion des faits réciproques à EpouxDe et EpouseDe
(defrule R2.1_EpouseDe
    (epouxDe ?n ?x)
    (not (epouseDe ?x ?n))
=>
    (assert (epouseDe ?x ?n))
)

(defrule R2.1_EpouxDe
    (epouseDe ?n ?x)
    (not (epouxDe ?x ?n))
=>
    (assert (epouxDe ?x ?n))
)


;; Assertion des faits (nom ...) pour toutes les personnes apparaissant
;;      dans au moins un fait initial (sauf liste de noms)

(defrule R2.3_creerNom
    (or
        (famille ?n ?)
  	    (pereDe ?n ?) 
  	    (mereDe  ?n ?)
  	    (genre ?n ?)
  	    (epouxDe ?n ?)
  	    (epouseDe ?n ?)
  	    (APourFrere ?n ?)
  	    (APourSoeur ?n ?)
  	    (pereDe ? ?n)
  	    (mereDe ? ?n)
  	    (epouxDe ? ?n)
  	    (epouseDe ? ?n)
  	    (APourFrere ? ?n)
  	    (APourSoeur ? ?n)
    )
    (not (nom ?n))
=>
    (assert (nom ?n))
)


;;;;;;;;;;;;;;;;;;;;;;
;;
;; Creer les genre à partir des faits de base
;;
;;;;;;;;;;;;;;;;;;;;;

(defrule R2.4_GenreMasculin
    (nom ?n)
    (not (genre ?n ?))
    (listeNomsMasculins $? ?n $?)
=>
    (assert (genre ?n Masculin))
)

(defrule R2.3_GenreFeminin
    (nom ?n)
    (not (genre ?n ?))
    (listeNomsFeminins $? ?n $?)
=>
    (assert (genre ?n Feminin))
)
 
;;;;;;;;;;;;;;;
;;;
;;;  Creer les APourFrère et APourSoeur (Facultatif) 
;;;
;;;;;;;;;;;;;
 


(defrule R2.2_APourFrere
    (and 
        (genre ?n Masculin)
        (or (APourFrere ?n ?X)
 	        (APourSoeur ?n ?X)
        )
        (not (APourFrere ?X ?n))
    )
=>
    (assert (APourFrere ?X ?n))
)

(defrule R2.4_APourSoeur
    (and 
        (genre ?n Feminin)
        (or
            (APourFrere ?n ?X)
            (APourSoeur ?n ?X)
        )  
        (not
            (APourSoeur ?X ?n)
        )
    )
=>
    (assert (APourSoeur ?X ?n))
)


;;;;;;;;;
;;
;;  Exercice 3
;;
;;;;;;;;;

(defrule R3.2_GenererMembre
    ?f <- (nom ?n)
    (not (membre (nom ?n) ))
=>
    (assert (membre (nom ?n) ))
)

(defrule R3.3_CompleterNomFamille
    ?f <- (membre (nom ?n) (nomFamille nil))
    ?g <- (famille ?n ?fam)
        (not (membre (nom ?n) (nomFamille ?fam) ))
=>
    (modify ?f (nomFamille ?fam))
)

;;;;;;;;;
;;
;;  Question 4
;;
;;;;;;;;;

(defrule R4.1   ;;; LISTE DES ENFANTS POUR UN PERE
    (membre (nom ?n))   ; Un membre qui a pour nom ?n
    (pereDe ?pp ?n)     ; le père ?pp de ?n
    (not (membre (nom ?pp)(pereDe $? ?n $?)) )      ;
    ?f <- (membre (nom ?pp)(pereDe $?fl) )
=>
    (modify ?f (... ?n $?fl))
)

(defrule R4.1_b ;;; CREE LES FRATRIES
    (and
        (membre (nom ?n2)(genre Masculin))
    ?f <- (membre (nom ?n1) )
        (not (membre (nom ?n1)(APourFrere $? ?n2 $2)))
        (or
        
        )
    )
    =>
        (modify ?f(APourFrere $?ls ?n2)) ;; On rajoute ?n2 à la liste
)
