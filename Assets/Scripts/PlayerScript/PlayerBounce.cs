using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour {

	public float min_X= -2.6f, max_X= 2.6f, min_Y= -5.6f;
	private bool Out_Bounds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckBounds();
	}
	void CheckBounds()
	{
		Vector2 temp = transform.position;
		if(temp.x >= max_X)
		temp.x = max_X;
		
		if(temp.x <= min_X)
		temp.x = min_X;
		
		transform.position = temp;

		if(temp.y <= min_Y){
			if(!Out_Bounds)
			{
				Out_Bounds = true;
				SoundManager.instance.DeathSound();
				GameManager.instance.RestartGame();
			}
		}
	}//check bounds
	 void OnTriggerEnter2D(Collider2D target) {
		if(target.tag == "topspike")
		{
			transform.position = new Vector2(100f,100f);
				SoundManager.instance.GameOverSound();
				GameManager.instance.RestartGame();
		}
	}
}
