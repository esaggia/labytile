using UnityEngine;
using System.Collections;

public class Portail : MonoBehaviour {
	public GameObject endPortal;
	public Vector3 portalPos;

	// Use this for initialization
	void Start () {

		 
		 GameObject endDoor= (GameObject)Instantiate (endPortal,portalPos,transform.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
