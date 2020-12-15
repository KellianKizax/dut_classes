/******************************************************************************
 * SCRIPT BGG - V1
 *****************************************************************************/

/*-----------------------------------------------------------------------------
 * Cette fonction est exécutée après la fin du chargement de la page où le
 * script est inclut. Elle ajoute un écouteur de clics au bouton de soumission
 * du formulaire de la page courante qui exécute la fonction searchGames()
 * en lui transmettant le contenu de l'input text du formulaire.
 *---------------------------------------------------------------------------*/
window.onload = function ()
{
    let sectionBGG = document.getElementById('bgg-found');
    let champTexte = document.getElementsByTagName("input")[0];
    let boutton = document.getElementsByTagName("input")[1];
    boutton.addEventListener("click", function(event){
        sectionBGG.innerHTML="";
        let recherche = champTexte.value;
        event.preventDefault();
        searchGames(recherche);
    });


};

/*-----------------------------------------------------------------------------
 * Utilise l'API Fetch pour lancer une requête vers le serveur
 * w11.iutrs.unistra.fr:3000 qui recherche tous les jeux contenant la chaine du
 * paramètre query. Lorsque les données sont réceptionnées, elles sont
 * transmises au format JSON à la fonction updateFoundGames().
 * S'il y a une erreur, elle doit être inscrite dans la console.
 *---------------------------------------------------------------------------*/
function searchGames(query)
{
    console.log("Recherche : "+query);
    fetch("http://w11.iutrs.unistra.fr:3000/api/boardgames?search="+query)
    .then( function (response) {
        if (response.ok)
            return response.json();
        throw new Error('Erreur : Response is not OK');
    })
    .then( function (data) {
        updateFoundGames(data.data);
    })
    .catch( function (error) {
        console.log(error.message);
    });
}

/*-----------------------------------------------------------------------------
 * Ajoute tous les jeux du paramètre games (au format JSON) dans la section
 * #bgg-found. Chaque jeu est représenté par un bouton contenent sa miniature
 * (thumbnail) et son titre.
 * S'il n'y a pas de jeux dans 'games', une erreur est déclenchée.
 *---------------------------------------------------------------------------*/
function updateFoundGames(games)
{
  let sectionBGG = document.getElementById('bgg-found');
    console.log(games);
    for (let i = 0; i < games.length; i++){
        let a = document.createElement("article");
        let p = document.createElement("p");
        let img = document.createElement("img");
        p.innerHTML = games[i].name;
        img.src = games[i].thumbnail;
        img.alt = "image indisponible";
        sectionBGG.appendChild(a);
        a.appendChild(p);
        a.appendChild(img);

    }

}
