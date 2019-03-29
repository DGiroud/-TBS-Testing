using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_TerrainGenerator : MonoBehaviour {

    public List<GameObject> basePlates;

    public List<GameObject> TIS;

    //Private Variables
    private int rand;
    private List<int> rotations = new List<int> { 0, 90, 180, 270 };
    private bool counting;
    private float cnt;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearTerrain();

            Invoke("GenerateBasePlate", 0.1f);
        }

    }
    public void GenerateBasePlate()
    {
        counting = true;

        

        
            counting = false;
            cnt = 0.0f;
            rand = Random.Range(0, basePlates.Count);
            GameObject plate = Instantiate(basePlates[rand], transform.position, transform.rotation, transform);
            Z_BasePlate BP = plate.GetComponent<Z_BasePlate>();

            if (BP.rotatable)
            {
                rand = Random.Range(0, 4);
                BP.geo.transform.Rotate(0, rotations[rand], 0);
            }

            TIS.Add(plate);

            BP.GenerateTerrain();
        
    }

    public void ClearTerrain()
    {
        if (TIS.Count != 0)
            foreach (GameObject tile in TIS)
                Destroy(tile);

        TIS.Clear();       
    }
}
