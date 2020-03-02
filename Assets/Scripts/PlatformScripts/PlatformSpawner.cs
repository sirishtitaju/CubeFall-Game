using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platformPrefab;
	public GameObject spikeplatformPrefab;
	public GameObject [] moving_Platforms;
	public GameObject breakablePrefab;

	public float platform_Spawn_Timer;
	public float current_Platform_Spawn_Timer;

	private int platform_Spawn_Count;

	public float min_X = -2f, max_X = 2f;

	// Use this for initialization
	void Start () {
		current_Platform_Spawn_Timer = platform_Spawn_Timer;
	}
	
	// Update is called once per frame
	void Update () {
		SpawnPlatforms();
	}
	void SpawnPlatforms()
	{
		current_Platform_Spawn_Timer += Time.deltaTime;
		if(current_Platform_Spawn_Timer >= platform_Spawn_Timer)
		{
			platform_Spawn_Count++;

			Vector3 temp = transform.position;
			temp.x = Random.Range(min_X,max_X);

			GameObject newPlatform = null;//temp new game Object

			if(platform_Spawn_Count < 2 )
			{
				newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
			}
			else if(platform_Spawn_Count == 2)
			{
				if(Random.Range(0,2)>0)
				{
					newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
				}
				else
				{
					newPlatform = Instantiate(moving_Platforms[Random.Range(0,moving_Platforms.Length)],temp,Quaternion.identity);
					
				}

			}
			else if(platform_Spawn_Count == 3)
			{
				if(Random.Range(0,2)>0)
				{
					newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
				}
				else
				{
					newPlatform = Instantiate(spikeplatformPrefab,temp,Quaternion.identity);
					
				}
				
			}
					else if(platform_Spawn_Count == 4)
			{
				if(Random.Range(0,2)>0)
				{
					newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
				}
				else
				{
					newPlatform = Instantiate(breakablePrefab,temp,Quaternion.identity);
					
				}
				platform_Spawn_Count = 0;
			}
			newPlatform.transform.parent  = transform;//to not meshUp hierarchy
			current_Platform_Spawn_Timer = 0;
		}//Spawn Platform
	}
}
