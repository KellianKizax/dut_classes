let date = new Date();
let heure = date.getHours();
let minute = date.getMinutes();
let seconde = date.getSeconds();

function AjouteZero(nbr){
  let nbzero = nbr;
  if (nbr < 10){
    nbzero = "0"+nbr;
  }
  return nbzero;
}

console.log(AjouteZero(heure)+":"+AjouteZero(minute)+":"+AjouteZero(seconde));
