#!/usr/bin/python3
# -*- coding: UTF-8 -*-

# author: Kellian GOFFIC
# usage: joueurs_par_nation.py nation
# =====================================
# Affichage des informations des
# joueurs de la nationnalité de la
# nation donnée en paramètre.
# =====================================

import datetime
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
        infos = line.split(':')
        age = datetime.date.today().year - int(infos[3])

        sys.stdout.write(f"""{infos[0]}, {infos[1]}, {age} ans\n""")
