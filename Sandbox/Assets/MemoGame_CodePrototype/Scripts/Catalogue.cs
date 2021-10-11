using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This classs derives from Publisher class.
public class Catalogue:Publisher
{
    private void Start()
    {
        //Creates an array of strings that represents the catalogue in the game (items the user can choose from to recreate the recipe model).
        //Strings are retrieved from pool prefabs' game tags (i.e. unique elements of pool).
        itemTags = Pool.singleton.GetTags();
        
        Publish(itemTags); // Sends the catalogue tags to the Publish method of the parent class (Publisher) for it to publish the catalogue into the world.
    }
}
