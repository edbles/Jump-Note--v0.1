using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	int score = 0;

	void Start () {
				score = PlayerPrefs.GetInt ("Score");
		}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");

		GUI.Label (new Rect (Screen.width / 2 - 40, 200, 80, 30), "Score: " + score);
		if(GUI.Button(new Rect(Screen.width / 2 - 40, 250, 70, 30), "Try Again"))
		{
			Application.LoadLevel(0);
		}
		if(GUI.Button(new Rect(Screen.width / 2 - -40, 250, 60, 30), "X"))
		{
			Application.LoadLevel(2);
		}
	}
	
}
