using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
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

    public Tile basePlate;

    public Spawner playerSpawn;
    public Spawner enemySpawn;
    public Tile guanteedSize1;
    public Tile randomSize1;
    public Tile randomSize2;
    public Tile edging;

    [Header("Settings")]
    public LayerMask regularLayermask;
    public LayerMask spawnLayermask;
    [HideInInspector]
    public List<GameObject> tilesInScene;

    private bool spawnedBase = false;
    private List<int> rotations = new List<int> { 0, 90, 180, 270 };
    private int rand;
    private bool spwn = true;
    private float cnt;
    private bool counting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        
            ButtonPressed();

        if (Input.GetKeyDown(KeyCode.H))
            counting = !counting;


        if (counting)
            cnt += 1 * Time.deltaTime;

        if (cnt >= 0.5f)
        {
            if (spwn)
            {
                GenerateTerrain(basePlate, basePlate);
                GenerateTerrain(guanteedSize1, randomSize2);
                GenerateTerrain(randomSize1, randomSize2);
                GenerateTerrain(randomSize2, edging);
                GenerateTerrain(edging, basePlate);
                spawnedBase = false;
                spwn = false;
                cnt = 0.0f;
            }
            else
            {
                ClearTerrain();
                spwn = true;
                cnt = 0.49f;
            }
        }
    }

    public void Trees()
    {
        ClearTerrain();
        counting = !counting;
        cnt = .9f;
            }

    public void ButtonPressed()
    {
        ClearTerrain();
        Invoke("Generate", 0.01f);
    }

    public void Generate()
    {
        GenerateTerrain(basePlate, basePlate);
        GenerateTerrain(guanteedSize1, randomSize2);
        GenerateTerrain(randomSize1, randomSize2);
        GenerateTerrain(randomSize2, edging);
        GenerateTerrain(edging, basePlate);
        spawnedBase = false;
    }


    public void GenerateTerrain(Tile tile, Tile nTileSet)
    {
        if (!spawnedBase)
        {
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            spawnedBase = true;
            rand = Random.Range(0, tile.pieces.Count);
            GameObject piece = Instantiate(tile.pieces[rand], transform.position, transform.rotation, transform);
            Base_Piece BP = piece.GetComponent<Base_Piece>();
            rand = Random.Range(0, 4);
            BP.geo.transform.Rotate(0, rotations[rand], 0);

            foreach (Transform SP in BP.playerSpawns)
                playerSpawn.spawnlocations.Add(SP);

            foreach (Transform SP in BP.enemySpawns)
                enemySpawn.spawnlocations.Add(SP);

            foreach (Transform SP in BP.gSpawnPoints)
                guanteedSize1.spawnlocations.Add(SP);

            foreach (Transform SP in BP.rSpawnPoints)
                randomSize1.spawnlocations.Add(SP);

            foreach (Transform SP in BP.eSpawnPoints)
                randomSize2.spawnlocations.Add(SP);

            tilesInScene.Add(piece);


            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            RandomizeList(playerSpawn.spawnlocations);
            RandomizeList(enemySpawn.spawnlocations);

            int x = playerSpawn.numberOf;

            for (int i = 0; i < x; i++)
            {
                RaycastHit hit;
                if (!Physics.Raycast(playerSpawn.spawnlocations[i].transform.position + new Vector3(3, 0.5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                    && !Physics.Raycast(playerSpawn.spawnlocations[i].transform.position + new Vector3(-3, 0.5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                    && !Physics.Raycast(playerSpawn.spawnlocations[i].transform.position + new Vector3(0, 0.5f, 3), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                    && !Physics.Raycast(playerSpawn.spawnlocations[i].transform.position + new Vector3(0, 0.5f, -3), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask))
                {
                    rand = Random.Range(0, playerSpawn.pieces.Count);
                    piece = Instantiate(playerSpawn.pieces[rand], playerSpawn.spawnlocations[i].position, playerSpawn.spawnlocations[i].rotation, transform);
                    rand = Random.Range(0, 4);
                    Tile_Piece TP = piece.GetComponent<Tile_Piece>();
                    TP.geo.transform.Rotate(0, rotations[rand], 0);
                    tilesInScene.Add(piece);
                }
                else
                {
                    x++;                    
                }
            }
            playerSpawn.spawnlocations.Clear();

            x = enemySpawn.numberOf;

            for (int i = 0; i < x; i++)
            {
                RaycastHit hit;
                if (!Physics.Raycast(enemySpawn.spawnlocations[i].transform.position + new Vector3(3, 0.5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                    && !Physics.Raycast(enemySpawn.spawnlocations[i].transform.position + new Vector3(-3, 0.5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                    && !Physics.Raycast(enemySpawn.spawnlocations[i].transform.position + new Vector3(0, 0.5f, 3), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask)
                    && !Physics.Raycast(enemySpawn.spawnlocations[i].transform.position + new Vector3(0, 0.5f, -3), transform.TransformDirection(Vector3.down), out hit, 1.0f, spawnLayermask))
                {
                    rand = Random.Range(0, enemySpawn.pieces.Count);
                    piece = Instantiate(enemySpawn.pieces[rand], enemySpawn.spawnlocations[i].position, enemySpawn.spawnlocations[i].rotation, transform);
                    rand = Random.Range(0, 4);
                    Tile_Piece TP = piece.GetComponent<Tile_Piece>();
                    TP.geo.transform.Rotate(0, rotations[rand], 0);
                    tilesInScene.Add(piece);
                }
                else
                {
                    x++;                    
                }
            }
            enemySpawn.spawnlocations.Clear();

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }
        else
        {
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            foreach (Transform SP in tile.spawnlocations)
            {             
                
                    rand = Random.Range(0, 100);              
                

                if (rand <= tile.chance)
                {
                    RaycastHit hit;
                    if (!Physics.Raycast(SP.transform.position + new Vector3(0, .5f, 0), transform.TransformDirection(Vector3.down), out hit, 1.0f, regularLayermask))
                    {
                        rand = Random.Range(0, tile.pieces.Count);
                        GameObject piece = Instantiate(tile.pieces[rand], SP.position, SP.rotation, transform);
                        rand = Random.Range(0, 4);
                        Tile_Piece TP = piece.GetComponent<Tile_Piece>();
                        TP.geo.transform.Rotate(0, rotations[rand], 0);
                        tilesInScene.Add(piece);

                        foreach (Transform NSP in TP.spawnPoints)
                            nTileSet.spawnlocations.Add(NSP);
                    }                  
                }
            }            
        }
        foreach (Transform spawnPoint in tile.spawnlocations)
            Destroy(spawnPoint.gameObject);
        
        tile.spawnlocations.Clear();
    }

    public void ClearTerrain()
    {
        foreach (Transform spawnPoint in basePlate.spawnlocations)
            Destroy(spawnPoint.gameObject);

        if (tilesInScene.Count != 0)
            foreach (GameObject tile in tilesInScene)
                Destroy(tile);

        tilesInScene.Clear();
        basePlate.spawnlocations.Clear();
    }

    public void RandomizeList(List<Transform> list)
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
