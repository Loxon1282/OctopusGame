using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleComponent : MonoBehaviour {

	public float missileLifeTime;

	public Vector3 customCrosshairPos;

	void Awake() {
		Invoke ("DestroyMissile", missileLifeTime);
	}

	void FixedUpdate () {
		this.transform.position = Vector3.MoveTowards (this.transform.position,
			customCrosshairPos, 0.04f);
		if(this.transform.localScale.x > 0.3f)
			this.transform.localScale -= new Vector3 (0.0005f, 0.0005f, 0);
	}

	void DestroyMissile() {
		Destroy (GetComponent<CircleCollider2D>());
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		this.gameObject.GetComponent<ParticleSystem> ().Emit (10);
		Destroy (this.gameObject, this.gameObject.GetComponent<ParticleSystem> ().main.startLifetime.constant);
	}
}
