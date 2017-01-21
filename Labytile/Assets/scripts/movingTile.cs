using UnityEngine;
using System.Collections;

public class movingTile : basicTile 
{
    public float elevation = 30.0f;
    public float elevationSpeed = 5.0f;

    //private bool isElevated = true;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();

	}
	
	// Update is called once per frame
    void Update()
    {
        int diffX = Mathf.Abs(varManager.player.indexX - indexX);
        int diffZ = Mathf.Abs(varManager.player.indexZ - indexZ);

        if ((diffX <= varManager.player.viewRange && diffZ <= varManager.player.viewRange) || indexX == varManager.player.indexX && indexZ == varManager.player.indexZ)
        {
            //isElevated = false;
            transform.position = new Vector3(transform.position.x, initialHeight - elevation, transform.position.z);
        }
        else //if (!isElevated && (Mathf.Abs(varManager.player.indexX - indexX) > playerViewRange || Mathf.Abs(varManager.player.indexZ - indexZ) > playerViewRange))
        {
            //isElevated = true;
            transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        }

    }

    IEnumerator MoveTile(bool moveDownWards = false)
    {
        //float startposY = transform.position.y;

        //if (dow)
        yield return null;
    }
}
