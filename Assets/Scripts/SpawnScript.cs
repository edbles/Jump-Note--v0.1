using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	//collection of objects to spawn
	public GameObject[] obj;
	//we're going to randomly spawn between 1 second (1f) and 2 seconds (2f)
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	
	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	void Spawn()
	{
		Instantiate (obj[Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
		
	}
	}
//Random.Range (0, obj.Length)