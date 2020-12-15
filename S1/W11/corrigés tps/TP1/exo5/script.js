function ChangeColor(event){
  let body = document.getElementsByTagName("body")[0]
  let nbr = 1;
  event.preventDefault();
  nbr++;
  if (nbr % 2 == 0){
    body.classList.toggle("green");
  }
  else body.classList.toggle("green");
}

let p = document.getElementsByTagName("p")[0];
p.addEventListener('click', ChangeColor);
