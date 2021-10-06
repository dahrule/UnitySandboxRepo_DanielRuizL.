using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   



    public List<GameObject> recipe;

    // Start is called before the first frame update
    void Start()
    {
        //Create a random Recipe from Collection.
        CreateRandomRecipe();
        GameObject obj = recipe[0];
        float y=obj.transform.position.y;
        recipe[0].transform.position = new Vector3(obj.transform.position.x, y+5, obj.transform.position.z);

        //Call spawnmanager to spawn recipe;

   
    }

    //When  ClickBehaviour event is received:
    //Compare recipe with clickedCollection.
    //Update Score.
    //Create a new random Recipe.
    //Call SpawnManager to spawn new recipe.
    //Enable clickBevahiour on collection objects.

    void CreateRandomRecipe()
    {
        int randnum=Random.Range(0,5);
        GameObject obj= Pool.singleton.poolediItems[0];
        recipe.Add(obj);

        obj.transform.position = new Vector3(obj.transform.position.x + 3, obj.transform.position.y, obj.transform.position.z + 3);
    }

    void Compare()
    {
        //GameObject.compare
    }

}
