using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh_Random : MonoBehaviour
{

    public List<GameObject> mesh;
    public GameObject geo;


    private List<int> rotations;


    public void Start()
    {
        rotations = new List<int> {0,90,180,270 };

        int rand = Random.Range(0, mesh.Count);

        foreach (var tile in mesh)
        {
            if (tile == mesh[rand])
            {
                tile.gameObject.SetActive(true);                
            }
            else
                tile.gameObject.SetActive(false);
        }
        rand = Random.Range(0, 3);
        geo.transform.rotation = Quaternion.Euler(0, rotations[rand], 0);

    }




}

	
