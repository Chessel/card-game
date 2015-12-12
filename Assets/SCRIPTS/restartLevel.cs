using UnityEngine;
using System.Collections;

public class restartLevel : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey (KeyCode.Return))
		{
			Application.LoadLevel("platformerPlayer");
		}
	}
}
