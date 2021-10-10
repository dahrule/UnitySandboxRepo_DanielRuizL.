using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalogue:Publisher
{

    private void Start()
    {
        //Creates a catalogue form pool prefabs (i.e. unique elements of pool)
        ItemTags = Pool.singleton.GetTags();
        
        Publish(ItemTags);
    }

    public override void Publish(string[] ItemTags)
    {
        //Initialize collection array.
        collection = new GameObject[ItemTags.Length]; 

        //Gets items by tag from the pool and stores them in collection.
        for (int i = 0; i < collection.Length; i++)
        {
            collection[i] = Pool.singleton.Get(ItemTags[i]);
        }

        //Places elements from collection into the world.
        for(int i = 0; i < collection.Length; i++)
        {
            collection[i].transform.position = spawnPoints[i].position;
        }
    }
       
}
