/******************************************************************************
 * SCRIPT BGG - V2
 *****************************************************************************/

const API_URL = 'http://w11.iutrs.unistra.fr:3000';

/*-----------------------------------------------------------------------------
 * Cette fonction est exécutée après la fin du chargement de la page où le
 * script est inclut. Elle ajoute un écouteur de clics au bouton de soumission
 * du formulaire de la page courante qui exécute la fonction searchGames()
 * en lui transmettant le contenu de l'input text du formulaire.
 *---------------------------------------------------------------------------*/
window.onload = function ()
{
	const gameName = document.querySelector('#gameName');
	document.querySelector('#buttonSearchGame').addEventListener('click',
		function(event) {
			event.preventDefault();
			searchGames( gameName.value );
		}
	);
};

/*-----------------------------------------------------------------------------
 * Utilise l'API Fetch pour lancer une requête vers le serveur
 * w11.iutrs.unistra.fr:3000 qui recherche tous les jeux contenant la chaine du
 * paramètre query. Lorsque les données sont réceptionnées, elles sont
 * transmises au format JSON à la fonction updateFoundGames().
 * S'il y a une erreur, elle doit être inscrite dans la console.
 *---------------------------------------------------------------------------*/
function searchGames( query )
{
	const url = API_URL+'/api/boardgames?search='+query;
	fetch(url)
	.then(function (res) {
		if (res.ok)
			return res.json();
		throw new Error('Response is not OK : '+response.status);
	})
	.then(function (data) {
		console.log(data);
		updateFoundGames( data.data );
		updateStatus(data.metadata.total);
	})
	.catch(function (error) {
		console.log(error.message);
	});
}

/*-----------------------------------------------------------------------------
 * Ajoute tous les jeux du paramètre games (au format JSON) dans la section
 * #bgg-found. Chaque jeu est représenté par un bouton contenent sa miniature
 * (thumbnail) et son titre.
 * S'il n'y a pas de jeux dans 'games', une erreur est déclenchée.
 *---------------------------------------------------------------------------*/
function updateFoundGames( games )
{
	if ( games.length == 0 )
		throw new Error('Aucun jeu trouvé.');

	const bggSection = document.querySelector('#bgg-found');
	for ( let i=0 ; i<games.length ; i++ )
	{
		let article = document.createElement('article');
		article.innerHTML = `<img src="${games[i].thumbnail}" alt="N/A">${games[i].name}`;
		article.addEventListener('click', function(event) {
			event.preventDefault();
			selectGame(games[i].objectid);
		});
		bggSection.appendChild(article);
	}
}

/*-----------------------------------------------------------------------------
 * Met à jour le paragraphe de la section #bgg avec un texte indiquant le
 * nombre de jeux trouvés.
 *---------------------------------------------------------------------------*/
function updateStatus( nbGames ) {
	document.querySelector('#bgg p').innerHTML = `Il y a ${nbGames} jeux qui correspondent.`;
}

/*-----------------------------------------------------------------------------
 * Recherche le jeu d'id gameId et exécute updateCurrentGame si le jeu a été
 * trouvé.
 *---------------------------------------------------------------------------*/
function selectGame( gameId ) {
    const url = API_URL+'/api/boardgames/'+gameId;
	fetch(url)
	.then(function (response) {
		if (response.ok)
			return response.json();
		throw new Error('Response is not OK : '+response.status);
	})
	.then(function (data) {
		updateCurrentGame(data.data);
	})
	.catch(function (error) {
		console.log(error.message);
	});
}

/*-----------------------------------------------------------------------------
 * Met à jour le contenu HTML de la section #bgg-selected avec les informations
 * du jeu.
 *---------------------------------------------------------------------------*/
function updateCurrentGame( game ) {
	const bggSection = document.querySelector('#bgg-selected');
	bggSection.innerHTML = `
		<article class="game">
			<header>
				<h3>${game.name}</h3>
			</header>
			<figure>
				<img src="${game.image}" alt="${game.name}">
			</figure>
			<section>
				<header>
					<h4>Caractéristiques</h4>
				</header>
				<table>
					<thead>
						<tr>
							<th>Année</th>
							<th>Nb. joueurs</th>
							<th>Durée</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td>${typeof game.yearpublished === 'object' ? 'N/A' : game.yearpublished}</td>
							<td>${typeof game.maxplayers  === 'object' || typeof game.minplayers  === 'object' ? 'N/A' : game.minplayers != game.maxplayers ? game.minplayers+'-'+game.maxplayers : game.maxplayers ? game.maxplayers : '?'}</td>
							<td>${typeof game.maxplaytime  === 'object' || typeof game.minplaytime  === 'object' ? 'N/A' : game.minplaytime != game.maxplaytime ? game.minplaytime+'-'+game.maxplaytime+' min' : game.maxplaytime ? game.maxplaytime+' min' : '?'}</td>
						</tr>
					</tbody>
				</table>
			</section>
			<section>
				<header>
					<h4>Description</h4>
				</header>
                <p>
				${game.description}
                </p>
			</section>
		</article>`;
}
