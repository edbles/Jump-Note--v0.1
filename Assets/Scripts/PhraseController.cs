using UnityEngine;
using System.Collections;

public class PhraseController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (0, 0);
		rigidbody2D.AddForce (new Vector2 (-500, 0));
	}
}
