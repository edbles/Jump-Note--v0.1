using UnityEngine;
using System.Collections;

//This is inefficient.
public class PowerupScript : MonoBehaviour {

	HUDScript hud;
	public Vector2 speed;

	void OnTriggerEnter2D(Collider2D other)//increase the score whenever the player collects the power up
	{
		if(other.tag == "Player")//if the player collected the powerup look for the main character get the HUD script then destroy the powerup
		{
			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(10);
			Destroy (this.gameObject);
		}
	}

	void Start(){
		rigidbody2D.velocity = speed;

	}

}
