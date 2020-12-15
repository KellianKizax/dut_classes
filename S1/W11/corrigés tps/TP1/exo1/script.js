function GenereTab(){
  let tab = []; let nbr;
  for (let i = 0; i < 50; i++){
    nbr = Math.floor(Math.random() * 100);
    tab.push(nbr);
  }
  return tab;
}

function deterMax(Xtab) {
  let max = Xtab[0];

  for (let i = 1; i < Xtab.length; i++){
    if (max < Xtab[i]){
      max = Xtab[i];
    }
    else;
  }
  return max;
}

function deterMin(Xtab) {
  let min = Xtab[0];

  for (let i = 1; i < Xtab.length; i++){
    if (min > Xtab[i]){
      min = Xtab[i];
    }
    else;
  }
  return min;
}

let tab1 = GenereTab();

console.log(tab1);
console.log("Voila le maximum : "+deterMax(tab1));
console.log("Voila le minimum : "+deterMin(tab1));
