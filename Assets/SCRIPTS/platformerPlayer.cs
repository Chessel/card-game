using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class platformerPlayer : MonoBehaviour {
	
	//MY VARIABLES
	
	//variable for the character's rigidbody
	private Rigidbody2D myRigidbody = null;
	
	//private BoxCollider2D stepRigidbody = null;
	
	//variable to call the spring that triggers the elevators
	// private GameObject springRigidbody = null;
	
	//variable to control the speed the character moves
	public float walkSpeed = 1.5f;
	
	//variable to control the speed the character jumps
	public float jumpSpeed = 10;

	//variable for the health
	public float health = 3;

	//variable for the lives
	public float lives = 3;
		
	//variable to control the velocity
	// private Vector2 myVelocity = Vector2.zero; 
	
	//variable set at the bottom of the character 
	public GameObject foot = null;
	
	//boolean that detrmines if the character is touchin something beneath it or not (floor)
	private bool isGrounded = false;
	
	private int spellCards = 0;

	//door to level 2 opens
	private bool openDoor = false;

	//boolean that determines if the dragon card has been selected
	public bool dragon = false;
	
	//boolean that determines if the tiburon card has been selected
	public bool tiburon = false;
	
	//boolean that determines if the eagle card has been selected
	public bool eagle = false;
	
	//boolean that determines if the wolf card has been selected
	public bool wolf = false;
	
	//boolean that determines if the rooster card has been selected
	public bool rooster = false;


	//variable that set the player score
	public float score = 0;


	//variable to update the score
	public GameObject scoreText = null;
	public GameObject dragonCardReference = null;
	public List<string> spellsList = new List<string>();

	void Awake ()
	{
		print ("I am awake");
		DontDestroyOnLoad(GameObject.FindWithTag("spellCard"));
		DontDestroyOnLoad (GameObject.FindWithTag ("dragonCard"));
	}
	// Use this for initialization
	void Start () 
	{
		myRigidbody = this.GetComponent<Rigidbody2D> ();
		dragonCardReference = GameObject.FindWithTag ("dragonCard");
		dragonCardReference.SetActive(false);
		print (dragonCardReference);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			
			//Don't use zero 0 for velocity.y
			//character moves left
			//keep y the same but go left
			myRigidbody.velocity = new Vector2 (-walkSpeed, myRigidbody.velocity.y);
			
		} 
		else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
		{
			//character moves right
			//keep y the same but go right
			myRigidbody.velocity = new Vector2 (jumpSpeed, myRigidbody.velocity.y);
			
		} 


		// Level 2 spell select


		//1 sets dragon to true
		if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
		{

			dragon = true;
			print ("dragon");
			
			//Destroy (this.gameObject);
		} 
		
		//3 sets tiburon to true
		else if (Input.GetKey(KeyCode.Alpha2)  || Input.GetKey(KeyCode.Keypad2))
		{
			tiburon = true;
			print ("tiburon" + tiburon);
		} 
		
		//1 sets eagle to true
		else if (Input.GetKey(KeyCode.Alpha3)  || Input.GetKey(KeyCode.Keypad3))
		{
			eagle = true;
			print ("eagle" + eagle);
		} 
		
		//1 sets wolf to true
		else if (Input.GetKey(KeyCode.Alpha4)  || Input.GetKey(KeyCode.Keypad4))
		{
			wolf = true;
			print ("wolf" + wolf);
		} 
		
		//1 sets rooster to true
		else if (Input.GetKey(KeyCode.Alpha5)  || Input.GetKey(KeyCode.Keypad5))
		{
			rooster = true;
			print ("rooster" + rooster);
		} 

		// making spells
		//checks if 2 cards have been selected plus Return 
		
		if (tiburon == true && rooster == true && Input.GetKey (KeyCode.Return))
		{
			walkSpeed = 15;
			print(walkSpeed);

		}

		else if (tiburon == true && eagle == true && Input.GetKey (KeyCode.Return))
		{
			myRigidbody.transform.localScale = new Vector3 (.5f, .5f, .5f);
			print ("small scale");
		}

		else if (tiburon == true && dragon == true && Input.GetKey (KeyCode.Return))
		{
			myRigidbody.transform.localScale = new Vector3 (2, 2, 2);
			print ("scale");
		}

		else if (tiburon == true && wolf == true && Input.GetKey (KeyCode.Return))
		{
			lives +=1;
		}

		else if (rooster == true && dragon == true && Input.GetKey (KeyCode.Return))
		{
			jumpSpeed = 7;
			print(jumpSpeed);
		}

		else if (rooster == true && eagle == true && Input.GetKey (KeyCode.Return))
		{
			myRigidbody.gravityScale = 0; 
			print( myRigidbody.gravityScale);
		}

		else if (rooster == true && wolf == true && Input.GetKey (KeyCode.Return))
		{
			walkSpeed = 1; 
		}

		
		else if (eagle == true && dragon == true && Input.GetKey (KeyCode.Return))
		{
			health += 3;
		}

		else if (eagle == true && wolf == true && Input.GetKey (KeyCode.Return))
		{
			health -= 3;
		}

		else if (dragon == true && wolf == true && Input.GetKey (KeyCode.Return))
		{
			lives -=1;
		}

		//the spell cards taken on level 1 enable te spell cards on level 2 

//		if (score == 300) 
//		{
//			GameObject.Find("dragon").active = true;
//			GameObject.Find("tiburon").active = true;
//			GameObject.Find("eagle").active = true;
//			GameObject.Find("wolf").active = false;
//			GameObject.Find("rooster").active = false;
//
//		}

		
		if (isGrounded == true) 
		{
			
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




	} //Update
	
	void OnCollisionEnter2D(Collision2D coll) {
		//checks the player hits a spell card
		if (coll.gameObject.tag == "spellCard") 
		{
			spellsList.Add (coll.gameObject.name);
			//destroys the spellCard and the counter spellCards increases by one everytime the player collects a card
			Destroy (coll.gameObject);
			spellCards ++;
			score += 100;
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


		if(coll.gameObject.name == "enemy")
		{
			if(health >= 1)
			{
				health--;
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
				print (lives);
			}

		}
		print (health);

	} //OnCollissionEnter2D


	void OnTriggerStay2D()
	{
		if (openDoor == true && Input.GetKey(KeyCode.O))
		{
			Application.LoadLevel("level2");
			foreach( string x in spellsList) {
				print ( x + "Card" );
				if (x + "Card" == "dragonCard")
				{
				  print ("I am in the if statement");
				  dragonCardReference = GameObject.FindWithTag ("dragonCard");
				  dragonCardReference.SetActive(true);
				}
			}
		}
	} //OnTriggerStay2D()


		

} //MonoBehaviour
