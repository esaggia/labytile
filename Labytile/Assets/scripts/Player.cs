using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float velocityX;
    public float velocityZ;

    public int indexX = 0;
    public int indexZ = 0;
    
	// Use this for initialization
	void Start () 
    {

	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
     if( Input.GetKey( KeyCode.RightArrow ) )
        {
        Vector3 movementR = new Vector3(velocityX,0.0f ,0.0f);
        transform.position += movementR;

        varManager.FindPlayerIndex();
        } 
        else if (Input.GetKey( KeyCode.LeftArrow ))
        {
        Vector3 movementL = new Vector3(velocityX,0.0f ,0.0f );
        transform.position -= movementL;

        varManager.FindPlayerIndex();
        }
 
        if (Input.GetKey( KeyCode.DownArrow ))
        {   
            Vector3 movementR = new Vector3(0.0f,0.0f , velocityZ);
            transform.position -= movementR;

            varManager.FindPlayerIndex();
        }
         else   if (Input.GetKey( KeyCode.UpArrow ))
         { 
            Vector3 movementL = new Vector3(0.0f,0.0f , velocityZ);
            transform.position += movementL;

            varManager.FindPlayerIndex();
         }

        
	}
}
