using UnityEngine;
using System.Collections;

public class DecimatorScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Application.LoadLevel(1);
			return;
		}
			//if the object has a parent destroy the parent
			if (other.gameObject.transform.parent) 
				{
						Destroy (other.gameObject.transform.parent.gameObject);
				}
			//if it doesn't (have a parent), don't
			else 
			{
			Destroy (other.gameObject);
			}

	}
}