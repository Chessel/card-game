using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timer : MonoBehaviour {

	//timer
	//reference object fro my timer
	public GameObject timeSlider = null;
	//private int timer 2 minutes to collect at least 3 coins to continue to the next level
	public float timerValue = 120;
	

	
	// Update is called once per frame
	void Update () {
		//upadtes the timer
		//Timer.deltaTime is the nummber of seconds since the last frame
		//About 1/frame rate or 1/60
		
		timerValue -= Time.deltaTime;
		timeSlider.GetComponent<Slider> ().value = timerValue;
		
		if (timeSlider.GetComponent<Slider> ().value <= 3) 
		{
			Application.LoadLevel("GameOver");
			//lives --;
		}
	}
}
