/*
// fichier2.js
import {myFunc, myVar0} from './fichier1.js';
myFunc(); /// output: Wololo
console.log(myVar0); /// output: 0
*/

// fichier2.js
import * as fichier1 from './fichier1.js';
fichier1.myFunc(); /// output: Wololo
console.log(fichier1.myVar0); /// output: 0
