function incremente(event) {
    let x = event.target;
    x.innerHTML++;
}

let p = document.getElementsByTagName("p")[0];
p.addEventListener('click', incremente);