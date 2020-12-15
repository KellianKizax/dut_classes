function transforme(event) {
    let element = event.target;
    let parent = element.parentElement;
    let textarea = document.createElement('textarea');
    let bouton = document.createElement('input')
    bouton.setAttribute('type', 'submit');
    bouton.setAttribute('value', 'valider');
    bouton.setAttribute('onclick', 'valideInput()');

    parent.removeChild(element);
    parent.appendChild(textarea);
    parent.appendChild(bouton);
}

function valideInput() {
    let textarea = document.getElementsByTagName('textarea')[0];
    let texte = textarea.value;
    let bouton = document.getElementsByTagName('input')[0];
    let parent = bouton.parentElement;

    console.log(texte)
    parent.removeChild(bouton);
    parent.removeChild(textarea);

    let paragraphe = document.createElement('p');
    paragraphe.innerHTML = texte;
    parent.appendChild(paragraphe);

}

let paragraphe = document.getElementsByTagName('p')[0];
paragraphe.addEventListener('click', transforme);