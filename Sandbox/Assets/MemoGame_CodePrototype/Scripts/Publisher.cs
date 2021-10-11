using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base clase in charge of publishing the content of string arrays into the world. It receives arrays of strings, retrieves gameobjects from the pool with tags matching those strings,stores retrieved gameobjects into a collection, and then places every object in the collection into defined spawnpoints at the world.
public class Publisher : MonoBehaviour
{

    protected GameObject[] collection;// stores game objects retrieved from the pool.
    public string[] itemTags; //item tags in collection, this what the gamelogic/manager uses.

    [SerializeField]
    public Transform[] spawnPoints; //World points to spawn gameobjects from the collection. 


    //Defines how string arrays are matched with gameobject arrays, and places objects into the world.
    public virtual void Publish(string[] tags)
    {
        //Initialize collection array to store game objects.
        collection = new GameObject[tags.Length];

        //Gets items by tag from the pool and stores them in the gameobject collection.
        for (int i = 0; i < tags.Length; i++)
        {
            collection[i] = Pool.singleton.Get(tags[i]);
        }

        //Places gameobjects from collection into the world.
        for (int i = 0; i < collection.Length; i++)
        {
            collection[i].transform.position = spawnPoints[i].position;
        }

    }

    //Returns whole collection to the pool by setting gameobjects to inactive.
    public void Depublish()
    {
        foreach (GameObject item in collection)
        {
            item.SetActive(false);
        }
    }


}
