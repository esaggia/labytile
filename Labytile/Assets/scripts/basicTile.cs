using UnityEngine;
using System.Collections;

public class basicTile : MonoBehaviour {

    public int playerViewRange = 1;
    //public Transform player = null;

    public int indexX = 0;
    public int indexZ = 0;

    protected float initialHeight = 0.0f;

 
    // Use this for initialization
    protected virtual void Start()
    {
        //player = FindObjectOfType<Player>().transform; 
        initialHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected float GetPlayerDistance()
    {

        float dist = 0.0f;
       // dist = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(varManager.player.transform.position.x, varManager.player.transform.position.z));

        return dist;
    }
}
