using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class platformerPlayer : MonoBehaviour {
	
	//MY VARIABLES
	
	//variable for the character's rigidbody
	private Rigidbody2D myRigidbody = null;
	
	//variable to control the speed the character moves
	public float walkSpeed = 1.5f;
	
	//variable to control the speed the character jumps
	public float jumpSpeed = 8;

	//variable to change the characters direction (left/right)
	private int direction = 1;

	//variable for the health
	public int health = 3;

	//variable for the lives
	public float lives = 3;
	
	//variable set at the bottom of the character 
	public GameObject foot = null;
	
	//boolean that detrmines if the character is touchin something beneath it or not (floor)
	private bool isGrounded = false;

	//variable that serves as a counter to know haw many  spell cards the player collected on level 1
	private int spellCards = 0;

	//door to level 2 opens
	private bool openDoor = false;

	//variable that set the player score
	public float score = 0;

	//variable to update the score
	public GameObject scoreText = null;

	//Variable for the Press O to open Door
	public GameObject pressO;

	//variables to assign a ceach spellCard  to a Game object
	public GameObject dragonCardReference;
	public GameObject roosterCardReference;
	public GameObject tiburonCardReference;
	public GameObject eagleCardReference;
	public GameObject wolfCardReference;

	//makes a List of the spellCArds that have been collected
	public List<string> spellsList = new List<string>();

	//makes a List of the spellCArds that had been selected by keypad input
	public List<string> selectedSpellsList = new List<string>();

	public void SubtractHealth() {
		health--;
		print ("subtract");
	}

	void Awake ()
	{
		DontDestroyOnLoad (GameObject.FindWithTag ("spellCard"));
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		myRigidbody = this.GetComponent<Rigidbody2D> ();
		pressO.SetActive (false);

	}

	// Update is called once per frame
	void Update () 
	{

		
		//character movement controls
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			//Don't use zero 0 for velocity.y
			//character moves left
			//keep y the same but go left
			myRigidbody.velocity = new Vector2 (-walkSpeed, myRigidbody.velocity.y);								// change from left to right or vice-versa

			this.transform.localScale = new Vector3(-direction, 1, 1);// face the other direction
			
		} 
		else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
		{
			//character moves right
			//keep y the same but go right
			myRigidbody.velocity = new Vector2 (walkSpeed, myRigidbody.velocity.y);								// change from left to right or vice-versa
			this.transform.localScale = new Vector3(direction, 1, 1);	// face the other direction

			
		} 
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) 
		{
			//character moves down
			//keep y the same but go right
			myRigidbody.velocity = new Vector2 (walkSpeed, -myRigidbody.velocity.x);
			
		} 
		
		
		// check if there's something below the character
		if (isGrounded == true) 
		{
			// jump			
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space)) 
			{
				//character jumps pressing keys W, up arrpw and space bar
				//keep x the same but go jump
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpSpeed);
			}
		}
		
		//Draws a line from the foot downward slighly.
		Debug.DrawLine (foot.transform.position, foot.transform.position + new Vector3 (0, -0.1f, 0));
		
		RaycastHit2D hit = Physics2D.Raycast(foot.transform.position, -Vector2.up, 0.1f);
		
		//this checks if there is something underneath the character
		if (hit.collider == null) 
		{
			//hit nothing
			isGrounded = false;
		} else
		{
			//hit something
			isGrounded = true;
		}

		// Level 2 spell select

		//1 sets dragon to true
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
			
			//dragon = true;
			//print ("dragon" + dragon);
			//add the name of the object to the spellList list
			selectedSpellsList.Add (GameObject.FindWithTag("dragonCard").gameObject.name);
			if(selectedSpellsList.Count > 2)
			{
				GameObject.FindWithTag (selectedSpellsList[0]).GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
				selectedSpellsList.Remove (selectedSpellsList[0]);

			}
			
			//Destroy (this.gameObject);
		} 
		
		//3 sets tiburon to true
		else if (Input.GetKeyDown(KeyCode.Alpha2)  || Input.GetKeyDown(KeyCode.Keypad2))
		{
			//tiburon = true;
			//print ("tiburon" + tiburon);

			//add the name of the object to the spellList list
			selectedSpellsList.Add (GameObject.FindWithTag("tiburonCard").gameObject.name);
			if(selectedSpellsList.Count > 2)
			{
				GameObject.FindWithTag (selectedSpellsList[0]).GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
				selectedSpellsList.Remove (selectedSpellsList[0]);

			}

		} 
		
		//1 sets eagle to true
		else if (Input.GetKeyDown(KeyCode.Alpha3)  || Input.GetKeyDown(KeyCode.Keypad3))
		{
			//eagle = true;
			//print ("eagle" + eagle);
			//add the name of the object to the spellList list
			selectedSpellsList.Add (GameObject.FindWithTag("eagleCard").gameObject.name);
			if(selectedSpellsList.Count > 2)
			{
				GameObject.FindWithTag (selectedSpellsList[0]).GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
				selectedSpellsList.Remove (selectedSpellsList[0]);

			}
					
		} 
		
		//1 sets wolf to true
		else if (Input.GetKeyDown(KeyCode.Alpha4)  || Input.GetKeyDown(KeyCode.Keypad4))
		{
			//wolf = true;
			//print ("wolf" + wolf);
			//add the name of the object to the spellList list
			selectedSpellsList.Add (GameObject.FindWithTag("wolfCard").gameObject.name);
			if(selectedSpellsList.Count > 2)
			{
				GameObject.FindWithTag (selectedSpellsList[0]).GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
				selectedSpellsList.Remove (selectedSpellsList[0]);

			}
			
		} 
		
		//1 adds rooster to selectSpellList which will set it to true
		else if (Input.GetKeyDown(KeyCode.Alpha5)  || Input.GetKeyDown(KeyCode.Keypad5))
		{
			//rooster = true;
			//print ("rooster" + rooster);
			//add the name of the object to the spellList list
			selectedSpellsList.Add (GameObject.FindWithTag("roosterCard").gameObject.name);
			if(selectedSpellsList.Count > 2)
			{
				GameObject.FindWithTag (selectedSpellsList[0]).GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
				selectedSpellsList.Remove (selectedSpellsList[0]);
			}
			
			
		} 


		//sets the spell booleans to true if the string is in the list
		foreach (string x in selectedSpellsList) 
		{

			GameObject.FindWithTag (x).GetComponent<SpriteRenderer>().color = new Color (0, 1, 1, 1);

		}

		//make the spells. select two cards an press enter
		//checks if the player has press Enter or Return
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter))
		
		//checks if two GameObject names are added to the spellCardList
		if (selectedSpellsList.Contains ("roosterCard") && selectedSpellsList.Contains ("eagleCard")) {
			myRigidbody.gravityScale = 0; 
			print ("gravity" + myRigidbody.gravityScale);
		} else if (selectedSpellsList.Contains ("roosterCard") && selectedSpellsList.Contains ("wolfCard")) {
			walkSpeed = 1;
			print ("walkSpeed" + walkSpeed);
		} else if (selectedSpellsList.Contains ("roosterCard") && selectedSpellsList.Contains ("dragonCard")) {
			jumpSpeed = 7;
			print ("jumpSpeed" + jumpSpeed);
		} else if (selectedSpellsList.Contains ("eagleCard") && selectedSpellsList.Contains ("wolfCard")) {
			health -= 3;
			print ("health" + health);
		} else if (selectedSpellsList.Contains ("eagleCard") && selectedSpellsList.Contains ("dragonCard")) {
			health += 3;
			print ("health" + health);
		} else if (selectedSpellsList.Contains ("dragonCard") && selectedSpellsList.Contains ("wolfCard")) {
			lives -= 1;
			print ("lives" + lives);
		} else if (selectedSpellsList.Contains ("tiburonCard") && selectedSpellsList.Contains ("eagleCard")) {
			myRigidbody.transform.localScale = new Vector3 (.5f, .5f, .5f);
			print ("small scale: " + myRigidbody.transform.localScale);
		} else if (selectedSpellsList.Contains ("tiburonCard") && selectedSpellsList.Contains ("dragonCard")) {
			myRigidbody.transform.localScale = new Vector3 (2, 2, 2);
			print ("scale:" + myRigidbody.transform.localScale);
		}else if (selectedSpellsList.Contains ("tiburonCard") && selectedSpellsList.Contains ("wolfCard")) {
			lives += 1;
			print ("lives:" + lives);
		}else if (selectedSpellsList.Contains ("tiburonCard") && selectedSpellsList.Contains ("roosterCard")) {
			walkSpeed = 15;
			print ("walkSpeed" + walkSpeed);
		}


	} //Update
	
	void OnCollisionEnter2D(Collision2D coll) {
		//checks the player hits a spell card on level 1
		if (coll.gameObject.tag == "spellCard") 
		{
			//add the name of the object to the spellList list
			spellsList.Add (coll.gameObject.name);
			print (spellsList);
			//destroys the spellCard and the counter spellCards increases by one everytime the player collects a card
			Destroy (coll.gameObject);
			spellCards++;
			score += 100;
			if (spellCards == 5) {
				{
					lives += 1;
				}
			}
			print (coll.gameObject.name + " added. Score = " + score);
			scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
		}


		//checks if the player has collected three or more spellCards
		if (spellCards >= 3)
		{
			//door cahnged color
			GameObject.FindWithTag ("door").GetComponent<SpriteRenderer>().color = new Color (0, 1, 1, 1);
			//The door now Canvas Behaviour opened
			openDoor = true;

		}


	} //OnCollissionEnter2D

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.tag == "elevatorBottom")
		{
			print ("elevator hit");
			if(health >= 1)
			{
				SubtractHealth();
			}else if(health < 1)
			{
				
				if(lives >= 1)
				{
					lives--;
					
				}else if(lives < 1)
				{
					lives--;
					Destroy(this.gameObject);
					Application.LoadLevel("GameOver");
					print ("Game Over!");
				}		
				// print (lives);
			}
			
		}
		print (lives + " lives " + health + " health");
	}// OnTriggerEnter2D



	void OnTriggerStay2D()
	{
		//shows text if openDoor has24 been set to true
		if (openDoor == true)
		{
			pressO.SetActive (true);
		}
		if (openDoor == true && Input.GetKey(KeyCode.O))
		{
		Application.LoadLevel("level2");
		}

	} //OnTriggerStay2D()


		

} //MonoBehaviour
