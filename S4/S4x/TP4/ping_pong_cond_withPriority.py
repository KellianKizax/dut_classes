#!/usr/bin/python3
# -*- coding: utf8 -*-

# author: Kellian GOFFIC        18/02/2021
# usage: ping_pong_cond_withPriority.py [<nb ping/pong>]
# ===============================================
# Une partie de ping pong avec des variables
# <Condition>.
# N objets (threads) Ping et N objets (threads) Pong.

from threading import Thread, Lock, Condition
from random import random
from time import sleep
from sys import argv
from queue import Queue


# définition de 2 classes Ping et Pong
class Ping(Thread):

    waiting = Queue()

    def __init__(self, id):
        super().__init__()
        self._id = id
    
    def run(self):
        global Switch
        sleep(random())

        Ping.waiting.put(self._id)
        
        Cond_ping.acquire()        
        while Switch == 1:
            Cond_pong.wait()
            if Ping.waiting.queue[0] == self._id:
                break
        
        print("ping ... ", end='')
        Switch = 1
        Ping.waiting.get()
        Cond_ping.notify()
        Cond_ping.release()


class Pong(Thread):

    waiting = Queue()

    def __init__(self, id):
        super().__init__()
        self._id = id


    def run(self):
        global Switch
        sleep(random())

        Pong.waiting.put(self._id)

        Cond_pong.acquire()
        while Switch == 0:
            Cond_ping.wait()
            if Pong.waiting.queue[0] == self._id:
                break

        print("pong")
        Switch = 0
        Pong.waiting.get()
        Cond_pong.notify()
        Cond_pong.release()

# main thread
if argv[1:]:
    N = int(argv[1])
else:
    N = 100

Switch = 0
Mutex = Lock()

Cond_ping = Condition(Mutex)
Cond_pong = Condition(Mutex)


# création d'une liste de N threads ping ;
# chaque thread fait UN (seul) ping
Threads_ping = [ Ping(i) for i in range(N) ]

# pareil pours les pongs
Threads_pong = [ Pong(i) for i in range(N) ]


for t in Threads_ping : t.start()
for t in Threads_pong : t.start()

for t in Threads_ping : t.join()
for t in Threads_pong : t.join()


print("\nFin de partie !")