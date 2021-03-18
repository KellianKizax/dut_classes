#!/usr/bin/python3
# wine_bottles_server.py

"""
Le server attend les requêtes de clients ; après acceptation d'une requête, il met
à jour le stock de bouteillers (300 au départ) puis répond au client (la quantité
livrée, qui peut être inférieure à celle demandée).
Le serveur se termine lorsque le stock est épuisé 
"""

from socket import *
from time import sleep


stock = 300

server_host = "localhost"
server_port = 1664

sock = socket(AF_INET, SOCK_STREAM)
sock.bind((server_host, server_port))
sock.listen(5)

while stock:
    print("Serveur en attente de commande.\n")
    connection, address = sock.accept()
    
    print(f"""Serveur connecté par {address} .\n""")
    request = connection.recv(1024).decode()
    request = int(request)
    
    if request:
        print(f"""Commande de {request} bouteille(s).\n""")
        
        delivery = 0
        if stock >= request:
            stock -= request
            delivery = request
        
        else:
            delivery = stock
            stock = 0

        sleep(3)
        message = f"""{delivery}"""
        connection.send(message.encode())
        connection.close()
        print(f"""Reste en stock : {stock} bouteille(s).\n\n""")

print("PLUS DE STOCK!")