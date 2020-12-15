function Clickincr(event){
  let p = event.target;
  let nbr = p.innerHTML;
  event.preventDefault();
  nbr++;
  p.innerHTML = nbr;
}

let p = document.getElementsByTagName("p")[0];
p.addEventListener('click', Clickincr);
