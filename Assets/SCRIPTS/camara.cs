using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour {

	public GameObject parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = parent.transform.position + new Vector3 (0, 0, -10);
	}
}
