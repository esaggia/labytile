using UnityEngine;
using System.Collections;

public class movingTile : basicTile 
{
    public float elevation = 30.0f;
    public float elevationSpeed = 15.0f;

    //private bool isElevated = true;


    public enum MovingState
    {
        eGoingDown,
        eGoingUp,
        eStayUp,
        eStayDown
    }

    public MovingState movingState = MovingState.eStayUp;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        //Debug.Log(initialHeight);
	}
	
	// Update is called once per frame
    void Update()
    {
        int diffX = Mathf.Abs(varManager.player.indexX - indexX);
        int diffZ = Mathf.Abs(varManager.player.indexZ - indexZ);

        switch (movingState)
        {
            case MovingState.eStayUp:

                SnapToHeight(initialHeight);

                if ((diffX <= varManager.player.viewRange && diffZ <= varManager.player.viewRange))// || indexX == varManager.player.indexX && indexZ == varManager.player.indexZ) // abaisser la tuile
                    movingState = MovingState.eGoingDown;

                break;
            case MovingState.eStayDown:

                SnapToHeight(initialHeight - elevation);

                if ((diffX > varManager.player.viewRange || diffZ > varManager.player.viewRange)) // remonter la tuile
                    movingState = MovingState.eGoingUp;
                break;
            case MovingState.eGoingDown:

                if ((diffX > varManager.player.viewRange || diffZ > varManager.player.viewRange)) // remonter la tuile
                    movingState = MovingState.eGoingUp;

                if (transform.position.y > initialHeight - elevation)
                    transform.position -= new Vector3(0.0f, elevationSpeed * Time.deltaTime, 0.0f);
                else
                    movingState = MovingState.eStayDown;
                break;
            case MovingState.eGoingUp:
                if ((diffX <= varManager.player.viewRange && diffZ <= varManager.player.viewRange))// || indexX == varManager.player.indexX && indexZ == varManager.player.indexZ) // abaisser la tuile
                    movingState = MovingState.eGoingDown;

                if (transform.position.y < initialHeight)
                    transform.position += new Vector3(0.0f, elevationSpeed * Time.deltaTime, 0.0f);
                else
                    movingState = MovingState.eStayUp;

                break;
        }

       // if ((diffX <= varManager.player.viewRange && diffZ <= varManager.player.viewRange) || indexX == varManager.player.indexX && indexZ == varManager.player.indexZ) // abaisser la tuile
       // {
       //     //isElevated = false;
       //     //transform.position = new Vector3(transform.position.x, initialHeight - elevation, transform.position.z);
       //   // StopCoroutine(MoveUpWards(), initialHeight);
       //   // StartCoroutine(SnapToHeight(initialHeight));
       //   //StartCoroutine(MoveDownWards());
       // }
       // else 
       // {
       //     //isElevated = true;
       //     //transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
       //    //StopCoroutine(MoveDownWards());
       //    //StartCoroutine(SnapToHeight(initialHeight - elevation));
       //    //StartCoroutine(MoveUpWards());
       // }
    }

    IEnumerator MoveDownWards()
    {
        //SnapToHeight(initialHeight);

        //yield return null;

        while (transform.position.y > initialHeight - elevation)
        {
            transform.position -= new Vector3(0.0f, elevationSpeed, 0.0f);

            yield return null;
        }

        SnapToHeight(initialHeight - elevation);

        yield return null;
    }

    IEnumerator MoveUpWards()
    {
        //SnapToHeight(initialHeight - elevation);

        //yield return null;

        while (transform.position.y < initialHeight)
        {
            transform.position += new Vector3(0.0f, elevationSpeed, 0.0f);

            yield return null;
        }

        SnapToHeight(initialHeight);

        yield return null;
    }

    void SnapToHeight(float height)
    {
        //if (transform.position.y != height)
            transform.position = new Vector3(transform.position.x, height, transform.position.z);

           // yield return null;
    }

    IEnumerator StopCoroutine(IEnumerator coroutine, float height)
    {
        StopCoroutine(coroutine);
        SnapToHeight(height);

        yield return null;

    }
}
