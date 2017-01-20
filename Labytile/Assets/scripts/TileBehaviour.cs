using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour 
{
    public float playerViewRange = 20.0f;
    public Transform player = null;
    public float elevation = 30.0f;

    private bool isElevated = false;
    private float initialHeight = 0.0f;

	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<Player>().transform;
        initialHeight = transform.position.y;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 playerPos = player.position;

        if (!isElevated && Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(playerPos.x, playerPos.z)) > playerViewRange)
        {
            isElevated = true;
            transform.position += new Vector3(0.0f, elevation, 0.0f);
        }
        else if (isElevated && Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(playerPos.x, playerPos.z)) < playerViewRange)
        {
            isElevated = false;
            transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        }
	}
}
