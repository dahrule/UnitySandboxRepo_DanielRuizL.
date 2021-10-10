using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publisher : MonoBehaviour
{

    protected GameObject[] collection;
    public string[] ItemTags; //item tags in collection.

    [SerializeField]
    public Transform[] spawnPoints; //World points to spawn items in collection. 


    //Defines how collection items are published into the world.
    public virtual void Publish(string[] ItemTags)
    {    
        
    }

    //Disables the script passed for each item in collection.
    public void Disable(Behaviour script)
    {

        foreach (GameObject item in collection)
        {
            Behaviour component=gameObject.GetComponent(typeof(Behaviour)) as Behaviour;
            component.enabled = false;

        }
    }

    public void Depublish()
    {
        foreach (GameObject item in collection)
        {
            item.SetActive(false);
        }
    }

}
