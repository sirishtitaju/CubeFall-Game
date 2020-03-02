using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Rigidbody2D myBody;
	public float moveSpeed = 2f;

	private float ScreenWidth;
	
	// Use this for initialization
	void Awake () {
		myBody = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		 foreach (Touch touch in Input.touches) {
   		if (touch.position.x < Screen.width/2) {
     	myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
   		}
   		else if (touch.position.x > Screen.width/2) {
     	myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
   } 
 }
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxisRaw("Horizontal")> 0f)
		{
			myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
		}
		if(Input.GetAxisRaw("Horizontal")< 0f)
		{
			myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
		}//move
	}
	public void PlatformMove(float x)
	{
		myBody.velocity = new Vector2(x,myBody.velocity.y);
	}
}
