#!/usr/bin/python3
# -*- coding: UTF-8 -*-

# author: Kellian GOFFIC
# usage: joueurs_nation_subproc.py nation
# =====================================
# Affichage des informations telles
# qu'inscrites dans le fichier foot_2020.txt
# des joueurs de la nationnalité donnée
# en paramètre.
# =====================================

import os
import sys

PATH_FILE = "foot_2020.txt"

if len(sys.argv[1:]) == 0:
    sys.stderr.write("Argument 'nation' manquant !\n")
    exit(1)

if not os.path.isfile(PATH_FILE):
    error_msg = PATH_FILE + " : Problème à l'ouverture.\n"
    sys.stderr.write(error_msg)
    exit(1)


file = open(PATH_FILE, 'r')

for line in file:
    if line.split(':')[4][0:-1] == sys.argv[1]:
        sys.stdout.write(line)
