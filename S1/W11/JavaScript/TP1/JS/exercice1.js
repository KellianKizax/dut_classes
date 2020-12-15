console.log("console.log('ca marche pas')");
let tab = [];
for (let i = 0; i < 50; i++) {
    tab[i] = Math.floor(Math.random() * 100);
}

function valMax(tab) {
    let res = tab[0];

    for (let i = 1; i < tab.length; i++) {
        if (tab[i] > res) {
            res = tab[i];
        } else {}
    }
    return res;
}

function valMin(tab) {
    let res = tab[0];

    for (let i = 1; i < tab.length; i++) {
        if (tab[i] < res) {
            res = tab[i];
        } else {}
    }
    return res;
}

console.log(tab);
console.log(valMax(tab));
console.log(valMin(tab));