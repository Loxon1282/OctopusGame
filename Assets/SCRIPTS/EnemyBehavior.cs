using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {


	GameObject player;
	public float speed=0.001f , distance=5.0f;
	public float swimY=1.0f;
	float posX;
	private Vector3 _startPosition;
	public Rigidbody2D rb2D;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		_startPosition = transform.position;
		rb2D = GetComponent<Rigidbody2D>();
	}



	void Update () {
	//	Debug.Log ("ODLEGLOSC: "+Vector2.Distance (player.transform.position, transform.position));


		Debug.Log (rb2D.velocity);
		posX = Mathf.PingPong (Time.time, 60.0f);
		transform.position = _startPosition + new Vector3(posX,Mathf.Sin(Time.time)*swimY, 0.0f);

		Vector3 moveDirection = gameObject.transform.position - _startPosition; 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}


		//ATAKOWANIE Z BLISKA
//		if(Vector2.Distance(player.transform.position,transform.position)<distance){
//			transform.position = Vector3.Lerp (transform.position, player.transform.position, speed);
//			Debug.Log ("ATAK KURWA");
//			}
			
	}	

}
