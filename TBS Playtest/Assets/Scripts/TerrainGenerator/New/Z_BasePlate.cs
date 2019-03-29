using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_BasePlate : MonoBehaviour
{

    [System.Serializable]
    public struct Tile
    {
        public int chance;
        public List<GameObject> pieces;
        public List<Transform> spawnlocations;
    }

    [System.Serializable]
    public struct Spawner
    {
        public int numberOf;
        public List<GameObject> pieces;
        public List<Transform> spawnlocations;
    }

    //Spawn Types
    [Header("Plate Types")]
    public Spawner playerSpawn;
    public Spawner enemySpawn;
    public Tile guaranteedSize1;
    public Tile guaranteedSize2;
    public Tile randomSize1;
    public Tile randomSize2;
    public Tile edging;

    //Spawn Locations
    [Header("Spawn Points")]
    public List<Transform> playerSpawns;
    public List<Transform> enemySpawns;
    public List<Transform> gSpawns;
    public List<Transform> rSpawns;
    public List<Transform> eSpawns;

    //Settings
    [Header("Settings")]
    public bool rotatable;
    public GameObject geo;
    public LayerMask regularLayermask;
    public LayerMask spawnLayermask;    

    //Private Variables
    private int rand;
    private List<int> rotations = new List<int> { 0, 90, 180, 270 };
    public Z_TerrainGenerator TG;


    private void Start()
    {
        TG = transform.GetComponentInParent<Z_TerrainGenerator>();
    }

    public void GenerateTerrain()
    {
        GenerateSpawnerSet(playerSpawn);
        GenerateSpawnerSet(enemySpawn);
        GenerateTileSet(guaranteedSize1, randomSize2);
        GenerateTileSet(guaranteedSize2, guaranteedSize1);
        GenerateTileSet(randomSize1, randomSize2);
        GenerateTileSet(randomSize2, edging);
        GenerateTileSet(edging, guaranteedSize1);
    }

    void GenerateTileSet(Tile tile, Tile nTileSet)
    {
        foreach (Transform SP in tile.spawnlocations)
        {
            if (tile.chance != 100)
                rand = Random.Range(0, 101);
            else rand = 0;

            if (rand <= tile.chance)
            {
                RaycastHit hit;
                if (!Physics.Raycast(SP.transform.position + new Vector3(0, 1f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, regularLayermask))
                {
                    rand = Random.Range(0, tile.pieces.Count);
                    GameObject plate = Instantiate(tile.pieces[rand], SP.position, SP.rotation, transform);
                    rand = Random.Range(0, 4);
                    Z_Plate TP = plate.GetComponent<Z_Plate>();

                    if (TP.rotatable)
                        TP.geo.transform.Rotate(0, rotations[rand], 0);

                    //TG.TIS.Add(plate);

                    foreach (Transform NSP in TP.spawnPoints)
                        nTileSet.spawnlocations.Add(NSP);
                }
            }

            
        }
        foreach (Transform spawnPoint in tile.spawnlocations)
            Destroy(spawnPoint.gameObject);

        tile.spawnlocations.Clear();
    }
     void GenerateSpawnerSet(Spawner spawnSet)
    {
        RandomizeList(spawnSet.spawnlocations);

        int x = spawnSet.numberOf;

        for (int i = 0; i < x; i++)
        {
            RaycastHit hit;
            if (!Physics.Raycast(spawnSet.spawnlocations[i].transform.position + new Vector3(2, 0.5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                && !Physics.Raycast(spawnSet.spawnlocations[i].transform.position + new Vector3(-2, 0.5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                && !Physics.Raycast(spawnSet.spawnlocations[i].transform.position + new Vector3(0, 0.5f, 2), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                && !Physics.Raycast(spawnSet.spawnlocations[i].transform.position + new Vector3(0, 0.5f, -2), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask))
            {
                rand = Random.Range(0, spawnSet.pieces.Count);
                GameObject plate = Instantiate(spawnSet.pieces[rand], spawnSet.spawnlocations[i].position, spawnSet.spawnlocations[i].rotation, transform);

                rand = Random.Range(0, 4);
                Z_Plate TP = plate.GetComponent<Z_Plate>();

                if (TP.rotatable)
                    TP.geo.transform.Rotate(0, rotations[rand], 0);

                //TG.TIS.Add(plate);
            }
            else            
            {
                Debug.Log(hit.transform.name);
                x++;
            }
        }

        //foreach (Transform spawnPoint in spawnSet.spawnlocations)
           // Destroy(spawnPoint.gameObject);

        spawnSet.spawnlocations.Clear();
    }

    void RandomizeList(List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Transform temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}


