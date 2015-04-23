using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour {

	public float songPosition;
	public float deltaSongPosition;
	public float bpm;
	public float beatsPerSecond;
	public Note note;
	public float buffer;
	//public Note[] notes = new Note[6];
	public float timeBetweenBeats;
	public float lastBeat;
	private float songLength;
	private int beatNum;
	private GameObject gc;
	private float[] notePositions = {3.0f, 3.5f, 4.0f, 4.5f, 5.0f, 5.5f, 6.0f, 6.5f, 7.0f};

	// Use this for initialization
	void Start () {
		//beatNum = 0;

		songLength = gameObject.audio.clip.length;
		//timeBetweenBeats = 60.0f / bpm;
		//beatsPerSecond = bpm / 60.0f;
		//gc = GameObject.FindGameObjectWithTag("GameController");
		float metronome = 4.0f;
		int totalBeats = Mathf.RoundToInt ((songLength / .5f) - 4.0f);

		for (int i = 0; i<totalBeats; i++) {
			Note tempNote;
			tempNote = Instantiate(note) as Note;
			bool isRight;
			if( Random.Range (0.0f, 1.0f)<0.5f){
				isRight = true;
			}
			else{
				isRight = false;
			}
			tempNote.SetBeat(metronome, isRight );
			metronome+=.5f;
		
		}
		gameObject.audio.Play ();
		songPosition = (float)AudioSettings.dspTime;
		
		//int totalNotes = Mathf.RoundToInt (songLength / timeBetweenBeats);
		//gc.GetComponent<GameController> ().MakeNotes (totalNotes);
	}

	// Update is called once per frame
	void Update () {
		deltaSongPosition = (float)AudioSettings.dspTime - songPosition;
		//Debug.Log ("Delta Song: " + deltaSongPosition);
		if (deltaSongPosition > lastBeat + timeBetweenBeats) {
			//Debug.Log ("Beat");
			lastBeat += timeBetweenBeats;
						
		}
	
	}


}
