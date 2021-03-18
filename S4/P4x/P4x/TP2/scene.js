import * as THREE from './three.js-master/build/three.module.js'
import * as dat from './three.js-master/examples/jsm/libs/dat.gui.module.js';
import * as objl from './three.js-master/examples/jsm/loaders/OBJLoader.js'
import * as Orbit from './three.js-master/examples/jsm/controls/OrbitControls.js'

// import { OrbitControls } from './three.js-master/examples/jsm/controls/OrbitControls.js';

var W = 1000;
var H = 700;

var container = document.querySelector('#threejsContainer');

var scene, camera, renderer, controls;

function init() {        
        scene = new THREE.Scene();
        
        camera = new THREE.PerspectiveCamera(75, W / H, 0.1, 1000);
        camera.lookAt( 0, 0, 0 );
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

        function move_elt( elt, x, y, z ) {
            elt.position.set( x, y, z );
        }

        var cube = {
            elt: generate_rubikscube(),
            x: 10,
            y: 0,
            z: 0,
        };

        move_elt( cube.elt, cube.x, cube.y, cube.z );

        scene.add( cube.elt );


	// ======================================================
	// === GUI

        

        var gui = new dat.GUI();

		// ===========
		// Cube

        var gui_cube = gui.addFolder('Cube Position');

		var parameters = {
			x: cube.x,
			y: cube.y,
			z: cube.z,
		};

        var gui_cube_x = gui_cube.add( parameters, 'x' ).min(-50).max(50).step(0.5).listen();
        var gui_cube_y = gui_cube.add( parameters, 'y' ).min(-50).max(50).step(0.5).listen();
        var gui_cube_z = gui_cube.add( parameters, 'z' ).min(-50).max(50).step(0.5).listen();
        
        gui_cube_x.onChange( function(value) {
            cube.x = value;
            move_elt( cube.elt, cube.x, cube.y, cube.z );
        } );

        gui_cube_y.onChange( function(value) {
            cube.y = value;
            move_elt( cube.elt, cube.x, cube.y, cube.z );
        } );
        
        gui_cube_z.onChange( function(value) {
            cube.z = value;
            move_elt( cube.elt, cube.x, cube.y, cube.z );
        } );

        gui_cube.open();

        // ==========================================================
        // === Floor

        var floor = new THREE.Mesh(
                new THREE.BoxGeometry(100,0.1,100),
                new THREE.MeshLambertMaterial({
                        color: 0x6ebf6e,
                        side: THREE.DoubleSide
                }),
        );

        floor.position.set(0,-0.1,0);
        scene.add(floor);

        // ==========================================================
        // === OrbitControls
        
        controls = new Orbit.OrbitControls( camera, renderer.domElement );
        
        //controls.update() must be called after any manual changes to the camera's transform
        camera.position.set( 10, 3, 10 );
        controls.update();


        // ===========================================================
        // ===========================================================
        // ===========================================================

        // TP2


        // ===========================================================
        // OBJLoader

        
        // instantiate a loader
        const loader = new objl.OBJLoader();

        /*
		loader.load(
			// the ressource to load
			'./cow.obj',
			function( object ) {
                object.position.set(0,0,5);
                let box = new THREE.BoxHelper( object, 0xffff00 );
                let cow = object.children[0];
                let bbox = cow.geometry.boundingBox;
                
                let v = new THREE.Vector3();
                bbox.getSize(v);

                object.scale.y = 1 / v.y;
                object.scale.x = (v.x / v.y) / v.x;
                object.scale.z = (v.z / v.y) / v.z;

                box.update();
                scene.add(object);
				scene.add(box);
			}
		);
        */

        function import_obj( name_file, height, position, rotateX, rotateY, rotateZ ) {
            loader.load(
                name_file,
                function( object ) {
                    let child = object.children[0];
                    
                    child.position.set(position.x, position.y, position.z);
                    
                    let box = new THREE.BoxHelper( child, 0xffff00 );
                    let bbox = child.geometry.boundingBox;

                    let v = new THREE.Vector3();
                    bbox.getSize(v);
                    
                    child.scale.y = height / v.y;
                    child.scale.x = ((v.x*height) / v.y) / v.x;
                    child.scale.z = ((v.z*height) / v.y) / v.z;
                    
                    child.rotateX(rotateX);
                    child.rotateY(rotateY);
                    child.rotateZ(rotateZ);

                    box.update();

                    scene.add(child);
                    scene.add(box);
                }
            )
        }

        import_obj("./bear.obj", 1, new THREE.Vector3(3,0,-3), 3*Math.PI/2, 0, 0);
        import_obj("./cow.obj", 1, new THREE.Vector3(-3,0,3), 0, 3*Math.PI/2, 0);
        import_obj("./bunny.obj", 1, new THREE.Vector3(3,0,3), 0, 0, 0);


        // ===========================================================
        // ===========================================================
        // ===========================================================

        

}

function animate() { //a compléter        
        requestAnimationFrame(animate);
        renderer.render(scene, camera);
        controls.update();
}


init();
animate();
