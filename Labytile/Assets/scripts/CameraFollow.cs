using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
public Transform player;
/*public float x_min, x_max, z_min,z_max;Si l'on doit contraindre la camera dans l espace de jeu*/
private Vector3 offset;     
	// Use this for initialization
	void Start () 
	{
		 offset = transform.position - player.transform.position;
	
	}
	

	void LateUpdate () 
    {
    Vector3 target = player.transform.position + offset;
	/*float targetX = Mathf.Clamp(target.x, x_min, x_max);
    float targetZ = Mathf.Clamp(target.z, z_min, z_max);
    transform.position = new Vector3(targetX, target.y, targetZ);*/
	}
}
