using UnityEngine;
using System.Collections;

//This is inefficient.
public class Note : MonoBehaviour {

	HUDScript hud;
	private bool isRight=true;
	private float buffer;

	private Vector2 endPos;
	private Vector2 startPos;
	private Vector2 distance;
	private GameObject conductor;
	public float beatNumber;
	private float beatTimePos;
	private float direction;
	private string activationKey;
	private float crotchet;

	public string activateLeft;
	public string activateRight;

	private GameObject player;
	//private float tolerance = .5f;
	private float tBB;
	private bool isLaunched;

	public void SetBeat(float beatTime, bool leftOrRight){

		beatTimePos = beatTime;
		isRight = leftOrRight;
			
			
		if (isRight) {
			direction = -1.0f;
			activationKey = activateRight;
			player = GameObject.FindWithTag ("PlayerR");
			}
		else {
			direction = 1.0f;
			activationKey = activateLeft;
			player = GameObject.FindWithTag("PlayerL");
			}

		startPos = new Vector2 (direction*-15.0f, 1.0f);

		gameObject.transform.position = startPos;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		conductor = GameObject.FindWithTag ("Conductor");
		crotchet = conductor.GetComponent<Conductor>().bpm/60.0f;
		buffer = conductor.GetComponent<Conductor> ().buffer;
		}



	void Update(){
	
		float testPos = conductor.GetComponent<Conductor> ().deltaSongPosition;

	
		float playerX = player.GetComponent<PlatformerCharacter2D> ().transform.position.x;
		endPos = new Vector2(playerX, gameObject.transform.position.y);
		float xSpeed = direction * Mathf.Abs(((startPos.x - endPos.x) / crotchet));


		if ((testPos > beatTimePos-(crotchet)) && (testPos < beatTimePos-(crotchet) + buffer)) {
			rigidbody2D.velocity = new Vector2(xSpeed, 0.0f);
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
						 
			}

		if (Input.GetKeyDown (activationKey)) {
			float keyStrikeTime = conductor.GetComponent<Conductor>().deltaSongPosition;
			//player.GetComponent<PlatformerCharacter2D>().Move (0.0f, false, true);
			CheckTime(keyStrikeTime);

		} 

	}



	public void CheckTime(float tapTime){

		//Debug.Log ("TapTime:" + tapTime + "Beat Time" + beatTimePos + "buffer:" + buffer);
		float withinBuffer = Mathf.Abs (beatTimePos - tapTime);

		if (withinBuffer < buffer) {
						Debug.Log ("Notes time Position:" + beatTimePos + "Key Strike Time:" + tapTime);
						GameObject hudScript = GameObject.FindWithTag ("HUD");
						hudScript.GetComponent<HUDScript> ().IncreaseScore (1);
						//gameObject.GetComponent <SpriteRenderer>().color = Color.yellow;
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
