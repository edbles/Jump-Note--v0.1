using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	/**This class controls transitions into and out of levels*/

	// Use this for initialization
	void Start () {


	
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}


	/**Called when a player loses or quits a level
	 * */
	public void EndLevel(){
		Debug.Log ("LOSEEEEEER");
		Application.LoadLevel (0);
	}

	//Call if both players sruvive till the end of the song
	public void WinLevel(){
		Debug.Log ("WINNNNERRRRR");
		Application.LoadLevel (0);
	}


}
