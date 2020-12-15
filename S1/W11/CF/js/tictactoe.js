/******************************************************************************
 * SCRIPT TIC-TAC-TOE - W11
 ******************************************************************************/

// URL de l'API utilisée
const API_URL = 'http://w11.iutrs.unistra.fr:8080/api/games/';

// Variables globales utilisées dans les différentes fonctions ci-dessous
let gameId = false; // Identifiant de la partie
let isEnded = true; // Vrai s'il n'y a pas de partie en cours

/*-----------------------------------------------------------------------------
 * Au chargement de la page, réalise les deux opérations suivantes :
 * 1) ajoute un écouteur de l'événement "click" au bouton "Démarrer" qui
 *    démarre le jeu avec startGame() si le nom d'utilisateur de l'<input> html
 *    correspondant n'est pas vide.
 * 2) exécute la fonction initializeCellListeners()
 */
window.onload = function() {
    const startButton = document.getElementsByTagName("input")[1];
    const username = document.getElementById("name")[0];

    /*ne s'active jamais ????? refresh la page à la place*/
    /*startButton.addEventListener("click", startGame())*/

    startGame("kellian")
    initializeCellListeners();
}

/*-----------------------------------------------------------------------------
 * Ajoute aux 9 cellules de la grille un écouteur de l'événement "click" qui
 * exécute la fonction play() avec l'indice de la cellule (de 0 à 8), si et
 * seulement si le jeu n'est pas terminé et que la cellule est vide.
 * Identifiants des cellules :
 *     <table> |---|---|---|
 *             | 0 | 1 | 2 |
 *             |---|---|---|
 *             | 3 | 4 | 5 |
 *             |---|---|---|
 *             | 6 | 7 | 8 |
 *             |---|---|---| </table>
 */
function initializeCellListeners() {
    for (let i = 0; i < 9; i++) {
        let td = document.getElementsByTagName("td")[i];
        /* chose étonnante, ces addEventListener fonctionnent eux, comparés à la ligne 24, mais s'active sans toucher à la souris ?? */
        td.addEventListener('click', play(i))
    }
}

/*-----------------------------------------------------------------------------
 * Démarre le jeu avec la requête fetch adéquate.
 * Si la réponse est bonne, exécute la fonction updateGameInformations(). Avant
 * toute chose, cette fonction réinitialise le plateau de jeu.
 */
function startGame(username) {
    event.preventDefault;

    resetBoard();

    fetch(API_URL + "create?username=" + username)
        .then(function(res) {
            if (res.ok)
                return res.json();
            else
                throw new Error(res.status);
        })
        .then(function(data) {
            updateGameInformations(data);
        })
        .catch(function(error) {
            console.log(error.message);
        })
}

/*-----------------------------------------------------------------------------
 * Met à jour les informations de jeu, à savoir :
 * 1) Met à jour les les variables globales gameId et isEnded de ce fichier
 * 2) Met à jour l'identifiant de la partie dans le <footer> de la page HTML
 * 3) Met à jour le message du premier élément <h2> de la page HTML avec, selon
 *    les cas :
 *     - "Aucune partie en cours"
 *     - "À vous de jouer <username>"
 *     - "Bravo <username> ! Tu as gagné !"
 *     - "L'ordinateur a gagné, essaye encore."
 *     - "Match nul."
 * 4) Met à jour la couleur d'arrière-plan du <main> : #00a934 si l'humain a
 *    gagné, #ff8001 si c'est l'ordinateur, #009fe3 dans tous les autres cas.
 * 5) Affiche le temps restant à jouer dans le paragraphe situé en-dessous du
 *    <h2> de la seconde <section>.
 */
function updateGameInformations(data) {
    gameId = data.id;
    isEnded = data.isEnded;
    const footerspan = document.getElementsByTagName("span")[3];
    footerspan.innerHTML = gameId;

    const h2 = document.getElementsByTagName("h2")[0];
    const main = document.getElementsByTagName("main")[0];

    if (data.id == "") {
        h2.innerHTML = "Aucune partie en cours"
        main.style.backgroundColor = "#009fe3";
    } else if (data.winner == "computer") {
        h2.innerHTML = "L'ordinateur a gagné, essaye encore."
        main.style.backgroundColor = "#ff8001";
    } else if (data.winner == "human") {
        h2.innerHTML = "Bravo " + data.username + " ! Tu as gagné !"
        main.style.backgroundColor = "#00a934";
    } else if (data.winner == "none") {
        h2.innerHTML = "Match nul."
        main.style.backgroundColor = "#009fe3";
    } else {
        h2.innerHTML = "A vous de jouer " + data.username
        main.style.backgroundColor = "#009fe3";
    }

    const paragraph = document.getElementsByTagName("p")[0];
    paragraph.innerHTML = ""

}

/*-----------------------------------------------------------------------------
 * Joue dans la cellule n°pos avec la requête fetch adéquate.
 * Si la réponse est bonne, met à jour le plateau et les information de jeu
 * avec updateBoard() et updateGameInformations()
 */
function play(pos) {
    fetch(API_URL + gameId + "/play?pos=" + pos)
        .then(function(res) {
            if (res.ok)
                return res.json();
            else
                throw new Error(res.status);
        })
        .then(function(data) {
            updateGameInformations(data);
        })
        .catch(function(error) {
            console.log(error.message);
        })

}

/*-----------------------------------------------------------------------------
 * Met à jour le plateau de jeu HTML à partir de la grille board.
 * Chaque valeur "X" ou "O" de board donne lieu à une cellule <td> avec pour
 * classe et contenu textuel cette valeur "X" ou "O".
 * Par exemple, ce board doit permettre d'obtenir cette <table> :
 *                            <table>
 * board = [ "X","","",         <tr><td class="X">X</td><td></td><td></td></tr>
 *           "", "","O",   ==>  <tr><td></td><td></td><td class="O">O</td></tr>
 *           "", "","" ]        <tr><td></td><td></td><td></td></tr>
 *                            </table>
 */
function updateBoard(board) {

    for (let i = 0; i < 9; i++) {
        let td = document.getElementsByTagName("td")[i];

        if (board[i] == "X") {

            td.classList.add("X");
            td.innerHTML = "X";
        } else if (board[i] == "0") {

            td.classList.add("O");
            td.innerHTML = "O";
        } else {}
    }
}

/*-----------------------------------------------------------------------------
 * Supprime toutes les classes et tout le contenu des toutes les cellules du
 * plateau de jeu HTML.
 */
function resetBoard() {
    const table = document.querySelector("table");
    table.innerHTML = `
                <tr>
                    <td> </td>
                    <td> </td>
                    <td> </td>
                </tr>
                <tr>
                    <td> </td>
                    <td> </td>
                    <td> </td>
                </tr>
                <tr>
                    <td> </td>
                    <td> </td>
                    <td> </td>
                </tr>
`
}