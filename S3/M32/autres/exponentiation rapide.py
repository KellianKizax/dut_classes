def expoRapide( nombre: int, puissance: int, modulo: int ) -> int:
    res = nombre
    p = puissance
    paire = (puissance%2 == 0)
    
    while p > 0:
        if p > 1:
            res = (res * res) %modulo
            p = int( p/2 )
        
        elif (not p > 1) & (paire == False):
            res = (res * nombre) %modulo
            p -= 1

        else:
            p -= 1


    return res

# essai de l'algo
"""
print( expoRapide( 3, 4, 100) )
print( expoRapide( 3, 8, 100) )
print( expoRapide( 3, 16, 100) )
print( expoRapide( 3, 32, 100) )
print( expoRapide( 3, 42, 100) )
"""
""" exo7
print(expoRapide( 3, 16, 100 )) #21
print( expoRapide( 3, 17, 100) ) #63
print( expoRapide( 3, 33, 100) ) #23
"""
