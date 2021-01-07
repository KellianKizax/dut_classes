from typing import *
import math

# retourne une liste de liste formée de la manière suivante :
# [ [témoins de primalité], [témoins de composition] ]
def test_fermat( n: int):
    res = [[],[]]
    for a in range(1,n):
        p = n-1
        x = math.pow( a, p ) % 15
        if x == 1:
            res[0].append(a)
        else:
            res[1].append(a)
    
    return res

print(test_fermat(15))