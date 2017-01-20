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
       if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) 
        {
        Vector3 movementR = new Vector3(velocityX,0.0f ,0.0f);
        transform.position += movementR;
        } 
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
        Vector3 movementL = new Vector3(velocityX,0.0f ,0.0f );
        transform.position -= movementL;
        }
 
        if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {   
            Vector3 movementR = new Vector3(0.0f,0.0f , velocityZ);
            transform.position -= movementR;
        }
         else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0) 
         { 
            Vector3 movementL = new Vector3(0.0f,0.0f , velocityZ);
            transform.position += movementL;
         }
	}
}
