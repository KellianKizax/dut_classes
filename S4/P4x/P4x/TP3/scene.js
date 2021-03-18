import * as THREE from './three.js-master/build/three.module.js';
import * as dat from './three.js-master/examples/jsm/libs/dat.gui.module.js';
import * as objl from './three.js-master/examples/jsm/loaders/OBJLoader.js';
import * as Orbit from './three.js-master/examples/jsm/controls/OrbitControls.js';

import Sun from './sun.js';


var W = 1650;
var H = 928;

var container = document.querySelector('#threejsContainer');

var scene, camera, renderer, controls;



function init() {

    // === Init Scene =========================================================
    
    scene = new THREE.Scene();
        
    camera = new THREE.PerspectiveCamera(80, W / H, 0.1, 1000);
    camera.lookAt( 0, 0, 0 );
    scene.add(camera);
        
    renderer = new THREE.WebGLRenderer();
    renderer.setSize(W, H);
    container.appendChild(renderer.domElement);


	// ====================================================

    // repère des axes
    const axesHelper = new THREE.AxesHelper( 5 );
    scene.add(axesHelper);


	// ======================================================
	// === GUI

    var gui = new dat.GUI();

    var gui_time = gui.addFolder('System Time');

	var parameters = {
		acceleration: 1,
        deceleration: 1
	};

    var gui_time_ac = gui_time.add( parameters, 'acceleration' ).min(1).max(1000).step(1).listen();
    var gui_time_dec = gui_time.add( parameters, 'deceleration' ).min(0).max(1).step(0.1).listen();
        
    gui_time_ac.onChange( function(value) {
        parameters.deceleration = 1;
        parameters.acceleration = value;
     } );

    gui_time_dec.onChange( function(value) {
        parameters.acceleration = 1;
        parameters.deceleration = value;
    } );

    gui_time.open();


    // === OrbitControls ======================================================
        
    controls = new Orbit.OrbitControls( camera, renderer.domElement );
    camera.position.set( 10, 3, 10 );
    controls.update();


    // === Planets ============================================================

    let sun = new Sun(scene);
}




function animate() { //a compléter        
        requestAnimationFrame(animate);
        renderer.render(scene, camera);
        controls.update();
}




init();
animate();
