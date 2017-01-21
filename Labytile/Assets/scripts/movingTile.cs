using UnityEngine;
using System.Collections;

public class movingTile : basicTile 
{
    public float elevation = 30.0f;
    public float elevationSpeed = 5.0f;

    private bool isElevated = true;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();

	}
	
	// Update is called once per frame
    void Update()
    {
        float dist = GetPlayerDistance();

        if (!isElevated && dist > playerViewRange)
        {
            isElevated = true;
            transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        }
        else if (isElevated && dist < playerViewRange)
        {
            isElevated = false;
            transform.position -= new Vector3(0.0f, elevation, 0.0f);
        }

    }

    IEnumerator MoveTile(bool moveDownWards = false)
    {
        //float startposY = transform.position.y;

        //if (dow)
        yield return null;
    }
}
