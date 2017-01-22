using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {
	 public int nmeIndexX = 0;
    public int nmeIndexZ = 0;
    public GameObject player;


	
	void Start()
	{
	
	

		
	}
	void OnTriggerStay(Collider coll)
	 {
        if(coll.gameObject.CompareTag("Tile"))  
        {	
        	
        	basicTile tile = coll.gameObject.GetComponent<basicTile>();
			if (tile != null)
        	{
        		Debug.Log(tile.indexX + " " + tile.indexZ);
           		nmeIndexX  = tile.indexX;
            	nmeIndexZ = tile.indexZ;
               
        	}
        }
     }
	void Update ()
	 {
        // transform.Rotate(Vector3.down * 2);


        // basicTile tile =LevelGenerator.GetTileWithIndex(nmeIndexX, nmeIndexZ); CHANGER METH EN STATIC PUBLIC 
        //if (tile.transform.position.y==-30)
        //{
        //    Vector3 playerpos=player.transform.position;
        //    Vector3 start=transform.position;
        //    Vector3 direction=playerpos-start;
        //    Vector3 facing=transform.TransformDirection(Vector3.forward)*10;
        //    Debug.DrawRay(start ,facing,Color.red);



        //     RaycastHit hit;
        //   if (Physics.Raycast(start,facing, out hit,10))  
        //    {


        //        if (player==hit.collider.gameObject )
        //       {
        //           print("changedir");
        //           transform.TransformDirection(player.transform.position);
        //           transform.Rotate(new Vector3(0,0,0));


        //       }
        //      else
        //       {   
        //          print("backtoroutine");


        //        }
        //    }
        //}

	 	

     
     }

           
}
