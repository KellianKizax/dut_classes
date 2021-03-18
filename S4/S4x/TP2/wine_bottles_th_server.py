#!/usr/bin/python3
# -*- coding: utf8 -*-

# author: Kellian GOFFIC        10/02/2021
# usage: wine_bottles_th_server.py
# ===============================================
# Le serveur attent une requête de la part d'un
# client ; il met ensuite le stock a jour
# par le biais d'un thread par client et lui
# répond.
# Le serveur se termine lorsque le stock est
# épuisé.
# ===============================================

"""
Le server attend les requêtes de clients ; après acceptation d'une requête, il met
à jour le stock de bouteillers (300 au départ) puis répond au client (la quantité
livrée, qui peut être inférieure à celle demandée).
Le serveur se termine lorsque le stock est épuisé 
"""

from socket import *
from time import sleep
from threading import Thread, Lock


MUTEX = Lock()
stock = 300

server_host = "localhost"
server_port = 1664


# ===============================================
# Classe StockManager

class StockManager(Thread):

    def __init__( self, request, connection ):
        Thread.__init__(self)
        self.__request = request
        self.__connection = connection
    
    def run(self):
        global stock
        global MUTEX
        
        delivery = 0
        print(f"""Commande de {self.__request} bouteille(s).""")

        MUTEX.acquire()
        if stock <= 0:
            MUTEX.release()
            return

        elif stock < self.__request:
            delivery = stock
            stock = 0
            print(f"""Reste en stock : {stock} bouteille(s).\n\n""")
            MUTEX.release()
        
        else:
            stock -= self.__request
            print(f"""Reste en stock : {stock} bouteille(s).\n\n""")
            MUTEX.release()
            delivery = self.__request

        sleep(3)
        message = f"""{delivery}"""
        self.__connection.send(message.encode())
        self.__connection.close()

# ===============================================
# Main


sock = socket(AF_INET, SOCK_STREAM)
sock.bind((server_host, server_port))
sock.listen(5)

while stock:
    print("Serveur en attente de commande.\n")
    connection, address = sock.accept()

    print(f"""Serveur connecté par {address} .""")
    request = connection.recv(1024).decode()
    request = int(request)

    StockManager( request, connection ).start()

sock.close()
print("PLUS DE STOCK!")