// author: Kellian GOFFIC       19/02/2021

import * as THREE from './three.js-master/build/three.module.js'

export default class Sun {

    #mesh;
    #diameter = 1.391980; //mkm
    #axis_angle = 7.25;  //°
    #rotation_period = 25.6; //days equatorial region (latitude = 0°)

    constructor( scene ) {
        this.mesh = this.mesh_creator();
        scene.add(this.mesh);
    }

    mesh_creator() {
        var sphere = new THREE.Mesh(
            new THREE.SphereGeometry(this.#diameter,20,20),
            new THREE.MeshLambertMaterial({
                color: "#f9d71c",
                side: THREE.FrontSide,
                emissive: 0xfdfbd3
            })
        );
        
        sphere.position.set(0,0,0);
        return sphere;
    }

}