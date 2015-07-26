using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {
		
	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "Jump Note");

		if(GUI.Button(new Rect(Screen.width / 2 - 30, 250, 60, 30), "Play"))
		{
			Application.LoadLevel(1);
		}

	}
	
}