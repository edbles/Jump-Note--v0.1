using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour {

	public float songPosition;
	public float deltaSongPosition;
	public float bpm;
	public Note note;
	public float buffer = 0.5f;
	//public Note[] notes = new Note[6];
	public float timeBetweenBeats;
	public float lastBeat;
	private float songLength;
	private int beatNum;
	private GameObject gc;
	private float[] notePositions = {0.28f, .84f, 1.80f, 2.87f, 4.0f, 4.95f};

	// Use this for initialization
	void Start () {
		//beatNum = 0;

		songLength = gameObject.audio.clip.length;
		timeBetweenBeats = 60.0f / bpm;
		//gc = GameObject.FindGameObjectWithTag("GameController");
		for (int i = 0; i<notePositions.Length; i++) {
			Note tempNote;
			tempNote = Instantiate(note) as Note;
			tempNote.SetBeat(notePositions[i]);
		
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
