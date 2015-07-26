using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float leftPlayerPercentTotal = 0f;
	int leftCount = 0;
	float leftPlayerScore = 0f;

	int rightCount =0;
	float rightPlayerScore = 0f;
	float rightPlayerPercentTotal = 0f;

	Text guiText;
	string scoreString;

	void Start(){

		guiText = GetComponent<Text> ();
		scoreString = guiText.text;

	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text =""+ leftPlayerScore + "%\t\t\t" + rightPlayerScore + "%"; 
		//playerScore += Time.deltaTime;
	}
	public void IncreaseScore(float amount, bool isLeft)
	{
		if (isLeft) {	
						leftCount++;
						leftPlayerPercentTotal += amount;
						leftPlayerScore = Mathf.Round (leftPlayerPercentTotal/leftCount);
				} else {
						rightCount++;
						rightPlayerPercentTotal +=amount;
						rightPlayerScore = Mathf.Round (rightPlayerPercentTotal/rightCount);
				}
	}


}
