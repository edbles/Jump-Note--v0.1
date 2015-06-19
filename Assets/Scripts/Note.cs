using UnityEngine;
using System.Collections;

//This is inefficient.
public class Note : MonoBehaviour {
	/** Note should habe a time stamp and and array of three bools indicating whether a lane must be active
	 * 
	 * */


	public bool played;
	private float timeStamp;

	private Vector2 endPos;
	private Vector2 startPos;
	private Vector2 distance;
	public bool isActive = false;

	private int screenZone;

	public static float laneOne = 2.5f;
	public static float laneTwo = 0.0f;
	public static float laneThree = -3.0f;
	private float buffer;
	
	

	public void SetUp(float beatTime, int screenZ){
		GameObject cond = GameObject.FindGameObjectWithTag ("Conductor");
		buffer = cond.GetComponent<Conductor>().buffer;


		screenZone = screenZ;
		timeStamp = beatTime;
		startPos = new Vector2(0.0f , 0.0f);
		played = false;
		float angle = 0.0f;

		if (screenZone < 4) {
			angle = 180.0f;
		}

		switch (screenZone) {

				case 1:
				case 4: 
						startPos = new Vector2 (0.0f, laneOne);
						this.transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle);
						break;
				case 2:
				case 5:
						startPos = new Vector2 (0.0f, laneTwo);
						this.transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle);
						break;
				case 3:
				case 6: 
						startPos = new Vector2 (0.0f, laneThree);
						this.transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle);
						break;
				default:
						break;
		}


			
		gameObject.transform.position = startPos;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		}



	void Update(){
	
 

	}

	/*Turns the notes sprite renderer on so that it is visible to the player
	 **/
	public void SetActive(){
		if (!isActive) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			isActive = true;
		}
	}



	/**Check a tap to see if it applies to this note
	 * */
	public void CheckTap(float tapTime, int screenZ){


		if (screenZ != screenZone) {
						return;
			} 
		else {
			//Debug.Log ("TapTime: " + tapTime + " Beat Time " + timeStamp + " buffer: " + buffer);
			float withinBuffer = Mathf.Abs (timeStamp - tapTime);

			if (withinBuffer < buffer) {
				//Debug.Log ("Notes time Position:" + timeStamp + "Key Strike Time:" + tapTime);
				//anim.Play(played);
				played = true;
				//GameObject phrase = this.transform.parent;
				GameObject phrase = this.transform.parent.gameObject;
				phrase.GetComponent<Phrase>().CheckNotes();
							
						}
				}
	}

}
