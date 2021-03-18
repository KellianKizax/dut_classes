;;;
;;; On complète les slots 
;;;
;;; ATTENTION : Il faut remplacer les ... par le bon slot dans chaque règle
;;;
;;;

(defrule R4.1_CompleterPereDe1
  (membre (nom ?n))
  (pereDe ?pp ?n)
  (not (membre (nom ?pp) (pereDe $? ?n $? )))
  ?f <- (membre (nom ?pp) (pereDe $?fl))
  =>
  (modify ?f (... ?n $?fl))
)


(defrule R4.1_CompleterMereDe1
  (membre (nom ?n))
  (mereDe ?pp ?n)
  (not (membre (nom ?pp) (mereDe $? ?n $? )))
  ?f <- (membre (nom ?pp) (mereDe $?fl))
  =>
  (modify ?f (... ?n $?fl))
)

;;;;;;;;
 
;;;

(defrule R4.1_CompleterAPourFrere1
   (and 
     (membre (nom ?n2) (genre Masculin))
     ?f <- (membre (nom ?n1) (APourFrere $?ls))
     (not (membre (nom ?n1) (APourFrere $?  ?n2 $?))) ;;;  On vérifie que le fait n'existe pas encore
     (or 
        (membre (pereDe $?x ?n1 $?y ?n2 $?z))
        (membre (mereDe $?x ?n1 $?y ?n2 $?z))
        (membre (pereDe $?x ?n2 $?y ?n1 $?z))
        (membre (mereDe $?x ?n2 $?y ?n1 $?z))
        (... ?n1 ?n2)
     )
   )
 =>
  (modify ?f (APourFrere $?ls  ?n2)) ;; On rajoute ?n2 à la liste
)
 
(defrule R4.1_CompleterAPourSoeur1
   (and 
     (membre (nom ?n2) (genre Feminin))
     ?f <- (membre (nom ?n1) (APourSoeur $?ls))
     (not (membre (nom ?n1) (APourSoeur $?  ?n2 $?))) ;;;  On vérifie que le fait n'existe pas encore
     (or 
        (membre (pereDe $?x ?n1 $?y ?n2 $?z))
        (membre (mereDe $?x ?n1 $?y ?n2 $?z))
        (membre (pereDe $?x ?n2 $?y ?n1 $?z))
        (membre (mereDe $?x ?n2 $?y ?n1 $?z))
        (APourSoeur ?n1 ?n2)
     )
   )
 =>
  (modify ?f (... $?ls  ?n2))  On rajoute ?n2 à la liste
)


