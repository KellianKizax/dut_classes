# 1.Processus légers et synchronisation

---

### 1.1. Combien y'a-t-il de chemins d'exécution ?

Dans cet exemple, le processus lourd créé deux processus légers, chacun ayant son chemin d'exécution, il y a donc 3 chemins d'exécution (1 lourd + 2 légers).



### 1.2. Que se passerait il si le père ne faisait pas de `pthread_join()`  ?

Le processur père s'arreterait sans attendre la fin de l'exécution des fils créés.



### 1.3. Dans quel ordre s'exécutent les threads ?

Les threads s'exécutent en fonction de l'ordonnanceur, mais certainement dans l'ordre de création dans le processus père, ici `tacheA` en premier puis `tacheB`.



### 1.4. Proposer quatre solutions différentes permettant de garantir que `ta` incrémente `glob` avant que `tb` ne le fasse.

1.  `sleep(1)` au début de `tb`, afin que l'ordonnanceur (re)élise `ta` avant `tb` (marche qu'avec 2 threads).

2. On créé et attend `ta` avant `tb` (on casse la synchronisation des deux threads dans ce cas).

3. Utilisation d'une variable de synchronisation (`vsync = 0` au lancement du processus lourd, et incrémentation lorsque `ta` est appelé, `tb` attend que cette variable `vsync != 0`)

4. Utilisation de signaux globaux, `pause()` au début de `tb`, et `pthread_kill()` à la fin de `ta`.






