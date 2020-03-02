using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

	public float move_Speed = 3f;
	static int count = 0;
	 void Awake() {
	}
	// Update is called once per frame
	void Update () {
		Move();
	}
    	void Move()
	{
		Vector2 temp = transform.position;
		temp.y += move_Speed * Time.deltaTime;
		transform.position = temp;
	}
}
