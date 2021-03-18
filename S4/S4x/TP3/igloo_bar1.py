#!/usr/bin/python3
# -*- coding: utf8 -*-

# author: Kellian GOFFIC        17/02/2021
# usage: ./igloo_bar1.py
# ===============================================
# Contrainte: Nbre de clients en train de
# consommer <= nbre de sièges dans le bar
# ===============================================

# Section des imports
from queue import Queue
from random import uniform
from threading import Thread, Semaphore, BoundedSemaphore
from time import sleep

# __ var. globales __
# nb : Seats doit être connu avant de pouvoir
#       initialiser la variable de classe
#       <enter_multiplex>

DefSeatsValue = 5 # valeur par défaut

try:
    Seats = input("Nbre de places ? (5 par défaut: taper Entree) ")
    if Seats == "":
        Seats = DefSeatsValue
    else:
        Seats = int(Seats)
    
    Nb_clients = int(input("Nbre de clients ? "))
    assert(Seats > 0)
    assert(Nb_clients > 0)
except ValueError: # si la conversion en 'int' echoue
    print("Nombre entier requis !")
    exit(1)
except AssertionError:
    print("Nbre (places et clients) positif requis !")
    exit(1)


class Client(Thread):
    # variables de classe partagées par tous les threads
    drinking = 0
    drink_mutex = Semaphore(1) # pour proteger les maj de 'drinking'
    enter_multiplex = BoundedSemaphore(Seats)

    def __init__(self, id, fifo):
        super().__init__() # Thread.__init__()
        self._id = id
        self._fifo = fifo
    
    def run(self):
        self.to_arrive() # pour espacer les arrivées

        Client.enter_multiplex.acquire() # "zone" ou il ne doit pas y avoir plus de
                                         # <SEATS> consommateurs
        Client.drink_mutex.acquire()
        Client.drinking += 1
        state = "s'installe (et boit)"
        item = "client {0:3d} {2:30s} compteur = {1:d}".format(self._id,Client.drinking,state)
        self._fifo.put(item)
        Client.drink_mutex.release()

        # phase de consomation
        self.drink()

        # Sortie d'un client
        Client.drink_mutex.acquire()
        Client.drinking -= 1
        state = "quitte sa place"
        item = "client {0:3d} {2:30s} compteur = {1:d}".format(self._id,Client.drinking,state)
        self._fifo.put(item)
        Client.drink_mutex.release()
        Client.enter_multiplex.release()
    
    def drink(self):
        sleep(uniform(1, 3))
    
    def to_arrive(self):
        sleep(uniform(0, 20))
        item = 'client {:3d} arrive au bar'.format(self._id)
        self._fifo.put(item)
    
class Affiche(Thread):
    def __init__(self, fifo):
        super().__init__() # Thread.__init__(self)
        self.setDaemon(True)
    
    def run(self):
        while True:
            item = Fifo.get()
            print(item)
            Fifo.task_done()
            sleep(0.1)

# main
Fifo = Queue()
Th_clients = [Client(i+1, Fifo) for i in range(Nb_clients)]

display = Affiche(Fifo)
display.start()

for t in Th_clients : t.start()

for t in Th_clients : t.join()

Fifo.join()

print("\nPlus de client !")
