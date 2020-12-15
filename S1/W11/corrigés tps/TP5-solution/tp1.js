const exos = [];

window.onload = () => {
	exos.forEach((exo, index) => {
		var b = document.createElement('button');
		b.appendChild(document.createTextNode('exo'+(index+1)));
		b.addEventListener('click', exo, false);
		document.body.appendChild(b);
	});
};

exos.push(
	function () {

		const tableau = [];
		for ( let i = 0; i < 10; i++ ) {
			tableau.push(Math.round(Math.random() * 100));
		}

		function tabMax(tab)
		{
			let max = tab[0];
			tab.forEach( function(elem) {
				if ( elem > max ) max = elem;
			});
			// for ( let i=0 ; i<tab.length ; i++ ) {
			// 	if ( tab[i] > max ) max = tab[i];
			// }
			return max;
		}

		function tabMin(tab)
		{
			let min = tab[0];
			tab.forEach( elem => { if ( elem < min ) min = elem; } );
			return min;
		}

		alert(tableau + '\nmin -> ' + tabMin(tableau) + '\nmax -> ' + tabMax(tableau));
	}
);

exos.push(
	function () {
		const date = new Date();

		const h = date.getHours();
		const m = date.getMinutes();
		const s = date.getSeconds();

		const hour = h < 10 ? '0'+h : h;
		// let hour;
		// if ( h<10 )
		// 	hour = '0'+h;
		// else
		// 	hour = h;

		const minutes = m < 10 ? '0'+m : m;
		const secondes = s < 10 ? '0'+s : s;

		alert('Il est ' + hour + ':' + minutes + ':' + secondes);
	}
);

exos.push(
	function () {
		const section = document.createElement('section');

		const h1 = document.createElement('h1');
		h1.appendChild(document.createTextNode('Le grand titre'));
		section.appendChild(h1);

		const ul = document.createElement('ul');
		for (let i = 1; i <= 3; i++) {
			const li = document.createElement('li');
			li.appendChild(document.createTextNode('element ' + i));
			ul.appendChild(li);
		}
		section.appendChild(ul);

		document.getElementsByTagName('body')[0].appendChild(section);
	}
);

exos.push(
	function () {
		// <p>Le paragraphe a été cliqué <span>0</span> fois</p>
		const para = document.createElement('p');
		para.appendChild(document.createTextNode('Le paragraphe a été cliqué '));
		const span = document.createElement('span');
		span.appendChild(document.createTextNode('0'));
		para.appendChild(span);
		para.appendChild(document.createTextNode(' fois'));
		para.addEventListener('click', function() {
			let i = span.innerText;
			i++;
			span.innerText = i;
			// span.innerText++;
		});
		document.getElementsByTagName('body')[0].appendChild(para);
	}
);

exos.push(
	function () {
		function changeColorStyle(event) {
			const elem = event.target;
			if ( elem.style.backgroundColor == "red" )
				elem.style.backgroundColor = 'blue';
			else
				elem.style.backgroundColor = 'red';
		}

		function changeColorClass(event) {
			const elem = event.target;
			if (elem.classList.contains('rouge')) {
				elem.classList.remove('rouge');
				elem.classList.add('blue');
			} else {
				elem.classList.remove('blue');
				elem.classList.add('rouge');
			}
			// elem.classList.toggle('rouge');
			// elem.classList.toggle('blue');
		}

		const para = document.createElement('p');
		para.appendChild(document.createTextNode('Paragraphe avec fond changeant'));

		// para.addEventListener('click', changeColorStyle);
		// para.classList.add('rouge'); // Seulement si utilisation de toggle
		para.addEventListener('click', changeColorClass);

		document.getElementsByTagName('body')[0].appendChild(para);
	}
);

exos.push(
	function () {
		function editParagraph(event) {
			const elem = event.target;

			const section = document.createElement('section');

			const textArea = document.createElement('textarea');
			textArea.value = elem.innerHTML;
			section.appendChild(textArea);

			const button = document.createElement('button');
			button.innerHTML = 'Valider';
			button.addEventListener('click', validateParagraph);
			section.appendChild(button);

			elem.parentNode.insertBefore(section, elem);
			elem.parentNode.removeChild(elem);
		}

		function validateParagraph(event) {
			const elem = event.target;

			const text = elem.previousSibling.value;

			const paragraph = document.createElement('p');
			paragraph.innerHTML = text;
			paragraph.addEventListener('click', editParagraph);

			const section = elem.parentNode;
			section.parentNode.insertBefore(paragraph, section);
			section.parentNode.removeChild(section);
		}

		const paragraph = document.createElement('p');
		paragraph.appendChild(document.createTextNode('Le contenu de ce paragraphe est éditable..'));
		paragraph.addEventListener('click', editParagraph);
		document.getElementsByTagName('body')[0].appendChild(paragraph);
	}
);
