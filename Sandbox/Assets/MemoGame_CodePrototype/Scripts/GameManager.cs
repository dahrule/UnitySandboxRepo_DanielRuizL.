using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Publisher cataloguePublisher;
    [SerializeField]
    Publisher recipePublisher;

    int recipeSize = 4;
    public int RecipeSize{ get { return recipeSize; } }

     string[] modelrecipe;//the recipe to be memorized and copied by player.
     public string[] recipe; //recipe attempt by player.

    public static GameManager singleton; //single reference to the game manager class.

    private void Awake()
    {
        singleton = this; //Creates a public reference to a unique instance of the GameManager.
    }
    private void Start()
    {
        
        //Ensures that there is already a catalog available.
        if (cataloguePublisher.itemTags.Length == 0)
        {
            
            cataloguePublisher.itemTags = Pool.singleton.GetTags();
            
        }

        InitializeRecipeArrays(); //Sets the modelrecipe and recipe containers to an equal size.


        CreateRecipe();//Create a random model recipe from items in the catalog. 

    }

    
    private void InitializeRecipeArrays()
    {
        modelrecipe = new string[recipeSize];
        recipe = new string[recipeSize];
    }

    private void CreateRecipe()
    {
        
        for (int i = 0; i < recipeSize; i++)
        {
            int randnum = Random.Range(0, cataloguePublisher.itemTags.Length-1);
            modelrecipe[i] = cataloguePublisher.itemTags[randnum];
        }

        recipePublisher.Publish(modelrecipe); // sends the new model recipe to a plubisher.
    }

    //The scoring logic lives here. A recipe is considered valid only if all its items are equal in type and order to the model recipe. If they are, the gameobjets in the recipe are returned to the pool (depublised), a new random model recipe is created and published, a recipe container is emptied, and the user scores a point.
    public void Score()
    {
        for (int i = 0; i < recipeSize; i++)
        {
            if (modelrecipe[i] != recipe[i])
            {
                Debug.Log("Wrong selection");

                InitializeRecipeArrays();
                recipePublisher.Depublish();
                CreateRecipe();

                return;
            }

        }

        UIManager.singleton.AddPoints(1);
        Debug.Log("Your recipe is correct. Score: " + UIManager.singleton.Score);
       
        InitializeRecipeArrays();
        recipePublisher.Depublish();
        CreateRecipe();
    }


}
