function PasseEnTextArea(event){
  s.removeChild(p);
  s.appendChild(textarea);
  s.appendChild(b);

}

function PasseEnParagraphe(event){
  let contenu = textarea.value;
  s.removeChild(textarea);
  s.removeChild(b);
  p.innerHTML = contenu;
  s.appendChild(p);
  

}

let s = document.getElementsByTagName("section")[0];
let p = document.createElement("p");
p.innerHTML = "Clique ici pour changer en textarea";
s.appendChild(p);
let b = document.createElement("input");
let textarea = document.createElement("textarea");
b.type = "submit";
b.value = "valider";
p.addEventListener("click", PasseEnTextArea);
b.addEventListener("click", PasseEnParagraphe);
