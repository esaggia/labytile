using UnityEngine;
using System.Collections;

public static class varManager 
{
    static public Player player = null;
    static public basicTile[] tiles;

    static public void FindPlayerIndex()
    {
        RaycastHit hit;
        Physics.Raycast(player.transform.position, Vector3.down, out hit, 100.0f);

        if (hit.transform.tag == "Tile")
        {
            basicTile tile = hit.transform.GetComponent<basicTile>();
            Debug.Log(tile.indexX + " " + tile.indexZ);
            player.indexX = tile.indexX;
            player.indexZ = tile.indexZ;
            //return new Vector2(tile.indexX, tile.indexZ);
        }

        //return new Vector2(0.0f, 0.0f);

    }

    static public Vector2 FindEnemyIndex(GameObject enemy)
    {
        RaycastHit hit;
        Physics.Raycast(enemy.transform.position, Vector3.down, out hit, 100.0f);

        if (hit.transform != null && hit.transform.tag == "Tile")
        {
            basicTile tile = hit.transform.GetComponent<basicTile>();
            Debug.Log(tile.indexX + " " + tile.indexZ);
            //enemy.indexX = tile.indexX;
            //enemy.indexZ = tile.indexZ;
            return new Vector2(tile.indexX, tile.indexZ);
        }

        return new Vector2(0.0f, 0.0f);

    }


    static public Vector2 GetPlayerIndex(){return new Vector2(player.indexX, player.indexZ);}

}
