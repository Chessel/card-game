using UnityEngine;
using System.Collections;

public class elevators : MonoBehaviour {

	//variable to call the spring that triggers the elevators
	private BoxCollider2D elevatorRigidbody = null;

	//private bool elevatorMaxHight = false;
	
	//variable to control the speed the elevators move
	public float goesUpSpeed = 0.5f;
	
	//boolean that determines if the elevator shoul move up or not.
	public bool goesUp = true;
	
	//sets the maximum heigh the elevators can go
	private float maxHeight = 3;
	
	//sets the minumin heigh the elevators can go
	private float minHeight = -3.5f;


	
	// Use this for initialization
	void Start () {


		elevatorRigidbody = this.GetComponent<BoxCollider2D>();
		//height = this.elevatorRigidbody.tansform.position.y;


	
	}
	
	// Update is called once per frame
	void Update () {

		float height = 0;

		height = elevatorRigidbody.transform.position.y;

		if (height >= maxHeight) {
			goesUp = false;
			// print("going down now");
		} else if (height <= minHeight) 
		{	
			goesUp = true;
			// print("going up now");
			
		}

		if(goesUp == true)
		{
			//print ("going up");
			elevatorRigidbody.transform.position += Vector3.up * goesUpSpeed * Time.deltaTime;
			elevatorRigidbody.transform.position += Vector3.up * goesUpSpeed * Time.deltaTime;
		} 
		else if(goesUp == false)
		{
			// print ("going down");
			elevatorRigidbody.transform.position += Vector3.down * goesUpSpeed * Time.deltaTime;
			elevatorRigidbody.transform.position += Vector3.down * goesUpSpeed * Time.deltaTime;
		}
			
		
	}
	

} //MonoBehaivour
