using UnityEngine;
using System.Collections;
using System;

public class PhraseController : MonoBehaviour {


	/**This class will spawn, activate and just generally control phrases
	 * */


	/** make two objects one for each track list and then edit the code in 
	 * the spawn next note function to spawn off of those two lists.
	 * 
	 * */


	/**Creates a basic object to store the 
	 * */
	public class PhraseBlock:IComparable{
		public float TimeStamp{ get; set;}
		public int NotePattern{ get; set; }
		public int NoteCatcherNumber{ get; set; }
		public string ToString(){
			return "\n" + TimeStamp + " " + NotePattern + " " + NoteCatcherNumber;
		}
		int IComparable.CompareTo(object obj)
		{
			PhraseBlock pb=(PhraseBlock)obj;
			if (this.TimeStamp > pb.TimeStamp) {
								return 1;
						} else if (this.TimeStamp == pb.TimeStamp) {
								return 0;
						} else{
								return -1;
						}
			
		}
		public PhraseBlock(float timeStamp, int notePattern, int noteCatcherNum){
			TimeStamp = timeStamp;
			NotePattern = notePattern;
			NoteCatcherNumber = noteCatcherNum;

		}
	}

	public TextAsset leftScoreSheet;
	public TextAsset rightScoreSheet;
	public string scoreDirectory;
	public GameObject conductor;
	public ArrayList phrases = new ArrayList();
	public Phrase samplePhrase;

	private bool canSpawnNotes = true;
	private ArrayList notesTimePatternCatcherArray = new ArrayList();
	private IEnumerator e;
	private float timeStamp;
	private bool spawnPhrasesComplete;
	private GameObject[] noteCatchers;
	private float songLength;


	// Use this for initialization
	void Start () {

		conductor = GameObject.FindGameObjectWithTag ("Conductor");

		bool fileRead = readFile (leftScoreSheet, 0);
		bool fileRead2 = readFile (rightScoreSheet, 1);

		/**
		foreach (PhraseBlock pb in notesTimePatternCatcherArray) {
			Debug.Log ("\n"+pb+" ");

		}*/

		notesTimePatternCatcherArray.Sort ();
		e = notesTimePatternCatcherArray.GetEnumerator ();
	
		bool phrasesSpawned = SpawnPhrases ();
		/**
		foreach (PhraseBlock pb in notesTimePatternCatcherArray) {
			Debug.Log ("\n"+pb.TimeStamp+" "+pb.NotePattern+" " +pb.NoteCatcherNumber);
			
		}*/

		//conductor.GetComponent<Conductor> ().StartTracks ();


		//innsert some sort of all clear for the conductor class to start the music and timer etc.

	
	}
	
	// Update is called once per frame
	void Update () {

	}

	private bool readFile(TextAsset scoreSheet, int tempNoteCatchNum){

		float tempTimeStamp;
		int tempNotePattern;
		//Debug.Log ("Filename:" + fileName);
		int count = 1;

		//Debug.Log ("FILENAME:" +scoreSheet);
		string[] linesFromFile = scoreSheet.text.Split ("\n" [0]);
		foreach (string line in linesFromFile){
			count++;
			int tLoc = line.IndexOf("T:")+2;
			int sLoc = line.IndexOf (":S");
			string timeS = line.Substring(tLoc, sLoc-tLoc);
			//Debug.Log ("\n"+timeS);
			tempTimeStamp = float.Parse(timeS);
			//Debug.Log ("timestamp post parse:" + tempTimeStamp);
			int nLoc = line.IndexOf("N:")+2;
			int pLoc = line.IndexOf(":P");
			//Debug.Log ("Line" + count+ "nLoc: " + nLoc +"pLoc" + "pLoc");
			string noteP = line.Substring(nLoc, pLoc-nLoc);
			//Debug.Log (" "+noteP);
			tempNotePattern = int.Parse(noteP);
			//Debug.Log("TempPattern:" +tempNotePattern);
			PhraseBlock pb = new PhraseBlock(tempTimeStamp, tempNotePattern, tempNoteCatchNum);

			notesTimePatternCatcherArray.Add(pb);

			//Debug.Log (pb.TimeStamp+" "+pb.NoteCatcherNumber+"\n");

		}

		return true;

	}

	public bool SpawnPhrases(){
		noteCatchers = GameObject.FindGameObjectsWithTag ("NoteCatcher");
		//Build the first 25 notes of the song
		//while(e.MoveNext()){


		for(int i = 0; i<25; i++){
			SpawnNextNote ();
		}

		conductor.GetComponent<Conductor> ().StartTracks ();

		return true;
	}

	/*This function builds the next note int he song. It currently assigns a random notePattern and 
	 * and predermined .5f second increment to it, but this should become a Queue
	 * */


	public void SpawnNextNote(){
	

			if (e.MoveNext ()) {
				
						PhraseBlock pb = (PhraseBlock)e.Current;

						Phrase tempPhrase = Instantiate (samplePhrase) as Phrase;
						float tempNoteC = noteCatchers [pb.NoteCatcherNumber].GetComponent<NoteCatcher> ().transform.position.x;
						//int notePattern = Mathf.RoundToInt(UnityEngine.Random.Range(1.0f, 7.4f));
						int spriteNum = pb.NotePattern - 1;
						tempPhrase.SetUp (pb.NotePattern, pb.TimeStamp, tempNoteC, spriteNum);
						phrases.Add (tempPhrase);
				}
	}



	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Static") {
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndLevel();

				
		}
	}
}
 