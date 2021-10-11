using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This classs derives from Publisher class.
public class Recipe : Publisher
{

    // This is called from the Game Manager who creates and sends an array of strings representing the recipe model. The method does the same as the parent class but adds an extra step that disables the click behavior on the game objects being published.
    public override void Publish(string[] tags)
    {
        base.Publish(tags);

        //Disable click behaviour on all objects in collection.
        foreach (GameObject obj in collection)
        {
            ClickBehaviour script = obj.GetComponent<ClickBehaviour>();
            script.Disable();
        }

    }


}
