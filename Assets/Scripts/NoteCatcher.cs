using UnityEngine;
using System.Collections;

public class NoteCatcher : MonoBehaviour {


	private float moveModifier = 1.0f;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		if (this.transform.position.x < 0) {
			moveModifier = -1.0f;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/**If the noteCatcher enters the phrase spawner ends the level
	 * */
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("PhraseController")){
			Debug.Log ("END OF LEVEL!!!");
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndLevel();
		}
	}


}
