using UnityEngine;
using System.Collections;

public class TouchInputController : MonoBehaviour {
	/**This class will receive all TouchInput from the screen and move it to the correct Script.
	 */

	//private float width;
	//private float height;
	//private float laneHeight;
	// Use this for initialization
	float laneOne = 3.8f;
	float laneTwo = 1.0f;
	float laneThree = -1.5f;
	float laneFour = -4.0f;


	GameObject cond;

	void Start () {

		cond = GameObject.FindGameObjectWithTag ("Conductor");
	//	width = Screen.width;
		//height = Screen.height;
		//laneHeight = height / 3;


	
	}
	
	// Update is called once per frame
	void Update () {

		/**check the lane and the song position of a touch maybe this should be in the note script
		 */

		for(int i = 0; i<Input.touchCount; i++){
			if(Input.GetTouch(i).phase == TouchPhase.Began){
				Vector2 touchPos = Input.GetTouch(i).position;
				Debug.Log ("Touch Pos: "+touchPos+"Conductor:" + cond.GetComponent<Conductor>().songPosition);
				//CheckTouch(Conductor.GetComponent<Conductor>().songPosition, 
			}
		}


	}


	void CheckTouch(float tapTime, int screenZone){
		/**
		GameObject[] notes = GameObject.FindGameObjectsWithTag ("Note");

		foreach (GameObject note in notes) {
						if (note.GetComponent<Note> ().isActive) {
								note.GetComponent<Note>().CheckTap(tapTime, screenZone);
						}
		}*/
		}
}