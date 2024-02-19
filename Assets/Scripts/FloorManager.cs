using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{

    [SerializeField] GameObject[] floorPrefabs;

    public void SpawnFloor(String floorTag)
    {
        if(floorTag == "NormalFloor")
        {
            GameObject floor = Instantiate(floorPrefabs[0], transform);
            floor.transform.position = new Vector3(UnityEngine.Random.Range(-4f, 4f), -5.3f, 0);
        }
        if(floorTag == "NailsFloor")
        {
            GameObject floor = Instantiate(floorPrefabs[1], transform);
            floor.transform.position = new Vector3(UnityEngine.Random.Range(-4f, 4f), -5.3f, 0);

        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
