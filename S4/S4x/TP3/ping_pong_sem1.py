#!/usr/bin/python3
# -*- coding: utf8 -*-

# author: Kellian GOFFIC        17/02/2021
# usage: ping_pong_sem1.py [<nb ping/pong>]
# =========================================
# Lance autant de threads 'ping' que de
# threads 'pong', chaque thread fait un
# seul 'ping' ou 'pong'.
# Délègue l'affichage des 'ping' et 'pong'
# a un thread dédié.
# =========================================


from time import sleep
from random import random
from threading import Thread, BoundedSemaphore, Semaphore
from sys import argv, stdout
from queue import Queue


class Affiche(Thread):
    def run(self):
        #global Fifo
        item = Fifo.get()
        while not (item is None):
            print(item,end="")
            sleep(0.1)
            item = Fifo.get()


def ping():
    sleep(random())
    SEM_PING.acquire()
    Fifo.put("ping ... ")
    #stdout.write("ping ... ")
    SEM_PONG.release()

def pong():
    sleep(random())
    SEM_PONG.acquire()
    Fifo.put("pong\n")
    #stdout.write("pong\n")
    SEM_PING.release()


# === main Thread =============================
if __name__ == "__main__":

    if argv[1:]:
        N = int(argv[1])

    else:
        N = 100


    SEM_PING = BoundedSemaphore(1)
    SEM_PONG = Semaphore(0)
    Fifo = Queue()


    # création d'une liste de N threads ping ;
    # chaque thread fait UN (seul) ping
    Threads_ping = [ Thread(target=ping) for i in range(N) ]

    # pareil pours les pongs
    Threads_pong = [ Thread(target=pong) for i in range(N) ]

    display = Affiche()
    display.start()
    
    for t in Threads_ping : t.start()
    for t in Threads_pong : t.start()

    for t in Threads_ping : t.join()
    for t in Threads_pong : t.join()
    
    Fifo.put(None)
    display.join()

    print("\nFin de partie !")