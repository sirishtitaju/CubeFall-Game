using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour {

	public GameObject starPrefab;
	public float SpawnTime;
	public float min_X = -2f, max_X = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnStars ();
	}
	void SpawnStars()
	{	
		
		Vector3 temp = transform.position;
		temp.x = Random.Range(min_X,max_X);

		GameObject newPlatform = null;
		newPlatform = Instantiate(starPrefab,temp,Quaternion.identity);
		newPlatform.transform.parent  = transform;
	}
	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "destroy") {
			Destroy (gameObject);
			print ("Hello");
		}
		print ("HelloOutside");
	}
}
