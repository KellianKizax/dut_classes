#! /usr/bin/python3
# -*- coding: utf8 -*-
import threading
import time

K = 150

class CostlyThread(threading.Thread):

    def __init__(self, value):
        threading.Thread.__init__(self)
        self.value = value

    def run(self):
        result = 0
        z = self.value
        for k in range(1, K+2):
            result += z ** (1 / k**1.5)
        self.value = result

# timer
startTime = time.time()

threadList = []

for i in range(100000) :	# on lance cent mille threads
    curThread = CostlyThread(i)
    curThread.start()	# on lance le thread
    threadList.append(curThread)  # on ajoute le thread à la liste

# maintenant qu'on a tout lancé, on récupère tout!
resultList = []

for curThread in threadList :
    curThread.join()	# on attend que le thread a fini
    result = curThread.value	# on récupère sa valeur
    resultList.append(result)

# print(resultList)  # si on veut la liste des résultats

print(time.time() - startTime)

# Temps mis ==========================================
# Janv 2018
# sur troglo 20s
# sur canette 1 mn !

# Fev 2021
# sur machine perso i7 6700hq 20s
