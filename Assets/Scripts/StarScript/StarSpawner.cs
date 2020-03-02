using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

	public GameObject starPrefab;
	public float min_X = -2f, max_X = 2f;
	public float star_Spawn_Time;
	private float star_Spawn_Count;
	// Use this for initialization
	void Start () {
		star_Spawn_Count = star_Spawn_Time;
	}
	
	// Update is called once per frame
	void Update () {
		SpawnStars ();
	}
	void SpawnStars()
	{	
		star_Spawn_Count+= Time.deltaTime;
		//print("star_spawncount = " + star_Spawn_Count);
		
		Vector3 temp = transform.position;
		temp.x = Random.Range(min_X,max_X);//to bound the spawn x-axis


		if(star_Spawn_Count >= star_Spawn_Time)
		{
			 Instantiate (starPrefab, temp, Quaternion.identity);
			star_Spawn_Count = 0;
		}

	}
}