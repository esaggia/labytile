using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float velocityX;
    public float velocityZ;
    
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

       


        if (Input.GetButton("Horizontal"))
        {
            Vector3 movement = new Vector3(velocityX, 0.0f, 0.0f);
            transform.position += movement;


        }
        if (Input.GetButton("Vertical"))
        {
            Vector3 movement = new Vector3(0.0f,0.0f , velocityZ);
            transform.position += movement;

        }

      
	
	}
}
