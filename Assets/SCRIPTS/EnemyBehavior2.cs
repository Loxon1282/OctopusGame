using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior2 : MonoBehaviour {
	
	public float smoothTime = 0.3F;
	private float yVelocity = 0.0F;
	Vector2 randPos;
	
	// Use this for initialization
	void Start () {
		randPos = Random.insideUnitCircle * 30;
		InvokeRepeating ("PositionRandomizing", 1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		//float newPositionX = Mathf.SmoothDamp(transform.position.y, randPos.y, ref yVelocity, smoothTime);
		float newPositionY = Mathf.SmoothDamp (transform.position.x, randPos.x, ref yVelocity, smoothTime);
		transform.position = new Vector3(newPositionY, transform.position.y, transform.position.z);
		
	}
	void PositionRandomizing(){
		randPos = Random.insideUnitCircle * 30;
	}
}
