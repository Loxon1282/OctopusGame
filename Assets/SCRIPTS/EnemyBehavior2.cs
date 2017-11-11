using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior2 : MonoBehaviour {
	
	public float smoothTime = 0.3F;
	private float yVelocity = 0.0F;
	Vector2 randPos;

	private Vector3 _startPosition;

	
	// Use this for initialization
	void Start () {
		randPos = Random.insideUnitCircle * 30;
		InvokeRepeating ("PositionRandomizing", 1, 3);
		_startPosition = transform.position;
		InvokeRepeating ("startPosChanging", 1, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {

		float newPositionX = Mathf.SmoothDamp(transform.position.y, randPos.y, ref yVelocity, smoothTime);
		float newPositionY = Mathf.SmoothDamp (transform.position.x, randPos.x, ref yVelocity, smoothTime);
		transform.position = new Vector3(newPositionY, Mathf.Sin(Time.time), transform.position.z);

		Vector3 moveDirection = gameObject.transform.position - _startPosition; 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
		}

		
	}
	void PositionRandomizing(){
		randPos = Random.insideUnitCircle * 30;
			
	}
	void startPosChanging(){
		_startPosition = transform.position;
	}
}
