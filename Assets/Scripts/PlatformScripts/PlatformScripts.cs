using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour {

	public float move_Speed = 2f;
	public float bound_Y = 6f;
	public bool moving_Platform_left,moving_Platform_right,is_Breakable,is_Spike,is_Platform;
	private Animator anim;

	 void Awake() {
		if(is_Breakable)
		{
			anim = GetComponent<Animator>();
		}
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
	void BreakableDeactivate()
	{	
		Invoke("DeactivateGameObject",0.2f);
	}
	void DeactivateGameObject()
	{
		SoundManager.instance.IceBreakSound();
		gameObject.SetActive(false);
	}
	void OnTriggerEnter2D(Collider2D target) {
		if(target.tag == "Player")
		{
			if(is_Spike)
			{
				target.transform.position = new Vector2(100f,100f);
				SoundManager.instance.GameOverSound();
				GameManager.instance.RestartGame();
				ScoreScript.scoreValue--;

			}
		}
	}
	 void OnCollisionEnter2D(Collision2D target) {
		if(target.gameObject.tag == "Player")
		{
			if(is_Breakable)
			{
				ScoreScript.scoreValue++;
				SoundManager.instance.LandSound();
				anim.Play("Break");
			}
				if(is_Platform)
			{
				SoundManager.instance.LandSound();
				ScoreScript.scoreValue++;
			}
			if(moving_Platform_left)
			{
				
				ScoreScript.scoreValue++;
			}
			if(moving_Platform_right)
			{
				ScoreScript.scoreValue++;
			}
		}
	}//onCollisionEnter
	void OnCollisionStay2D(Collision2D target) {
		if(target.gameObject.tag == "Player")
		{
			if(moving_Platform_left)
			{
				target.gameObject.GetComponent<PlayerScript>().PlatformMove(-2f);
				SoundManager.instance.LandSound();
			}
			if(moving_Platform_right)
			{
				target.gameObject.GetComponent<PlayerScript>().PlatformMove(2f);
				SoundManager.instance.LandSound();
			}
		}
	}
}
