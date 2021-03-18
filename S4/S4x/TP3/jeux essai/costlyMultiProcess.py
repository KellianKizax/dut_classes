#! /usr/bin/python3
# -*- coding: utf8 -*-
import multiprocessing as mp
import time

K = 150

def CostlyFunction(z):
    result = 0
    for k in range(1, K+2):
        result += z ** (1 / k**1.5)
    return result

startTime = time.time()
pool_size = mp.cpu_count() # ici, le nbre de process = le nbre de cpu
pool = mp.Pool(processes=pool_size)
# pool = mp.Pool() # equivalent aux 2 instructions precedentes
                   # par defaut, la taille d'un pool = nbre de cpu

# on lance cent mille operations
asyncResult = pool.map_async(CostlyFunction, range(100000))
resultList = asyncResult.get()	# asyncResult.get() est une liste de valeurs
# get est bloquant (tant que toutes les operations ne sont pas finies)

# print(resultList) # si on veut la liste des resultats
print(time.time() - startTime)

# Temps mis ==========================================
# Janv 2018
# sur troglo 0,7s  !
# sur canette 1,5s

# Fev 2021
# sur machine perso 17 6700hq 1s
