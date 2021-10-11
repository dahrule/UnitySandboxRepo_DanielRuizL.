using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This classs derives from Publisher class.
public class Catalogue:Publisher
{
    private void Start()
    {
        //Creates a catalogue from pool prefabs (i.e. unique elements of pool)
        itemTags = Pool.singleton.GetTags();
        
        Publish(itemTags);
    }
}
