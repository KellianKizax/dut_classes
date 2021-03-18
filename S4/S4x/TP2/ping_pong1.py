#!/usr/bin/python3
# -*- coding: utf8 -*-

# author: Kellian GOFFIC        09/02/2021
# usage: ping_pong1.py <nb ping/pong>
# =========================================
# Lance autant de threads 'ping' que de
# threads 'pong', chaque thread fait un
# seul 'ping' ou 'pong'.
# =========================================

# Utilisation d'un verrou (Mutex)
# et d'une variable d'état "bascule" (Ping_OK)

from time import sleep
from random import random
from threading import Lock, Thread
from sys import argv, stdout


def ping():
    # global Mutex
    global Ping_OK
    sleep(random())
    while True:
        MUTEX.acquire()
        if ( Ping_OK == False ):
            stdout.write("ping ... ")
            Ping_OK = True
            MUTEX.release()
            break
        MUTEX.release()


def pong():
    # global Mutex
    global Ping_OK
    sleep(random())
    while True:
        MUTEX.acquire()
        if ( Ping_OK == True ):
            stdout.write("pong\n")
            Ping_OK = False
            MUTEX.release()
            break
        MUTEX.release()


# === main Thread =============================
if __name__ == "__main__":
    if argv[1:]:
        N = int(argv[1])
    else:
        N = 100
    Ping_OK = False
    MUTEX = Lock()

    # création d'une liste de N threads ping ;
    # chaque thread fait UN (seul) ping
    Threads_ping = [ Thread(target=ping) for i in range(N) ]

    # pareil pours les pongs
    Threads_pong = [ Thread(target=pong) for i in range(N) ]

    for t in Threads_ping : t.start()
    for t in Threads_pong : t.start()

    for t in Threads_ping : t.join()
    for t in Threads_pong : t.join()

    print("\nFin de partie !")