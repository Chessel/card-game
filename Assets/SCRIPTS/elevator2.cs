using UnityEngine;
using System.Collections;

public class elevator2 : MonoBehaviour {

	public float walkSpeed = 2;				// speed
	public float wallCheckDistance = 0.5f;	// how far to check for a wall so you can turn around
	public int direction = 1;				// -1 = left, 1 = right
	public GameObject player;

	public platformerPlayer pp;

	void Start()
	{
		GameObject player = GameObject.FindWithTag ("Player");
		// platformerPlayer pp = player.GetComponent<platformerPlayer>();
		// walk at a rate of walkSpeed in the direction indicated by the variable
		this.GetComponent<Rigidbody> ().velocity = new Vector2 (walkSpeed * direction, 0);
	}
	
	void Update()
	{

		// Draw a line to the right for debugging.
		Debug.DrawLine (this.transform.position, this.transform.position + (Vector3.up * direction * wallCheckDistance));
		
		// Cast an invisible line to the right and see if you hit anything.
		RaycastHit2D hit = Physics2D.Raycast (this.transform.position, Vector2.up * direction, wallCheckDistance);
		
		// if the raycast hits something, turn around
		if(hit.collider != null)
		{
			direction *= -1;									// change from left to right or vice-versa
			this.GetComponent<Rigidbody> ().velocity *= -1;			// reverse velocity
			this.transform.localScale = new Vector3(1, direction, 1);	// face the other direction
		}
	}

//	void OnTriggerEnter2D(Collider2D trigger)
//	{
//		print ("trigger hit");
//		pp.SubtractHealth();
//
//	} 
	
	// A custom function for killing the enemy,
	// You have to pass in both the enemy GameObject and the enemy's head GameObject.
	void reduceHealth(GameObject elevator, GameObject playerHead)
	{
		
	}

}
