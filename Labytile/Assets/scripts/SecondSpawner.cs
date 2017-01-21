using UnityEngine;
using System.Collections;

public class SecondSpawner : MonoBehaviour {
	public GameObject endPortal;
	public Vector3 portalPos;

	public GameObject nme;
	public Vector3 nmePos;

	// Use this for initialization
	void Start () {
	 GameObject endDoor= (GameObject)Instantiate (endPortal,portalPos,transform.rotation);
	  GameObject nmeClone= (GameObject)Instantiate (nme,nmePos,transform.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
