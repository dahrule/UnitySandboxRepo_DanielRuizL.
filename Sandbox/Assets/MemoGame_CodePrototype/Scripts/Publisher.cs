using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base clase in charge of receiving information and publishing it into the world. It does that by moving in and out objects from the pool that match the information received(lists of tags).
public class Publisher : MonoBehaviour
{

    protected GameObject[] collection;
    public string[] itemTags; //item tags in collection.

    [SerializeField]
    public Transform[] spawnPoints; //World points to spawn items in collection. 


    //Defines how collection items are published into the world.
    public virtual void Publish(string[] tags)
    {
        //Initialize collection array.
        collection = new GameObject[tags.Length];

        //Gets items by tag from the pool and stores them in collection.
        for (int i = 0; i < tags.Length; i++)
        {
            collection[i] = Pool.singleton.Get(tags[i]);
        }

        //Places elements from collection in the world.
        for (int i = 0; i < collection.Length; i++)
        {
            collection[i].transform.position = spawnPoints[i].position;
        }

    }

    //Returns whole collection to the pool.
    public void Depublish()
    {
        foreach (GameObject item in collection)
        {
            item.SetActive(false);
        }
    }


}
