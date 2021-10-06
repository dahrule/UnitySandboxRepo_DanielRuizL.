using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBehaviour : MonoBehaviour
{
    
    string[] recipeAttempt;

    int _userRecipeSize=1;
    public int RecipeSize{ set {_userRecipeSize=value;} }



    //Declare event that notifies when clickedCollection is full.

    // Start is called before the first frame update
    void Start()
    {
        //Sets the length of user recipe.
        recipeAttempt = new string[_userRecipeSize];
    }

    private void OnMouseDown()
    {
        
     
    }

    void AddIngredient()
    {

    }

  
}
