using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

	[HideInInspector]
	public Vector3 destination;
	[HideInInspector]
	public float particleLifeTime;

	void Start() {
		Invoke ("DestroyMissile", particleLifeTime);
	}

	void FixedUpdate () {
		gameObject.transform.position = Vector3.MoveTowards (
			gameObject.transform.position,
			destination,
			0.1f);
		if (gameObject.transform.localScale.x > 0.3f) {
			gameObject.transform.localScale -= new Vector3 (0.003f, 0.003f, 0.003f);
		}
	}

	void DestroyMissile() {
		Destroy (gameObject.GetComponent<CircleCollider2D> ());

		gameObject.GetComponent<ParticleSystem> ().Play ();
		gameObject.GetComponent<ParticleSystem> ().Emit(50);
		gameObject.GetComponent<ParticleSystem> ().Stop ();

		gameObject.GetComponent<SpriteRenderer> ().sprite = null;

		Destroy (gameObject, gameObject.GetComponent<ParticleSystem>().main.startLifetime.constant);
	}

}
