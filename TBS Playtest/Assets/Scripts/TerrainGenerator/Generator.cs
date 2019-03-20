using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public List<GameObject> BasePlates;

    public List<GameObject> Tiles;

    public Transform baseSpawn;
    public List<Transform> spawnpoints;

    [Header("Player Spawns")]
    public GameObject playerSpawn;
    public int pNumberOf;

    [Header("Enemy Spawns")]
    public GameObject enemySpawn;
    public int eNumberOf;

    private int rand;
    private int SN;

    private List<float> rotations = new List<float> { 0, 90, 180, 270 };

    public List<GameObject> TIS;   


    public void ButtonPressed()
    {
        ClearTerrrain();
        Invoke("GenerateTerrain", 0.25f);

    }
    public void GenerateTerrain()
    {

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        rand = Random.Range(0, BasePlates.Count);
        SN = 0;

        GameObject BP = Instantiate(BasePlates[rand], transform);
        BP.transform.position = baseSpawn.position;
        rand = Random.Range(0, 4);
        BP.transform.GetComponent<TileSet>().tiles.transform.Rotate(0, rotations[rand], 0);
        TIS.Add(BP.gameObject);
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < spawnpoints.Count; i++)
        {
            Transform temp = spawnpoints[i];
            int randomIndex = Random.Range(i, spawnpoints.Count);
            spawnpoints[i] = spawnpoints[randomIndex];
            spawnpoints[randomIndex] = temp;            
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < pNumberOf; i++)
        {
            GameObject PS = Instantiate(playerSpawn, transform);
            PS.transform.position = spawnpoints[SN].position;
            rand = Random.Range(0, 4);
            PS.transform.GetComponent<TileSet>().tiles.transform.Rotate(0, rotations[rand], 0);
            SN++;
            TIS.Add(PS.gameObject);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < eNumberOf; i++)
        {
            GameObject ES = Instantiate(enemySpawn, transform);
            ES.transform.position = spawnpoints[SN].position;
            rand = Random.Range(0, 4);
            ES.transform.GetComponent<TileSet>().tiles.transform.Rotate(0, rotations[rand], 0);
            SN++;
            TIS.Add(ES.gameObject);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < spawnpoints.Count - pNumberOf - eNumberOf; i++)
        {
            rand = Random.Range(0, Tiles.Count);
            GameObject TL = Instantiate(Tiles[rand], transform);
            TL.transform.position = spawnpoints[SN].position;
            rand = Random.Range(0, 4);
            TL.transform.GetComponent<TileSet>().tiles.transform.Rotate(0, rotations[rand], 0);
            SN++;
            TIS.Add(TL.gameObject);
        }

    }

    public void ClearTerrrain()
    {
        if (TIS.Count != 0)
            foreach (var tile in TIS)
            {
                Destroy(tile.gameObject);
            }

        TIS.Clear();
    }
}
