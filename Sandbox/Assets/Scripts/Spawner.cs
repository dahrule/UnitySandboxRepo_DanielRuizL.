using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
   Transform[] spawnPoints;
    [SerializeField]
    GameObject objectPrefab;
    [SerializeField]
    int maxRange = 10;
    [SerializeField]
    int minRange = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform spawn in spawnPoints)
        {
            GameObject spawnObject = Instantiate(objectPrefab, spawn.transform.position, Quaternion.identity);
            Movement SpawnObjMov=spawnObject.GetComponent<Movement>();
            SpawnObjMov.ySpeed = Random.Range(minRange, maxRange);
            SpawnObjMov.yRange = Random.Range(minRange, maxRange);
        }
    }
}
