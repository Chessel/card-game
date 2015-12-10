using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spellCards : MonoBehaviour {


	//variables to assign a ceach spellCard  to a Game object
	public GameObject dragonCardReference;
	public GameObject roosterCardReference;
	public GameObject tiburonCardReference;
	public GameObject eagleCardReference;
	public GameObject wolfCardReference;

	// Use this for initialization
	void Start () {
		// Find the player.  Get the platformPlayer component.  Use that to look at the list inside of the player
		GameObject player = GameObject.FindWithTag ("Player");
		platformerPlayer pp = player.GetComponent<platformerPlayer>();


		// print ("level2 loaded");
		dragonCardReference = GameObject.FindWithTag ("dragonCard");
		//tiburonCardReference = GameObject.FindWithTag ("tiburonCard");
		//roosterCardReference = GameObject.FindWithTag ("roosterCard");
		//wolfCardReference = GameObject.FindWithTag ("wolfCard");
		//eagleCardReference = GameObject.FindWithTag ("eagleCard");

		GameObject.FindWithTag("tiburonCard").SetActive (false);
		//tiburonCardReference.SetActive (false);
		roosterCardReference.SetActive (false);
		wolfCardReference.SetActive (false);
		eagleCardReference.SetActive (false);
		dragonCardReference.SetActive (false);
		
		foreach (string x in pp.spellsList) {
			print (x + "Card");
			
			if (x == "dragon") {
				dragonCardReference.SetActive (true);
			} else if (x == "tiburon") {
				tiburonCardReference.SetActive (true);
			} else if (x == "rooster") {
				roosterCardReference.SetActive (true);
			} else if (x == "eagle") {
				eagleCardReference.SetActive (true);
			} else if (x == "wolf") {
				wolfCardReference.SetActive (true);
			}	
		} //foreach loop
			
	
	}//void Start

}//MonoBehaivour
