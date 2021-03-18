
(deftemplate but
    (slot ville (type SYMBOL) (default NIL))
)
(deftemplate depart
    (slot ville (type SYMBOL) (default NIL))
 )

(deftemplate noeud
    (slot nom (type SYMBOL) (default NIL))
    (slot status )
    (slot pere)
    (slot f (type NUMBER))
    (slot g (type NUMBER) (default 0))
    (slot h (type NUMBER))
 )


(deffacts init
    ;; l'origine 
    (depart (ville V0) )   
    ;; le but
    (but (ville V17))
    ;; 
    (phase init)
)
