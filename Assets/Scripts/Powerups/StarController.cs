using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {
	public float move_Speed = 3f;
	public float bound_Y = 6f;
	static int count = 0;
	// Use this for initialization
	void Start () {
		
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

		if(temp.y >= bound_Y)
		{
			gameObject.SetActive(false);
		}
	}
}
