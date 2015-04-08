using UnityEngine;
using System.Collections;

public class PhraseController : MonoBehaviour {
	public Note note;
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnNotes", 1.0f, 1.0f);
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnNotes(){
			Instantiate (note);
	}
}
