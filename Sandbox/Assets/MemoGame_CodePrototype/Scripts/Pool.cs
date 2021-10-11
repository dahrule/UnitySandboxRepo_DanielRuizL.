using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Code from h3d learn. Design Patterns for Games programming. 
 * learn.holistic3d.com/courses.*/

[System.Serializable] //Makes the class visible inside Editor.

//Represents items that can be inside the pool.
public class PoolItem 
{ 
    public GameObject prefab;
    public int amount;
    public bool expandable=true;//an expandable item means that more units of this type can be added to the pool if needed on the go.
}

//Represents a pool where all items to be used by the game code will be instantiated in advance. The pool systems replaces constantly calling instantiate and destroy methods, making the code more efficient.
public class Pool : MonoBehaviour
{
    public static Pool singleton; //all instances of the class make reference to this unique singleton. Every class in the game can easily access the pool by using this variable without having an explicit reference to it.

    public List<PoolItem> items;
    public List<GameObject> poolediItems;


    //Runs before Start() is called.
    private void Awake()
    {
        singleton = this; //the singleton variable references this class.
        CreatePool();
    }

  

    //Creates a pool containing pool items x thier amount value. Sets objects inactive too. Inactive objets are considered to be inside the pool, though available to get, contrary to active objects which are considered outside the pool, or being used by the game.
    private void CreatePool()
    {
        poolediItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject gameobj = Instantiate(item.prefab);
                gameobj.SetActive(false);
                poolediItems.Add(gameobj);
            }
        }
    }

    //Returns the tag names of every unique item (prefab) in the pool.
    public string[] GetTags()
    {
        string[] tags = new string[items.Count];
        for (int i = 0; i < items.Count; i++)
        {
            tags[i] = items[i].prefab.tag;
        }
        return tags;
    }


    //Gets an item from pool by its tag name. To be considered a valid item it must match the tag parameter and must be inactive. 
    public GameObject Get(string tag)
    {
        foreach (var item in poolediItems)
        {
            if (!item.activeInHierarchy && item.tag == tag)
            {
                item.SetActive(true); // Sets the item active before returning it as "it is moving it out from the pool" to be used by other script in the game.
                return item;
            }
        }

        foreach(PoolItem item in items)
        {
            if(item.prefab.tag==tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                poolediItems.Add(obj); 
                obj.SetActive(true); // Sets the item active before returning it as "it is moving it out from the pool" to be used by other script in the game.

                return obj;
            }
        }
        return null;
    }
}
