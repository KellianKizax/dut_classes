#!/usr/bin/python3
# -*- coding: utf8 -*-

# author:   Kellian GOFFIC      03/02/2021
# usage:    joueurs_par_nation_thread.py nation
# ==============================================
# Affiche les informations des joueurs de la
# nationnalité donnée en paramètre.
# ==============================================

from threading import Thread
from time import sleep
from sys import argv, stderr, stdout
from queue import Queue
from datetime import datetime
from os.path import basename
import os


PATH_FILE = "foot_2020.txt"
FILE_DESC = -1


# définition de la fonction writer
def writer( fifo, nation ):
    for line in FILE_DESC:
        if line.split(':')[4][0:-1] == nation:
            fifo.put(line)
    fifo.put(None)

# définition de la fonction reader
def reader(fifo):
    un_joueur = fifo.get()      # get bloquant      # idem que : un_joueur = fifo.get(block=True)
    while un_joueur is not None:
        line = un_joueur[:-1]
        line = line.split(':')
        age = datetime.today().year - int(line[3])

        stdout.write(f"""{line[0]}, {line[1]}, {age} ans\n""")

        un_joueur = fifo.get()      # get bloquant


# main
# lecture/contrôles des paramètres, ouverture du fichier
if len(argv[1:]) == 0:
    stderr.write("Argument 'nation' manquant !\n")
    exit(1)


NATION = argv[1]

if not os.path.isfile(PATH_FILE):
    stderr.write(f"""{PATH_FILE} : Problème à l'ouverture !\n""")
    exit(1)

FILE_DESC = open(PATH_FILE, 'r')

# création de la file FIFO (Queue)
fifo = Queue()

# Instanciation et démarrage des deux threads
t1 = Thread( target=writer, args=(fifo, NATION) )
t1.start()
t2 = Thread( target=reader, args=(fifo,) )
t2.start()

t1.join()
t2.join()

# fermeture du fichier
FILE_DESC.close()
