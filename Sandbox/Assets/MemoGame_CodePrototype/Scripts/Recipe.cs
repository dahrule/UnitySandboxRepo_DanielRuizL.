using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : Publisher
{
    
    public override void Publish(string[] Itemtags)
    {
        
           
        

        //Initialize collection array.
        collection = new GameObject[Itemtags.Length];

        //Gets items by tag from the pool and stores them in collection.
        for (int i = 0; i < Itemtags.Length; i++)
        {
            collection[i] = Pool.singleton.Get(Itemtags[i]);
        }

        //Places elements from collection in the world.
        for (int i = 0; i < collection.Length; i++)
        {
            collection[i].transform.position = spawnPoints[i].position;
        }
    }

}
