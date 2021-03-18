#!/usr/bin/python3
# -*- coding: utf8 -*-
# joueurs_nation_parent.py nation

#___________________________________________________________________________
# Ce programme appelle le script joueurs_nation_subproc.py avec <subprocess.Popen>
#___________________________________________________________________________

'''
Récupère des lignes de structure :
nom:club:poste:annee_naissance:nation

Liste les infos "nom, club et age" de footballeurs de clubs (de la champion's league) dont la nationalité
 est la nation passée en paramètre
'''

from os.path import basename
from sys import stdout, stderr, argv
from datetime import datetime
from subprocess import Popen, PIPE

def process_pipeout(joueurs):
    annee_courante = datetime.now().year
    for un_joueur in joueurs.stdout: # ici on ne récupère que des joueurs de la nationalité voulue
        un_joueur = un_joueur[:-1] # pas indispensable ici 
        nom, club, _, annee_nais, _  = un_joueur.split(':')
        age = annee_courante - int(annee_nais)
        print( '{0:14s}| {1:20s}| {2:d} ans'.format(nom, club, age) )

# __ Variante __
def process_pipeout_bis(joueurs):
    annee_courante = datetime.now().year
    un_joueur = joueurs.stdout.readline()[:-1] # [:-1] pas indispensable
    while un_joueur:
        nom, club, _, annee_nais, _  = un_joueur.split(':')
        age = annee_courante - int(annee_nais)
        print( '{0:14s}| {1:20s}| {2:d} ans'.format(nom, club, age) )
        un_joueur = joueurs.stdout.readline()[:-1] # [:-1] pas indispensable

if __name__ == "__main__" :
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
            joueurs.close() # on referme car c'est le processus appelé qui va lire le fichier

            joueurs = Popen(['python3', 'joueurs_nation_subproc.py' , nation], stdout=PIPE, universal_newlines=True)
            # rem : sans le paramètre <universal_newlines=True>, il faudrait ajouter dans la boucle de lecture
            #       des lignes renvoyées par le sous-processus, l'instruction "un_joueur = un_joueur.decode()"
            #       avant l'instruction " ... = un_joueur.split(':')"
            # _______________________________________________________
            # variante:
            # joueurs = Popen('python3 joueurs_nation_subproc.py ' + nation, shell=True, stdout=PIPE, universal_newlines=True)

            process_pipeout(joueurs)
