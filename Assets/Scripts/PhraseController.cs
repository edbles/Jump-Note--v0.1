using UnityEngine;
using System.Collections;

public class PhraseController : MonoBehaviour {


	/**This class will spawn, activate and just generally control phrases
	 * */

	public GameObject conductor;
	public ArrayList phrases = new ArrayList();
	public Phrase samplePhrase;

	private float timeStamp;
	private bool spawnPhrasesComplete;
	private GameObject[] noteCatchers;
	private float songLength;


	// Use this for initialization
	void Start () {

		conductor = GameObject.FindGameObjectWithTag ("Conductor");

	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool SpawnPhrases(float songL){
		noteCatchers = GameObject.FindGameObjectsWithTag ("NoteCatcher");
		songLength = songL;

		//This should change to a collection of the appopriate timeStamps for the song
		timeStamp = 4.0f;


		//Build the first 50 notes of the song
		for (int i = 0; i<25; i++) {
			SpawnNextNote();
		}

		return true;
	}

	/*This function builds the next note int he song. It currently assigns a random notePattern and 
	 * and predermined .5f second increment to it, but this should become a Queue
	 * */
	public void SpawnNextNote(){

		//Build the next note in the song
		//This will need to change for a real level to a stack of notes or possibly 2?
		if(timeStamp<songLength){
			Phrase tempPhrase = Instantiate(samplePhrase) as Phrase;
			int noteCatcherNum = 0;
		
			noteCatcherNum = Mathf.RoundToInt(Random.Range (0.0f, 1.0f));
		
		
			float tempNoteC = noteCatchers[noteCatcherNum].GetComponent<NoteCatcher>().transform.position.x;
			int notePattern = Mathf.RoundToInt(Random.Range(1.0f, 7.4f));
			tempPhrase.SetUp(notePattern, timeStamp, tempNoteC);
			phrases.Add (tempPhrase);
			timeStamp+=.5f;

		}
	}
}
 