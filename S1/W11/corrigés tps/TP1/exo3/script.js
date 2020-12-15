let main = document.getElementsByTagName('main')[0];

let section = document.createElement("section");
main.appendChild(section);

let ul = document.createElement("ul");
section.appendChild(ul);

let li1 = document.createElement("li");
let texte1 = document.createTextNode("element 1");
let li2 = document.createElement("li");
let texte2 = document.createTextNode("element 2");
let li3 = document.createElement("li");
let texte3 = document.createTextNode("element 3");

ul.appendChild(li1);
li1.appendChild(texte1);
ul.appendChild(li2);
li2.appendChild(texte2);
ul.appendChild(li3);
li3.appendChild(texte3);
