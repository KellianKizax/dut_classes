Cesar_GOFFICK_G2.cs : Programme de cryptage/décryptage de messages chiffrés par décalage, code César.

Fichier de présentation du fonctionnement du programme.

Fonctionnement :

Au démarrage du programme vous pouvez voir s'afficher le menu suivant :

		||>> Bienvenu dans le programme César !
		|| 'Je préfère être le premier homme ici que le second dans Rome.' -Jules César
		||
		||==================== Code César ====================||
		|| Sélectionnez le numéro de l'action souhaitée.      ||
		||                                                    ||
		|| 1- Cryptage d'un message                           ||
		|| 2- Décryptage brute d'un message                   ||
		|| 3- Décryptage analyse fréquentielle                ||
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 

Vous n'avez qu'à sélectionner l'action de votre choix, ici nous choisirons la n°1:

	[...]
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 1
		||>> Cryptage
		||
		|| Chaine à crypter ? : Le batiment du departement informatique est le plus beau de l'IUT !    
		|| Après un décalage de ? : 47
		|| Chaine cryptée : gzwvodhzioypyzkvmozhziodiajmhvodlpzznogzkgpnwzvpyzgdpo
		||
		|| 'Pas de vin, pas de soldats.' -Jules César
		||
		||==================== Code César ====================||
		|| Sélectionnez le numéro de l'action souhaitée.      ||
		||                                                    ||
		|| 1- Cryptage d'un message                           ||
		|| 2- Décryptage brute d'un message                   ||
		|| 3- Décryptage analyse fréquentielle                ||
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 

Voici un exemple de cryptage, nous alloçns maintenant essayer de le decrypter par
analyse fréquentielle. Nous choisissons l'action n°3:

	[...]
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 3
		||>> Decryptage analyse frequentielle
		||
		|| Chaine à decrypter ? : gzwvodhzioypyzkvmozhziodiajmhvodlpzznogzkgpnwzvpyzgdpo
		||
		|| Lettre apparaissant le plus souvent : z
		|| Chaine décryptée : lebatimentdudepartementinformatiqueestleplusbeaudeliut
		|| Le texte est-il compréhensible ? ('o'/'n') : o
		||
		||
		|| 'Veni, vidi, vici.' -Jules César
		||
		||==================== Code César ====================||
		|| Sélectionnez le numéro de l'action souhaitée.      ||
		||                                                    ||
		|| 1- Cryptage d'un message                           ||
		|| 2- Décryptage brute d'un message                   ||
		|| 3- Décryptage analyse fréquentielle                ||
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 

Nous allons maintenant essayer le décryptage brute avec un élément crypté plus court:

	[...]
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 2    
		||>> Decryptage brute
		||
		|| Chaine à decrypter ? : cruur
		|| Chaine cryptée : cruur
		|| Décalage de 1
		|| Chaine décryptée : bqttq
		|| Le texte est-il compréhensible ? (oui/non) : non
		|| Décalage de 2
		|| Chaine décryptée : apssp
		|| Le texte est-il compréhensible ? (oui/non) : non
		|| Décalage de 3
		|| Chaine décryptée : zorro
		|| Le texte est-il compréhensible ? (oui/non) : oui
		||
		||==================== Code César ====================||
		|| Sélectionnez le numéro de l'action souhaitée.      ||
		||                                                    ||
		|| 1- Cryptage d'un message                           ||
		|| 2- Décryptage brute d'un message                   ||
		|| 3- Décryptage analyse fréquentielle                ||
		|| 4- Quitter                                         ||
		||                                                    ||
		||==================== Code César ====================||
		||
		|| 

Voilà, la présentation du programme est terminée, nous vous invitons à l'essayer de vous-même.


Kellian GOFFIC