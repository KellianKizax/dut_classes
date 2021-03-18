#!/usr/bin/python3
# -*- coding: utf8 -*-
# threaded_ping.py2 host ...

# NB : c'est le shell qui affiche les lignes de la commande ping
#   (le script python n'intercepte pas les lignes de résultat, mais seulement le code retour)

from sys import argv, stderr
from subprocess import DEVNULL, call
from os.path import basename
from threading import Lock, Thread

mutex = Lock()
results = []


def ping(hote, delai):
    # on lance la commande unix ping pour interroger l'hote
    #   (option -w pour arrêter un certain délai sinon ping "boucle")

    # retour = call( ['/bin/ping', '-w' + str(delai), hote] )
    

    # Si on ne souhaite pas de trace du déroulement de ping (ni message d'erreur)
    retour = call( ['ping', '-w' + str(delai), hote], stdout=DEVNULL, stderr=DEVNULL)

    mutex.acquire()

    if retour == 0:
        results.append( ( hote, 'VIVANT' ) )
    elif retour == 1:
        results.append( ( hote, 'DEFAILLANT' ) )
    else:
        results.append( ( hote, 'INCONNU' ) )

    mutex.release()


# === main =======================================================
if len(argv[1:]) == 0:
    stderr.write('Usage : ' + basename(argv[0]) + ' host ...\n')
    exit(1)


delai = 3
for hote in argv[1:]:
    t = Thread( target=ping, args=(hote, delai) )
    t.start()
    t.join()


etoiles = '*' * 30
print(etoiles)
for res in results:
    host, status = res
    print( f"""{host} : {status}""" )
    print(etoiles)