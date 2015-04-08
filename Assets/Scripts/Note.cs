using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	// Use this for initialization
	void Start () {

		transform.position = new Vector2(Random.Range (-5, 5), Random.Range(-5, 5));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
			if (other.CompareTag ("Player")) {
			Debug.Log ("Hit Note");		
		}
	}

}
