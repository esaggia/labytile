using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float velocity;
  
    public int indexX = 0;
    public int indexZ = 0;

    public int viewRange = 1;
    
	// Use this for initialization
	void Start () 
    {
        Cursor.lockState = CursorLockMode.Locked;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
     if( Input.GetKey( KeyCode.RightArrow ) )
        {
        Vector3 movementR = new Vector3(velocity,0.0f ,0.0f);
        transform.position += movementR;

        varManager.FindPlayerIndex();
        } 
        else if (Input.GetKey( KeyCode.LeftArrow ))
        {
        Vector3 movementL = new Vector3(velocity,0.0f ,0.0f );
        transform.position -= movementL;

        varManager.FindPlayerIndex();
        }
 
        if (Input.GetKey( KeyCode.DownArrow ))
        {   
            Vector3 movementR = new Vector3(0.0f,0.0f , velocity);
            transform.position -= movementR;

            varManager.FindPlayerIndex();
        }
         else   if (Input.GetKey( KeyCode.UpArrow ))
         { 
            Vector3 movementL = new Vector3(0.0f,0.0f , velocity);
            transform.position += movementL;

            varManager.FindPlayerIndex();
         }


        

        
	}
}
