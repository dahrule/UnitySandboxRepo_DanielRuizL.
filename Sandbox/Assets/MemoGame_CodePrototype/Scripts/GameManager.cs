using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Publisher cataloguePublisher;
    [SerializeField]
    Publisher recipePublisher;

    int gamescore = 0;

    public int recipeSize = 4;

    public string[] modelrecipe;
    public string[] recipe; //recipe attempt by player.

    public static GameManager singleton;

    private void Awake()
    {
        singleton = this; //Creates a public reference to a unique instance of the GameManager.
    }
    private void Start()
    {
        
        //Ensures there is already a catalog available.
        if (cataloguePublisher.ItemTags.Length == 0)
        {
            
            cataloguePublisher.ItemTags = Pool.singleton.GetTags();
            
        }

        InitializeRecipeArrays();

        //Create a random recipe 
        CreateRecipe();

    }

    private void InitializeRecipeArrays()
    {
        //Initializes modelrecipe and recipe containers to an equal size.
        modelrecipe = new string[recipeSize];
        recipe = new string[recipeSize];
    }

    private void CreateRecipe()
    {
        
        for (int i = 0; i < recipeSize; i++)
        {
            int randnum = Random.Range(0, cataloguePublisher.ItemTags.Length-1);
            modelrecipe[i] = cataloguePublisher.ItemTags[randnum];
        }

        recipePublisher.Publish(modelrecipe); // sends the new recipe to the plubisher.
    }

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
        gamescore += 1;
        Debug.Log("Your recipe is correct");
        Debug.Log("Your score: " + gamescore);
        InitializeRecipeArrays();
        recipePublisher.Depublish();
        CreateRecipe();
    }


}
