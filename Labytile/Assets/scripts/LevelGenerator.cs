using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public Texture2D levelTexture = null;
    public GameObject movingTile = null;
    public GameObject staticTile = null;
    public GameObject playerObject = null;

    public Player GetPlayer() { return player; }

    private Player player = null;

    private basicTile[] tiles;

	// Use this for initialization
	void Start () 
    {

        Color[] pixels = levelTexture.GetPixels();

        tiles = new basicTile[pixels.Length];
        int tileCounter = 0;

        for (int i = 0; i < pixels.Length;i++)
        {
            int indexX = i % levelTexture.width;
            int indexZ = i / levelTexture.width;

            if (pixels[i].r == 0) // tiles 
            {
                basicTile tile = SpawnTile(movingTile, indexX, indexZ);
                tiles[tileCounter] = tile;
                tileCounter++;
            }
            else
            {
                basicTile tile = SpawnTile(staticTile, indexX, indexZ);
                tiles[tileCounter] = tile;
                tileCounter++;
            }

            //if (pixels[i].g == 1) // spawn d'ennemi
            //    SpawnTile(movingTile, indexX, indexZ);
            //
            if (pixels[i].b == 1) // spawn joueur
                SpawnPlayer(indexX, indexZ);
            //
            //    if (pixels[i].a == 1) { }// 
            //    SpawnTile(movingTile, indexX, indexZ);

        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    basicTile SpawnTile(GameObject tileToSpawn,int indexX, int indexZ)
    {
        GameObject tile = Instantiate(tileToSpawn, transform.position + new Vector3((float)indexX * tileToSpawn.transform.localScale.x, 0.0f, (float)indexZ * tileToSpawn.transform.localScale.z), Quaternion.identity) as GameObject;
        basicTile tileComp = tile.GetComponent<basicTile>();
        tileComp.indexX = indexX;
        tileComp.indexZ = indexZ;

        return tileComp;
    }

    Player SpawnPlayer(int indexX, int indexZ)
    {
        basicTile tile = GetTileWithIndex(indexX,indexZ);
        Transform spawnPoint = tile.transform.GetChild(0);

        GameObject player = Instantiate(playerObject, spawnPoint.position, spawnPoint.rotation) as  GameObject;

        Player playerComp = player.GetComponent<Player>();

        varManager.player = playerComp;

        return playerComp;
    }

    basicTile GetTileWithIndex(int indexX, int indexZ)
    {
        basicTile tileToReturn = null;

        foreach (basicTile tile in tiles)
        {
            tileToReturn = tile.indexX == indexX ? (tile.indexZ == indexZ ? tile : null) : null;
        }

        return tileToReturn;
    }
}
