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
	public float songLength;


	AudioSource[] tracks;
	private GameObject phraseController;
	private int beatNum;
	private GameObject gc;
	//private float[] notePositions = {3.0f, 3.5f, 4.0f, 4.5f, 5.0f, 5.5f, 6.0f, 6.5f, 7.0f};

	// Use this for initialization
	void Start () {

		tracks = gameObject.GetComponents<AudioSource> ();
		songLength = tracks[0].clip.length;

	

		phraseController = GameObject.FindGameObjectWithTag ("PhraseController");

		//Spawns the first 50 phrases and then starts the song playing
		//bool phrasesSpawned = phraseController.GetComponent<PhraseController> ().SpawnPhrases (songLength);


		//StartTracks ();


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

	public void StartTracks(){
			//put code in here to start all three tracks at the same time
		foreach (AudioSource track in tracks){
			track.Play ();

		}
		songPosition = (float)AudioSettings.dspTime;
	
	}

	public void SetTrackMuteState(int trackNum, bool notePlayed){
		tracks [trackNum].mute = !notePlayed;


	}






}
