#!/usr/bin/python3
# -*- coding: utf8 -*-
# joueurs_par_nation.py  nation

'''
Structure du fichier foot_2020.txt dont on suppose qu'il est ds le repertoire courant :
nom:club:poste:annee_naissance:nation
Exemples valeur de nation : fr, br, de

Liste les footballeurs de clubs (de la champion's league), dont la nationalité est la nation 
passée en paramètre
On affiche juste les infos "nom, club et age"
'''

import sys, os
import datetime

if len(sys.argv[1:]) == 1 :
    nation = sys.argv[1]
else :
    sys.stderr.write("Usage : " + os.path.basename(sys.argv[0]) + " nation\n")
    exit(1)

nom_fichier='foot_2020.txt'
if not os.path.isfile(nom_fichier) :
    msg = nom_fichier + ": fichier inexistant !\n"
    sys.stderr.write(msg)
    exit(1)

joueurs = open(nom_fichier, 'r')
annee_courante = datetime.datetime.now().year

un_joueur = joueurs.readline()[:-1] # on se debarrasse du '\n' de fin de ligne
while un_joueur:
    if un_joueur.endswith(nation):
        nom, club, _, annee_nais, _ = un_joueur.split(':')  # conversion de la chaine en tableau
        age = annee_courante - int(annee_nais)
        print(nom + ', ' + club + ', ' + str(age))
    un_joueur = joueurs.readline()[:-1]

joueurs.close()

# Affichage avec alignement des colonnes à gauche
print('\nAffichage avec alignement des colonnes à gauche')
input('Appuyer sur Entree')
print()

# Reouverture du fichier
joueurs = open(nom_fichier, 'r')

un_joueur = joueurs.readline()[:-1] # on se debarrasse du '\n' de fin de ligne
while un_joueur:
    if un_joueur.endswith(nation):
        nom, club, _, annee_nais, _ = un_joueur.split(':')  # conversion de la chaine en tableau
        age = annee_courante - int(annee_nais)
        print( '{0:14s}| {1:20s}| {2:d} ans'.format(nom, club, age) )
        # print( '%-14s| %-20s| %2d ans' %(nom, club, age) )
    un_joueur = joueurs.readline()[:-1]

joueurs.close()

