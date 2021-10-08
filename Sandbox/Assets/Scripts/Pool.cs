using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Code from h3d learn. Design Patterns for Games programming. 
 * learn.holistic3d.com/courses.*/

[System.Serializable] //Makes the class visible inside Editor.
public class PoolItem //Represents items that can be inside the pool.
{ 
    public GameObject prefab;
    public int amount;
}

public class Pool : MonoBehaviour
{
    public static Pool singleton; //all instances of the class make reference to this unique singleton.
    public List<PoolItem> items;
    public List<GameObject> poolediItems;


    //Runs before Start() is called.
    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePool();
    }

    //Creates a pool by instantiating all pool items times thier amount value. Sets objects inactive too. Inactive objets are considered into the pool, though available to get, contrary to active objects which are considered outside the pool.
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

    //Public methods
    public string[] GetTags()
    {
        string[] tags = new string[items.Count];
        for(int i=0; i<items.Count; i++)
        {
            tags[i] = items[i].prefab.tag;
        }
        return tags;
    }


    //Gets an item from pool. To be considered a valid item it must match the tag parameter and must be inactive. 
    public GameObject Get(string tag)
    {
        foreach(var item in poolediItems)
        {
            if(!item.activeInHierarchy && item.tag==tag)
            {
                item.SetActive(true); // Sets the item active before returning it as "it is moving it out from the pool" to be used by other script.
                return item;
            }
        }
        return null;
    }

    public GameObject GetRandomItem()
    {
        int randnum = Random.Range(0, items.Count);
        return items[randnum].prefab;
    }
}
