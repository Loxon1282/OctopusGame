using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMisleParticles : MonoBehaviour {

	ParticleSystem part = new ParticleSystem();

	// Use this for initialization
	void Start () {
		part = this.GetComponent<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
			part.Emit (10);
			Invoke ("DestroyThisObject", (float)part.main.startLifetime.constant);
		}
	}
	void DestroyThisObject() {
		Destroy (this.gameObject);
	}
}
