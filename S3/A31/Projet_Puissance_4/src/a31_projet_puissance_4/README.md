# Rapport projet A31:

### DUVERNAY Benoît & GOFFIC Kellian - Groupe 6

08/01/2020 - V1.1

---



##### <u>**Choix de conception :**</u>

Afin de réaliser notre projet , nous avons décider de mettre en place plusieurs Design Patrern ( DP ) :

- **Un Design Pattern Observateur  :**  Notre classe `Observer` s'abonne à `Obsersable` , cette dernière notifie `Observer` quand elle change d'état et nécessite une MAJ.
  
  Il est idéal pour mettre à jour notre vue sans qu'on ait une dépendance cyclique à cette dernière.
  
  

- **Un Design Pattern Template :** Ce dernier permet une implémentation aisé des différentes variantes du puissance 4. Ce DP nous parait donc indispensable à notre projet.





##### <u>**Variante implémentée :**</u>

- **Puissance 4 Standard :** Version de base du jeu avec les règles classiques

- **5-in-a-row :** Dans cette variante on rajoute 1 colonne de 6 jetons sur chaques extrémités de la grille. La condition de victoire change car il faut maintenant aligner 5 jetons de la même couleur pour gagner.
  
  Pour cela il faut ajouter une classe `FiveInGrid` qui hérite de notre classe `Grid` , ainsi qu'une classe `FiveInGame` qui hérite de `Game`, mais aussi une classe `ConnectFourFiveIn` qui hérite de la classe `ConnectFour`, qui établira la stratégie de la variante 5-in-a-row, dans laquelle on va notamment modifier la condition de victoire dans la méthode `ConnectFourFiveIn.checkWin()`.





##### <u>**Variante non-implémentée:**</u>

- **PopOut :** Ici le joueur peut décider de retirer un jeton de sa couleur si il se trouve sur la dernière ligne.  Pour cela on créé une `PopOutView` où on va ajouter des boutons au niveau de la ligne inférieur de la grille qui permet de retirer un jeton qui lui appartient. Si il retire un jeton il faut incrémenter son nombre de jetons de un en ajoutant celui-ci à la liste des jetons possédés. Il faut donc aussi ajouter une classe `PopOutConnectFour` où on ajoute la méthode `removeDisc()` aux actions potentielles en jeu.
  
  <ScreenShot>

- **PowerUp :** Dans cette variante , le joueur possède des jetons spéciaux. Les conditions de victoire sont inchangées.
  
  Pour cela on va ajouter des jetons spéciaux qui vont hériter de la classe abstraite `Disc`. Pour chaque jeton, il faudra créer une méthode avec son effet sur la grille.
  
  De plus il faut ajouter une classe `PowerUpGame`, où l'on va modifier note méthode `distributeDisc()` pour ajouter nos jetons spéciaux et faire en sorte que chacun des joueurs possède 21 jetons en comprenant ces derniers.
  
  Enfin il faut modifier la vue pour que le joueur ait la possibilité de choisir entre le placement de jetons standards ou spéciaux, cela est fait en créant `PowerUpView` , où l'on ajoute des boutons qui permettent de séléctionner ces derniers
  
  <ScreenShot>

- **Pop10 :**  Dans cette variante, le jeu démarre réellement quand la grille est rempli. Pour cette variante nous avons pris la décision de la remplir aléatoirement au début de la partie.
  
  Le joueur doit enlever des jetons de la ligne du dessous de sa couleur pour gagner des points si ce dernier fait partie d'un alignement de 4 jetons de sa couleurs.
  
  On créé `PopTenGame` où l'on modifie `checkwin()` , `PopTenConnectFour()` pour modifier `foward()` car le joueurs retire et ajoute potentiellement un jeton dans le meme tour dans ce mode de jeu. Ainsi qu'une `PopTenView` pour afficher les points de chaque joueurs, en plus des boutons qui permettent de retirer un jeton.



##### <u>**Eventuels Problèmes :**</u>

Par manque de temps , nous avons pas pu implémenter toutes les variantes du Jeu.



                                                                                                                           DUVERNAY Benoît

                                                                                                                           GOFFIC Kellian
