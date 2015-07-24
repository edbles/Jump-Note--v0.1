using UnityEngine;
using System.Collections;

public class Static : MonoBehaviour {


	//public GameObject noteCatcher;
	public GameObject phraseController;

	public float missedNotes;

	private float moveOffset;
	private Rigidbody2D rb2D;


	// Use this for initialization
	void Start () {
		rb2D = GetComponent <Rigidbody2D> ();
		float centerOffset = -5.0f; //variable that defines the offset needed to move the static to center
		if (this.transform.position.x < 0) {
			centerOffset*=-1.0f;
			}
		moveOffset = (-1.0f * (this.transform.position.x+centerOffset)) / missedNotes;
		//Debug.Log ("Move Offset: " + moveOffset);
		//noteCatcher.transform = this.transform.GetChild (0);
		phraseController = GameObject.FindGameObjectWithTag ("PhraseController");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MoveStaticIn(){

		rb2D.MovePosition(new Vector2(this.transform.position.x+moveOffset, this.transform.position.y));
		gameObject.GetComponentInChildren<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x+moveOffset, this.transform.position.y));


		
	}


	/*Checks to see if the Static is colliding with a phrase
	 * if it is it destorys the phrase moves the static in and spawns the next note in phrase controller
	*/
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Phrase") {
						other.GetComponent<Phrase>().SelfDestruct(false);
						//Destroy (other.gameObject);
						MoveStaticIn ();
						phraseController.GetComponent<PhraseController>().SpawnNextNote();
				} 
	}




}
