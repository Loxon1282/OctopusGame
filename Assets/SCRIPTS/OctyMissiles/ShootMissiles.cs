using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissiles : MonoBehaviour {

	public GameObject missile;
	public GameObject crosshair;
	public float particleLifeTime;

	void Update() {
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			GameObject missileTemp = Instantiate (missile) as GameObject;

			missileTemp.GetComponent<MissileController> ().destination = crosshair.transform.position;
			missileTemp.GetComponent<MissileController> ().particleLifeTime = particleLifeTime;

			missileTemp.transform.position = this.transform.position;

		}
	}

}
