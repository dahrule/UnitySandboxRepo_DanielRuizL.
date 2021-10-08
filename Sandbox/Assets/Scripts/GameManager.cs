using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    Spawner spawner;
    public int recipeSize = 4;

    public static GameManager singleton; //all instances of the class make reference to this unique singleton.Only one manager exists in game.

    string[] catalogue;
    public List<string> recipe=new List<string>();

    private void Awake()
    {
        singleton = this;

        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        if (spawner == null)
        {
            spawner = FindObjectOfType<Spawner>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Create catalogue of items
        catalogue = Pool.singleton.GetTags();

        //Create a random recipe
        CreateRandomRecipe();

        spawner.PublishRecipe(recipe);
        spawner.PublishCatalogue(catalogue);

    }

    void CreateRandomRecipe()
    {
        recipe.Clear();
        for(int i=0; i<recipeSize;i++)
        {
            int randnum = Random.Range(0, catalogue.Length);
            recipe.Add(catalogue[randnum]);
        }
        player.dish.Clear();
        player.dishSize = recipeSize;
        spawner.PublishRecipe(recipe);
        Debug.Log(recipe);
       
    }

     public int Score(List<string> list)
    {
        Debug.Log("Hola");

        for (int i=0; i<recipeSize; i++)
        {
            if (list[i] != recipe[i])
            {
                Debug.Log("Your dish is wrong");
                CreateRandomRecipe();
                return 0;
            }
        }

        Debug.Log("Your dish is correct");
        CreateRandomRecipe();
        return 1;
    }

    public void Test()
    {
        Debug.Log("Hola");
    }

}
