function changeCouleur() {
    let element = document.getElementsByTagName('body')[0];
    element.classList.toggle('rouge');
    element.classList.toggle("vert");
}

let body = document.getElementsByTagName('body')[0];
body.addEventListener('click', changeCouleur);