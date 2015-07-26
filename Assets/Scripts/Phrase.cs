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



	float phrasePercentage;
	private float crotchet;
	//private Vector2 endPos;
	private float buffer;
	//private int audioClipNum;
	private static int[] lanes = {1, 2, 3};

	/**
	private static int laneTwo = 2;
	private static int laneThree = 3;
*/
		
	// Use this for initialization
	void Start () {

		conductor = GameObject.FindWithTag ("Conductor");
		crotchet = conductor.GetComponent<Conductor>().bpm/60.0f;
		buffer = conductor.GetComponent<Conductor>().buffer;
		aC = GetComponent<AudioClip> ();
		//Debug.Log ("Buffer: " + buffer);
	

	
	}


	/**Sets up the phrase with the appropriate notes and timestamp and screenZone
	 * */
	public void SetUp(int noteP, float timeS, float noteCP, int spriteNum){
		noteCatchPos = noteCP;
		timeStamp = timeS;
		notePattern = noteP;
		bool[] isNegativeNote = {true, true, true};
		Note[] tempNotes = {null, null, null};

		/**
		foreach (Note n in tempNotes) {
			n = (Note)Instantiate (sampleNote) as Note;
		}*/


		if (noteCatchPos < this.transform.position.x) {
			modifier = 0;
		}

	

		if (notePattern == 1 || notePattern == 4 || notePattern == 6 || notePattern == 7) {
						isNegativeNote [0] = false;
				}
		if (notePattern == 2 || notePattern == 4 || notePattern == 5 || notePattern == 7) {
			isNegativeNote[1] = false;

			} 
		if (notePattern == 3 || notePattern == 5 || notePattern == 6 || notePattern == 7) {
			isNegativeNote[2] = false;
			}


		for (int i = 0; i<3; i++) {
			tempNotes [i] = (Note) Instantiate (sampleNote) as Note;
			tempNotes [i].SetUp (timeStamp, lanes [i] + modifier, spriteNum, isNegativeNote [i]);
			tempNotes [i].transform.parent = gameObject.transform;
			notes.Add (tempNotes [i]);
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

		int count = 0;
		float tapPercentage = 0.0f;

				foreach (Note note in notes) {
						if(note!= null){
							if (!note.isPlayedAccurate) {
									phrasePlayed = false;
									break;
							}
							count++;
							tapPercentage += note.tapPercentage;
						}
			
				}

				if (phrasePlayed) {
						phrasePercentage = Mathf.Round (tapPercentage/count);						
						SelfDestruct(phrasePlayed);
						
				}
				
		}

	public void SelfDestruct(bool wasPlayed){

		bool isLeft = noteCatchPos < 0;
		//check if the note is being removed because it was succesfully captured by a player
		if (wasPlayed) {
						
						GameObject phraseC = GameObject.FindGameObjectWithTag ("PhraseController");
						phraseC.GetComponent<PhraseController> ().SpawnNextNote ();


				} 
		GameObject hudScript = GameObject.FindWithTag ("HUD");
		hudScript.GetComponent<HUDScript> ().IncreaseScore (phrasePercentage, isLeft);
		//check if the note was assigned to move right on the screen
		if(modifier==3){


			conductor.GetComponent<Conductor>().SetTrackMuteState(2, wasPlayed);
		}
		//otherwise if the note was assigned to move left
		else{
			conductor.GetComponent<Conductor>().SetTrackMuteState(1, wasPlayed);
		
		}


		Destroy (gameObject);
	}




}
