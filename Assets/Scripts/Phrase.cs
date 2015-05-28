using UnityEngine;
using System.Collections;

public class Phrase : MonoBehaviour {

	public int modifier = 3;
	public float timeStamp;
	public AudioClip aC;
	public HUDScript hud;
	public GameObject conductor;
	public float noteCatchPos;
	
	public ArrayList notes = new ArrayList();
	public Note sampleNote;
	public int notePattern;




	private float crotchet;
	//private Vector2 endPos;
	private float buffer;
	//private int audioClipNum;
	private static int laneOne = 1;
	private static int laneTwo = 2;
	private static int laneThree = 3;

		
	// Use this for initialization
	void Start () {

		conductor = GameObject.FindWithTag ("Conductor");
		crotchet = conductor.GetComponent<Conductor>().bpm/60.0f;
		buffer = conductor.GetComponent<Conductor> ().buffer;
		aC = GetComponent<AudioClip> ();
	

	
	}


	/**Sets up the phrase with the appropriate notes and timestamp and screenZone
	 * */
	public void SetUp(int noteP, float timeS, float noteCP ){
		noteCatchPos = noteCP;
		timeStamp = timeS;
		notePattern = noteP;

		if (noteCatchPos < this.transform.position.x) {
			modifier = 0;
		}

		if (notePattern == 1 || notePattern == 4 || notePattern == 6 || notePattern == 7) {
			Note tempNote1  = (Note) Instantiate(sampleNote);
			tempNote1.SetUp(timeStamp, laneOne+modifier);
			tempNote1.transform.parent = gameObject.transform;
			notes.Add(tempNote1);
			} 
		if (notePattern == 2 || notePattern == 4 || notePattern == 5 || notePattern == 7) {
							Note tempNote2 = Instantiate(sampleNote) as Note;
							tempNote2.SetUp(timeStamp, laneTwo+modifier);
							tempNote2.transform.parent = gameObject.transform;
							notes.Add (tempNote2);
			} 
		if (notePattern == 3 || notePattern == 5 || notePattern == 6 || notePattern == 7) {
						Note tempNote3 = Instantiate (sampleNote) as Note;
						tempNote3.SetUp(timeStamp, laneThree+modifier);
						tempNote3.transform.parent = gameObject.transform;
						notes.Add (tempNote3);
			}
	}
	
	// Update is called once per frame
	void Update () {
		CalculateSpeed ();
		CheckNotes ();


	
	}


	/**This function checks where we are in the song positiona dn starts the note moving
	 * if we are within the note's crotchet and buffer time period
	 * */
	void CalculateSpeed(){
	
		float testPos = conductor.GetComponent<Conductor> ().deltaSongPosition;
	
		
		
		if ((testPos > timeStamp-(crotchet)) && (testPos < timeStamp-(crotchet) + buffer)) {
			float xSpeed = (noteCatchPos - this.transform.position.x) / crotchet;
			GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, 0.0f);
			foreach (Note note in notes){
				note.SetActive();
			}
		
		}
	}


	/**This function is called when a child note has been played correctly, it checks to see if all of the 
	 * children notes of this phrase have been played and if they have it increments the score.
	 * 
	 * */
	public void CheckNotes(){

		bool phrasePlayed = true;



				foreach (Note note in notes) {
						if(note!= null){
							if (!note.played) {
									phrasePlayed = false;
									break;
							}
						}
			
				}

				if (phrasePlayed) {
						GameObject hudScript = GameObject.FindWithTag ("HUD");
						hudScript.GetComponent<HUDScript> ().IncreaseScore (1);
						//call the conductor and make sure this track is unmuted
						//or volumed up or whatever

				}
				
		}

}
