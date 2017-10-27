using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {


	GameObject player;
	public float speed=0.001f , distance=5.0f;
	private Vector3 velocity = Vector3.zero;


	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");
	}


	void Update () {
	//	Debug.Log ("ODLEGLOSC: "+Vector2.Distance (player.transform.position, transform.position));
		if(Vector2.Distance(player.transform.position,transform.position)<distance){
			transform.position = Vector3.Lerp (transform.position, player.transform.position, speed);
			Debug.Log ("ATAK KURWA");
			}

		
	}

}
