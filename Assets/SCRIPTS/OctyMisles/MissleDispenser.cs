using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDispenser : MonoBehaviour {

	public GameObject misslePrefab;
	public GameObject crosshair;

	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			GameObject newMisle = Instantiate (misslePrefab);
			newMisle.transform.position = this.transform.position;
			newMisle.GetComponent<MissleComponent> ().customCrosshairPos = crosshair.transform.position;
			newMisle = null;
		}
	}
}
