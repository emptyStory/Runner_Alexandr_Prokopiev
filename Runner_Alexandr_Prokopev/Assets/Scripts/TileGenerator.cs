using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 100;


    [SerializeField] private Transform player;
    private int startTiles = 6;
    private int indexTile = 2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > spawnPos - 100)
        {
            if (indexTile <=3)
            {
                SpawnTile(indexTile);
                indexTile++;
                DeleteTile();
            }
            
        } 
    }

    private void SpawnTile(int tileIndex)
    {
            GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
            activeTiles.Add(nextTile);
            spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
