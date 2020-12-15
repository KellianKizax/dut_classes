function AjouteZero(nbr) {
    if (typeof(nbr) == 'number') {
        nbr = String(nbr);
    } else {}
    if (nbr.length == 1) {
        nbr = "0" + nbr;
    } else {}
    return nbr;
}

let date = new Date();
let heure = date.getHours();
heure = AjouteZero(heure);
let minutes = date.getMinutes();
minutes = AjouteZero(minutes);
let secondes = date.getSeconds();
secondes = AjouteZero(secondes);

console.log(heure + ':' + minutes + ':' + secondes);