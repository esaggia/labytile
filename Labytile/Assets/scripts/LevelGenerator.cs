﻿using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public Texture2D levelTexture = null;
    public GameObject movingTile = null;
    public GameObject staticTile = null;
    public GameObject playerObject = null;
    public GameObject portalObject = null;
    public GameObject enemyObject = null;

    public Player GetPlayer() { return player; }

    private Player player = null;

	// Use this for initialization
	void Start () 
    {

        Color[] pixels = levelTexture.GetPixels();

        SpawnTiles(pixels);
        SpawnPortal(pixels);
        SpawnPlayer(pixels);
        SpawnEnemy(pixels);
        

            //if (pixels[i].g == 1) // spawn d'ennemi
            //    SpawnTile(movingTile, indexX, indexZ);
            //
            //    if (pixels[i].a == 1) { }// 
            //    SpawnTile(movingTile, indexX, indexZ);
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

    void SpawnTiles(Color[] pixels)
    {
        varManager.tiles = new basicTile[pixels.Length];
        int tileCounter = 0;

        for (int i = 0; i < pixels.Length; i++)
        {
            int indexX = i % levelTexture.width;
            int indexZ = i / levelTexture.width;

            if (pixels[i].r == 0) // tiles 
            {
                basicTile tile = SpawnTile(movingTile, indexX, indexZ);
                varManager.tiles[tileCounter] = tile;
                tileCounter++;
            }
            else
            {
                basicTile tile = SpawnTile(staticTile, indexX, indexZ);
                varManager.tiles[tileCounter] = tile;
                tileCounter++;
            }
        }
    }

    void SpawnPortal(Color[] pixels)
    {
        for (int i = 0; i < pixels.Length; i++)
        {
            int indexX = i % levelTexture.width;
            int indexZ = i / levelTexture.width;

            if (pixels[i].a == 1)
            {
                basicTile tile = GetTileWithIndex(indexX, indexZ);
                Transform spawnPoint = tile.transform.GetChild(0);

                GameObject portal = Instantiate(portalObject,spawnPoint.position,spawnPoint.rotation) as GameObject;
                portal.transform.SetParent(spawnPoint);


                return;
            }
            else
            {
                Debug.Log(pixels[i].a);
            }
        }

 
    }

    Player SpawnPlayer(Color[] pixels)
    {
        for (int i = 0; i < pixels.Length; i++)
        {
            int indexX = i % levelTexture.width;
            int indexZ = i / levelTexture.width;

            if (pixels[i].b == 1) // spawn joueur
            {
                basicTile tile = GetTileWithIndex(indexX, indexZ);
                Debug.Log(tile.indexX + " " + tile.indexZ + " = spawn du joueur");

                if (tile == null)
                {
                    Debug.Log("no tile found 1");
                    return null;
                }

                Transform spawnPoint = tile.transform.GetChild(0);

                GameObject player = Instantiate(playerObject, spawnPoint.position, spawnPoint.rotation) as GameObject;

                Player playerComp = player.GetComponent<Player>();

                playerComp.indexX = indexX;
                playerComp.indexZ = indexZ;
                varManager.player = playerComp;

                //Debug.Log(spawnPoint.parent.GetComponent<basicTile>().indexX);

                return playerComp;
            }

          //else
          //    Debug.Log(pixels[i].b);
        }

        Debug.Log("no tile found 2");
        return null;
    }

    basicTile GetTileWithIndex(int indexX, int indexZ)
    {
        basicTile tileToReturn = null;

        foreach (basicTile tile in varManager.tiles)
        {
            if (tile.indexX == indexX && tile.indexZ == indexZ)
                tileToReturn = tile;
        }

        return tileToReturn;
    }
    void SpawnEnemy(Color[] pixels)
    {
        for (int i = 0; i < pixels.Length; i++)
        {
            int indexX = i % levelTexture.width;
            int indexZ = i / levelTexture.width;

            if (pixels[i].g == 1)
            {
                basicTile tile = GetTileWithIndex(indexX, indexZ);
                Transform spawnPoint = tile.transform.GetChild(0);

                GameObject enemy = Instantiate(enemyObject, spawnPoint.position, spawnPoint.rotation) as GameObject;
                //enemyObject.transform.SetParent(spawnPoint);


                //return;
            }
            else
            {
                Debug.Log(pixels[i].g);
            }
        }
    }
}
