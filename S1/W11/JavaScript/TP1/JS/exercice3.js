let body = document.querySelector("body");
let section = document.createElement('section');
let h1 = document.createElement('h1');
let ul = document.createElement('ul');

body.appendChild(section);
section.appendChild(h1);
section.appendChild(ul);

let li;
for (let i = 1; i <= 3; i++) {
    ul.appendChild(document.createElement('li'));
    li = document.querySelector('ul:last-child');
    li.appendChild(document.createTextNode("element " + i));
}