using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Transform tile;
    public Vector2 mapSize;

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap() {

        string holderName = "Tiles";
        if (transform.FindChild(holderName)) {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                Transform newTile = (Transform)Instantiate(tile, tilePosition, Quaternion.Euler(Vector3.right * 90));
                newTile.parent = mapHolder;
            }
        }
    }
}
