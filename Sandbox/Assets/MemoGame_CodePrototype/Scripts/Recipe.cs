using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : Publisher
{
    
    public override void Publish(string[] tags)
    {
        base.Publish(tags);

        //Disable click behaviour on all collection items.
        foreach (GameObject obj in collection)
        {
            ClickBehaviour script = obj.GetComponent<ClickBehaviour>();
            script.Disable();
        }

    }


}
