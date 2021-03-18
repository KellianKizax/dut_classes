import * as THREE from './three.js-master/build/three.module.js'
import * as dat from './three.js-master/examples/jsm/libs/dat.gui.module.js';

// import { OrbitControls } from './three.js-master/examples/jsm/controls/OrbitControls.js';

var W = 1000;
var H = 700;

var container = document.querySelector('#threejsContainer');

var scene, camera, renderer;

function init() {        
        scene = new THREE.Scene();
        
        camera = new THREE.PerspectiveCamera(75, W / H, 0.1, 1000);
        camera.position.set(40, 10, 40);
        camera.lookAt( 20, 0, 20 );
        scene.add(camera);
        
        renderer = new THREE.WebGLRenderer();
        renderer.setSize(W, H);
        container.appendChild(renderer.domElement);

	// ====================================================

        // repère des axes
        const axesHelper = new THREE.AxesHelper( 5 );
        scene.add(axesHelper);
        
        // sphere d'origine
        var sphere = new THREE.Mesh(
                new THREE.SphereGeometry(1,20,20),
		new THREE.MeshLambertMaterial({
			color: "#FFFFFF",
			side: THREE.DoubleSide
		})
        );
        scene.add(sphere);
        
        // === Spheres sur les trois différents axes =========================================
        // axe X
        var sphereX = new THREE.Mesh(
                new THREE.SphereGeometry(1, 20, 20),
		new THREE.MeshLambertMaterial({
			color: "#FF2D00",
			side: THREE.DoubleSide
		})
        );
        scene.add(sphereX);
        sphereX.position.set( 20, 0, 0 );

        // axe Y
        var sphereY = new THREE.Mesh(
                new THREE.SphereGeometry(1, 20, 20),
		new THREE.MeshLambertMaterial({
			color: "#28FF00",
			side: THREE.DoubleSide
		})
        );
        scene.add(sphereY);
        sphereY.position.set( 0, 20, 0 );

        // axe Z
        var sphereZ = new THREE.Mesh(
                new THREE.SphereGeometry(1, 20, 20),
		new THREE.MeshLambertMaterial({
			color: "#0008FF",
			side: THREE.DoubleSide
		})
        );
        scene.add(sphereZ);
        sphereZ.position.set( 0, 0, 20 );


        // === Sources de lumière ===================================================
        var spotLight1 = new THREE.SpotLight(0xffffff);
        spotLight1.position.set(100, 100, 100);
        scene.add(spotLight1);


        // =========================================================
        // === Cube generation and movement

        function generate_rubikscube() {
			var cube = new THREE.Mesh(
				new THREE.BoxGeometry(4,4,4),
				new THREE.MeshLambertMaterial({
					color: 0xff0000,
					side: THREE.DoubleSide
				})
			);

			cube.position.set( 0, 0, 0 );
            return cube;
        }

        function move_cube( cube, x, y, z ) {
            cube.position.set( x, y, z );
        }

        var cube = {
            elt: generate_rubikscube(),
            x: 10,
            y: 0,
            z: 0,
        }

        move_cube( cube.elt, cube.x, cube.y, cube.z );

        scene.add( cube.elt );


	// ======================================================
	// === GUI

        var parameters = {
                x: cube.x,
                y: cube.y,
                z: cube.z,
        };

        var gui = new dat.GUI();

        var gui_cube = gui.addFolder('Cube Position');

        var gui_cube_x = gui_cube.add( parameters, 'x' ).min(-100).max(100).step(1).listen();
        var gui_cube_y = gui_cube.add( parameters, 'y' ).min(-100).max(100).step(1).listen();
        var gui_cube_z = gui_cube.add( parameters, 'z' ).min(-100).max(100).step(1).listen();
        
        gui_cube_x.onChange( function(value) {
            cube.x = value;
            move_cube( cube.elt, cube.x, cube.y, cube.z );
        } );

        gui_cube_y.onChange( function(value) {
            cube.y = value;
            move_cube( cube.elt, cube.x, cube.y, cube.z );
        } );
        
        gui_cube_z.onChange( function(value) {
            cube.z = value;
            move_cube( cube.elt, cube.x, cube.y, cube.z );
        } );

        gui_cube.open();

}

function animate() { //a compléter        
        requestAnimationFrame(animate);
        renderer.render(scene, camera);       
}


init();
animate();
