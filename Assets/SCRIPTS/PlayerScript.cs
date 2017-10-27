using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	float currentDirection,distance;
	int direction = 1;
	float slow = 100.0f;
	Rigidbody2D cialo;

	public float maxSpeed = 0.2f;


	void Start(){
		cialo = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update(){
		CalculatePositions ();
		float currentDistanceA, currentDistanceB, currentSpeed;
		currentDistanceA = Mathf.Abs(currentDirection - this.transform.eulerAngles.z);
		currentDistanceB = 360 - currentDistanceA;
		currentSpeed = (currentDistanceA >= currentDistanceB) ? currentDistanceB : currentDistanceA;
		//this.transform.rotation=(Quaternion.Euler(0, 0, direction * currentSpeed * 15f * Time.fixedDeltaTime));
		this.transform.Rotate(new Vector3(0, 0, direction * currentSpeed * 0.6f * Time.fixedDeltaTime));
		if (Input.GetMouseButton (0)) {
			if(cialo.velocity.magnitude < maxSpeed)
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2((Input.mousePosition.x - Screen.width / 2)/slow, (Input.mousePosition.y - Screen.height / 2)/slow));
		}

		if(cialo.velocity.magnitude > maxSpeed)
		{
			cialo.velocity = cialo.velocity.normalized * maxSpeed;
		}
	}


	
	public void CalculatePositions()
	{
	Vector2 zeroMouse = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2 + 40);
	float angle = Vector2.SignedAngle(Vector2.up, zeroMouse);
	currentDirection = (angle < 0) ? Mathf.Round(360-Mathf.Abs(angle)) : Mathf.Round(angle);
	//	Debug.Log (currentDirection);
		CalculateDistance();
	}
	public void CalculateDistance()
	{
		distance = currentDirection - this.transform.eulerAngles.z;
		if (Mathf.Abs(distance) < 180 && Mathf.Sign(distance) == -1)
		{
			direction = -1;
		}
		else if (Mathf.Abs(distance) > 180 && Mathf.Sign(distance) == 1)
		{
			direction = -1;
		}
		else
		{
			direction = 1;
		}
	}

}