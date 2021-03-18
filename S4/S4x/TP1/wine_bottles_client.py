#!/usr/bin/python3
# wine_bottles_client.py

"""
Le client commande un certain nombre de N bouteilles de vin sur le serveur ;
N est tiré au hasard parmi [1,99].
Après envoi de sa demande, le client attend la réponse et se termine.
"""

from socket import *
from random import randint
import sys

server_host = "localhost"
server_port = 1664

sock = socket(AF_INET, SOCK_STREAM)

try:
    sock.connect((server_host, server_port))
except:
    sys.stderr.write("Service non disponible\n")
else:
    request = f"""{randint(0,99)}"""
    sock.send(request.encode())

    delivery = sock.recv(1024).decode()
    print(f"""{delivery} bouteille(s) recue(s).\n""")

    sock.close()
