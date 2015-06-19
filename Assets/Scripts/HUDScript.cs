using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 0;
	Text guiText;
	string scoreString;

	void Start(){

		guiText = GetComponent<Text> ();
		scoreString = guiText.text;

	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = scoreString + ": " + playerScore;
		//playerScore += Time.deltaTime;
	}
	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}


}
