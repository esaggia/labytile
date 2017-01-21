using UnityEngine;
using System.Collections;

public class movingTile : basicTile 
{
    public float elevation = 30.0f;
    public float elevationSpeed = 1.0f;

    //private bool isElevated = true;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        Debug.Log(initialHeight);
	}
	
	// Update is called once per frame
    void Update()
    {
        int diffX = Mathf.Abs(varManager.player.indexX - indexX);
        int diffZ = Mathf.Abs(varManager.player.indexZ - indexZ);

        if ((diffX <= varManager.player.viewRange && diffZ <= varManager.player.viewRange) || indexX == varManager.player.indexX && indexZ == varManager.player.indexZ)
        {
            //isElevated = false;
            //transform.position = new Vector3(transform.position.x, initialHeight - elevation, transform.position.z);
            StopCoroutine(MoveUpWards());
            StartCoroutine(MoveDownWards());
        }
        else //if (!isElevated && (Mathf.Abs(varManager.player.indexX - indexX) > playerViewRange || Mathf.Abs(varManager.player.indexZ - indexZ) > playerViewRange))
        {
            //isElevated = true;
            StopCoroutine(MoveDownWards());
            StartCoroutine(MoveUpWards());
        }
    }

    IEnumerator MoveDownWards()
    {
        do
        {
            transform.position -= new Vector3(0.0f, elevationSpeed, 0.0f);

            yield return null;
        }
        while (transform.position.y > initialHeight - elevation);

        transform.position = new Vector3(transform.position.x, initialHeight - elevation, transform.position.z);

        yield return null;
    }

    IEnumerator MoveUpWards()
    {
        do
        {
            transform.position += new Vector3(0.0f, elevationSpeed, 0.0f);

            yield return null;
        }
        while (transform.position.y < initialHeight);

        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);

        yield return null;
    }
}
