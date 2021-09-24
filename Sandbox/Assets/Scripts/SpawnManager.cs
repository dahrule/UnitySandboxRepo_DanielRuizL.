using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnPoints;
    [SerializeField]
    GameObject objectPrefab;
    [SerializeField]
    int maxSpeedRange = 5;
    [SerializeField]
    int minSpeedRange = 1;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject spawn in spawnPoints)
        {
            GameObject spawnObject = Instantiate(objectPrefab, spawn.transform.position,Quaternion.identity);
            spawnObject.GetComponent<Movement>().speed = Random.Range(minSpeedRange, maxSpeedRange);
        }
    }
}
