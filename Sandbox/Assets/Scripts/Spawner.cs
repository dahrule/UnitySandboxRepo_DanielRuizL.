using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Vector3 center;
    Vector3 size;

    [SerializeField]
    float distanceTolerance = 0.5f;

    [SerializeField]
    Transform[] spawnPointsCatalogue;
    [SerializeField]
    Transform[] spawnPointsRecipe;




    private void Awake()
    {
        center = this.transform.position;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }

    public void SpawnWithinBox(GameObject[] objects,Vector3 dimensions)
    {
       
        foreach(GameObject obj in objects)
        {
            Vector3 newrandpos = RandomPosition(dimensions);

          


            //Set obj position to random point.
            //Check for collision: if collision occurs
            //cerate aother random point
            //else instantiatte
        }
    }

    private Vector3 RandomPosition(Vector3 dimensions)
    {
        //Create a random point in space
        int randx = Random.Range(-(int)dimensions.x, (int)dimensions.x);
        int randy = Random.Range(-(int)dimensions.y, (int)dimensions.y);
        int randz = Random.Range(-(int)dimensions.z, (int)dimensions.z);
        Vector3 randpos = new Vector3(center.x + randx, center.y + randy, center.z + randz);
        return randpos;
    }

    public void PublishCatalogue(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            GameObject obj = Pool.singleton.Get(array[i]);
            obj.transform.position = spawnPointsCatalogue[i].position;
        }
    }

    public void PublishRecipe(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject obj = Pool.singleton.Get(list[i]);
            obj.transform.position = spawnPointsRecipe[i].position;
        }
    }
}
