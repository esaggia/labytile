using UnityEngine;
using System.Collections;

public static class varManager 
{
    static public Player player = null;
    static public basicTile[] tiles;

    static public Vector2 GetPlayerIndex()
    {
        RaycastHit hit;
        Physics.Raycast(player.transform.position, Vector3.down,out hit, 10.0f);

        if (hit.transform.tag == "Tile")
        {
            basicTile tile = hit.transform.GetComponent<basicTile>();
            return new Vector2((float)tile.indexX, (float)tile.indexZ);
        }

        return new Vector2(0.0f, 0.0f);
    }

}
