using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour {

	public int nmeIndexX = 0;
    public int nmeIndexZ = 0;
    public GameObject player;
    public float speed = 20.0f;

    private Vector3 move = Vector3.zero;

	void Start()
	{
        player = varManager.player.gameObject;
	
	}
	void OnTriggerEnter(Collider coll)
	 {

         if (coll.tag == "player")
             SceneManager.LoadScene(0);

        //if(coll.gameObject.CompareTag("Tile"))  
        //{	
        //	basicTile tile = coll.gameObject.GetComponent<basicTile>();
		//	if (tile != null)
        //	{
        //		Debug.Log(tile.indexX + " " + tile.indexZ);
        //   		nmeIndexX  = tile.indexX;
        //    	nmeIndexZ = tile.indexZ;
        //	}
        //}
     }
	void Update ()
	 {
        Vector2 index = varManager.FindEnemyIndex(gameObject);
        nmeIndexX = (int)index.x;
        nmeIndexZ = (int)index.y;

        if (nmeIndexX == varManager.player.indexX)
        {
            //abaisser les tuiles entres
            int higherValue = Mathf.Max(nmeIndexX, varManager.player.indexX);
            int lowerValue = Mathf.Min(nmeIndexX, varManager.player.indexX);

            for (int i = 0; i < varManager.tiles.Length;i++)
            {
                basicTile tile = varManager.tiles[i];
                if (tile.indexX <= higherValue && varManager.tiles[i].indexX >= lowerValue)
                {

                    movingTile movingtile = tile.GetComponent<movingTile>();
                    if (movingtile != null)
                        movingtile.movingState = movingTile.MovingState.eGoingDown;
                }
            }
            move = player.transform.position - transform.position;
            move.Normalize();
        }
        if (nmeIndexZ == varManager.player.indexZ)
        {
            //abaisser les tuiles entres
            int higherValue = Mathf.Max(nmeIndexZ, varManager.player.indexZ);
            int lowerValue = Mathf.Min(nmeIndexZ, varManager.player.indexZ);

            for (int i = 0; i < varManager.tiles.Length; i++)
            {
                basicTile tile = varManager.tiles[i];
                if (tile.indexZ <= higherValue && varManager.tiles[i].indexZ >= lowerValue)
                {

                    movingTile movingtile = tile.GetComponent<movingTile>();
                    if (movingtile != null)
                        movingtile.movingState = movingTile.MovingState.eGoingDown;
                }
            }

            move = player.transform.position - transform.position;
            move.Normalize();
        }

        transform.position += move * speed * Time.deltaTime;

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
