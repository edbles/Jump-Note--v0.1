using UnityEngine;
using System.Collections;

//This is inefficient.
public class Note : MonoBehaviour {

	HUDScript hud;
	public bool isRight;
	private float buffer;

	private Vector2 endPos;
	private Vector2 startPos;
	private Vector2 distance;
	private GameObject conductor;
	public float beatNumber;
	private float beatTimePos;
	private GameObject player;
	//private float tolerance = .5f;
	private float tBB;
	private bool isLaunched;

	public void SetBeat(float beatTime){

		beatTimePos = beatTime;
		//beatNumber = beatNum;
		startPos = new Vector2(20, 1);
		//distance = new Vector2 (12.5f+beatTimePos,0.0f);
		/*
		if (!isRight) {
			startPos = new Vector2(-20, 1);
			speed.x *= -1;
		}*/

		//transform.position = distance;


		//tBB = conductor.GetComponent<Conductor>().timeBetweenBeats;
		//Debug.Log ("TBB:" + tBB);
		player = GameObject.FindWithTag ("Player");
		endPos = new Vector2 (player.transform.position.x, 1.0f);

		//beatTimePos = tBB * beatNumber;
		//isLaunched = false;
		//Debug.Log ("TBB:" + tBB);
		//float xSpeed = -1.0f *(distance.x-player.transform.position.x)/ tBB;
		//rigidbody2D.velocity = new Vector2(xSpeed, 0.0f);
		
	}



	void Update(){
		conductor = GameObject.FindWithTag ("Conductor");
		float testPos = conductor.GetComponent<Conductor> ().deltaSongPosition;
		//Debug.Log ("Beat Time:" + beatTimePos + "deltaSong" + testPos);
		buffer = conductor.GetComponent<Conductor> ().buffer;
		//Debug.Log (

		if ((testPos > beatTimePos) && (testPos < beatTimePos + buffer)) {
			transform.position = endPos;
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
						//rigidbody2D.velocity = new Vector2(-5.0f, 0.0f);
			} 
		else {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			}

	}



	public void CheckTime(float tapTime){
		if ((tapTime > beatTimePos) && (tapTime < beatTimePos + buffer)) {
			GameObject hudScript = GameObject.FindWithTag("HUD");
			hudScript.GetComponent<HUDScript>().IncreaseScore(1);
			Destroy (gameObject);
		}
	}



	/**
	void FixedUpdate(){

		float moveTime = conductor.GetComponent<Conductor>().timeBetweenBeats;

		//rigidbody2D.MovePosition (transform.position + (speed * moveTime));
	
	}*/
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Static"){
			Destroy(gameObject);
		}
	
	}

}
