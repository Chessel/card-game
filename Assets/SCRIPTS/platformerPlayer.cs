using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class platformerPlayer : MonoBehaviour {
	
	//MY VARIABLES
	
	//variable for the character's rigidbody
	private Rigidbody2D myRigidbody = null;
	
	//private BoxCollider2D stepRigidbody = null;
	
	//variable to call the spring that triggers the elevators
	private GameObject springRigidbody = null;
	
	//variable to control the speed the character moves
	public float walkSpeed = 3;
	
	//variable to control the speed the character jumps
	public float jumpSpeed = 10;
	
	
	//variable to control the velocity
	private Vector2 myVelocity = Vector2.zero; 
	
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

	
	
	
	
	// Use this for initialization
	void Start () 
	{
		myRigidbody = this.GetComponent<Rigidbody2D> ();

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
		
		if (isGrounded == true) 
		{
			
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space)) 
			{
				//character jumps pressing keys W, up arrpw and space bar
				//keep x the same but go jump
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpSpeed);
			}
		}

		//the user selectes the cards that he want by pressing on 1, 2, 3, 4, or 5

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

			//destroys the spellCard and the counter spellCards increases by one everytime the player collects a card
			Destroy (coll.gameObject);
			spellCards ++;
		}


		//checks if the player has collected three or more spellCards
		if (spellCards >= 3)
		{
			//door cahnged color
			GameObject.FindWithTag ("door").GetComponent<SpriteRenderer>().color = new Color (0, 1, 1, 1);
			//The door now Canvas Behaviour opened
			openDoor = true;

		}

		if (coll.gameObject.tag == "spellCard")
		{

			if (gameObject.name == ("dargon"))
			//The door now Canvas Behaviour opened
				{
					dragon = true;
				print (dragon);
				}
			
		}

	} //OnCollissionEnter2D


	void OnTriggerStay2D()
	{
		if (openDoor == true && Input.GetKey(KeyCode.O))
		{
			Application.LoadLevel("level2");
		}
	} //OnTriggerStay2D()


		

} //MonoBehaviour
