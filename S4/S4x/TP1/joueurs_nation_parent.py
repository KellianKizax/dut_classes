#!/usr/bin/python3
# -*- coding: UTF-8 -*-

# author: Kellian GOFFIC
# usage: joueurs_nation_parent.py nation
# =====================================
# Affichage des informations
# des joueurs de la nationnalité donnée
# en paramètre, en faisant appel à
# 'joueurs_nation_subproc.py'.
# =====================================

import datetime
import sys
import subprocess

if len(sys.argv[1:]) == 0:
    sys.stderr.write("Argument 'nation' manquant !\n")
    exit(1)

pipe = subprocess.Popen( "./joueurs_nation_subproc.py "+sys.argv[1], shell=True, stdout=subprocess.PIPE )

nb_lignes = 0
for ligne in pipe.stdout:
    ligne = ligne[:-1].decode()

    infos = ligne.split(':')
    age = datetime.date.today().year - int(infos[3])

    sys.stdout.write(f"""{infos[0]}, {infos[1]}, {age} ans\n""")
