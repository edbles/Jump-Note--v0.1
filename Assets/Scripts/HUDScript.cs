using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float leftPlayerScore = 0;
	float rightPlayerScore = 0;
	Text guiText;
	string scoreString;

	void Start(){

		guiText = GetComponent<Text> ();
		scoreString = guiText.text;

	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "P1 Score: " + leftPlayerScore + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" + "P2 Score: " + rightPlayerScore; 
		//playerScore += Time.deltaTime;
	}
	public void IncreaseScore(int amount, bool isLeft)
	{
		if (isLeft) {
						leftPlayerScore += amount;
				} else {
						rightPlayerScore +=amount;
				}
	}


}
