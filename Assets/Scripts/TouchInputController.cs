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

	}
	
	// Update is called once per frame
	void Update () {

		/**check the lane and the song position of a touch maybe this should be in the note script
		 */

		for(int i = 0; i<Input.touchCount; i++){

			Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
			if(Input.GetTouch(i).phase == TouchPhase.Began){

				Vector2 touchPos = Input.GetTouch(i).position;
				RaycastHit2D hitRay2D = Physics2D.Raycast(test, (touchPos));
				float tapTime = cond.GetComponent<Conductor>().deltaSongPosition;
				CheckTouch(tapTime, hitRay2D.point);
				//Debug.Log ("Touch Pos: "+ hitRay2D.point +"Conductor:" + cond.GetComponent<Conductor>().deltaSongPosition);


			}
		}


	}


	void CheckTouch(float tapTime, Vector2 touchPos){

		int screenZone = 0;
		if (touchPos.x > 0) {

			screenZone +=3;
			}

		if (touchPos.y > laneTwo && touchPos.y < laneOne) {
						screenZone++;
				} else if (touchPos.y > laneThree && touchPos.y < laneTwo) {
						screenZone += 2;
				} else if (touchPos.y > laneFour && touchPos.y < laneThree) {
						screenZone +=3;
				}
	

		GameObject[] notes = GameObject.FindGameObjectsWithTag ("Note");

		foreach (GameObject note in notes) {
						if (note.GetComponent<Note> ().isActive) {
								note.GetComponent<Note>().CheckTap(tapTime, screenZone);
						}
		}
		}
}