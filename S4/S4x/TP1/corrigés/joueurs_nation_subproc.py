#!/usr/bin/python3
# -*- coding: utf8 -*-
# joueurs_nation_subproc.py  nation

# ________________________________________________________________
# le script est appelé par joueurs_nation_parent.py (via subprocess.Popen)
# (mais il peut aussi être exécuté indépendamment ce qui explique la verification sur
#  le paramètre et sur le fichier)
# ________________________________________________________________

'''
Structure du fichier foot_2020.txt dont on suppose qu'il est ds le répertoire courant :
nom:club:poste:annee_naissance:nation
Exemples valeur de nation : fr, es, br, ...
Filtre les footballeurs de clubs (de la Champion's League), dont la nationalité est la nation passée en paramètre
'''

from os.path import basename
from sys import stdout, stderr, argv
from time import sleep

nom_fichier='foot_2020.txt'
if len(argv[1:]) != 1 :
    stderr.write("Usage : " + basename(argv[0]) + " nation\n")
else :
    nation = argv[1]
    try:
        joueurs = open(nom_fichier, 'r')
    except IOError:
        msg = nom_fichier + ": Pb ouverture !\n"
        stderr.write(msg)
    else:
        un_joueur = joueurs.readline()[:-1]
        while un_joueur:
            if un_joueur.endswith(nation):
                print(un_joueur)
                # stdout.write(un_joueur + '\n')
                stdout.flush() # pour vider le buffer et "forcer" le print
                sleep(0.5) # pour ralentir la production de resultats
            un_joueur = joueurs.readline()[:-1]
        joueurs.close()
