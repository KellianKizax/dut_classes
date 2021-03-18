#! /usr/bin/python3
# -*- coding: utf8 -*-
# version de CostlyFunction sans thread

import time
 
K = 150
 
def CostlyFunction(z):
    result = 0
    for k in range(1, K+2):
        result += z ** (1 / k**1.5)
    return result

# timer
startTime = time.time()
resultList = []
 
for i in range(100000) :	# on lance cent mille fois la fonction CostlyFunction
	resultat = CostlyFunction(i)
	resultList.append(resultat)	# on ajoute le resultat a la liste

# print(resultList) # si on veut la liste des resultats
 
print(time.time() - startTime)

# Temps mis ==========================================
# Janv 2018
# sur troglo 7s
# sur canette 11s

# Fev 2021
# ordi perso i7 6700hq 3.57s
