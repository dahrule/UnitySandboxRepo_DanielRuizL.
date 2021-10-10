using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    GameObject[] collection;

    [SerializeField]
    public Transform[] spawnPoints;

    Vector3 center;
    [SerializeField]
    Vector3 size=new Vector3(1,1,1);

    



    private void Awake()
    {
        center = this.transform.position;
    }

    private void Start()
    {
        foreach(var item in Pool.singleton.poolediItems)
        {
            //item.SetActive(true);
        }
        
        //SpawnWithinBox(Pool.singleton.poolediItems.ToArray(), size);
      
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }

    /* NOT WORKING. The intention is to spawn object within a box volume without objects overlapping.
    public void SpawnWithinBox2(GameObject[] objects,Vector3 boxdimensions)
    {
       
        foreach(GameObject obj in objects)
        {
            Sensor objSensor = obj.GetComponent<Sensor>(); 
            
            //Repeats the following until cube object is not overlapping with another cube object.
                do
                {  //Generates a random point in 3d space.
                    Vector3 newrandpos = RandomPosition(boxdimensions);
                    //Set obj position to the random point.
                    obj.transform.position = newrandpos;
                }
                while (objSensor.Overlaps); 
            Debug.Log("no OVERLAP");
            
        }
    }

    */

    public void SpawnWithinBox(GameObject[] objects, Vector3 boxdimensions)
    {

        foreach (GameObject obj in objects)
        {
          
            //Generates a random point in 3d space.
                Vector3 newrandpos = RandomPosition(boxdimensions);
            //Set obj position to the random point.
            //obj.transform.position = newrandpos;
            Instantiate(obj, newrandpos, Quaternion.identity);
        }
    }


    private Vector3 RandomPosition(Vector3 dimensions)
    {
        //Create a random point in space
        int randx = Random.Range(-(int)dimensions.x/2, (int)dimensions.x/2);
        int randy = Random.Range(-(int)dimensions.y/2, (int)dimensions.y/2);
        int randz = Random.Range(-(int)dimensions.z/2, (int)dimensions.z/2);
        Vector3 randpos = new Vector3(center.x + randx, center.y + randy, center.z + randz);
        return randpos;
    }

    public void PublishRecipe(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject obj = Pool.singleton.Get(list[i]);
            obj.transform.position = spawnPoints[i].position;
        }
    }

   

}
