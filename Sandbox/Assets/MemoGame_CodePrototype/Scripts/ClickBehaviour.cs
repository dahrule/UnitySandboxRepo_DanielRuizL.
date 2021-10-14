using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class describes what happens when an object from the catalogue is clicked.The script lives inside the prefabs.
public class ClickBehaviour : MonoBehaviour
{
    static int clickCounts=0; //clickCounts is static to ensure the existance of only one variable for all instances of this class in the game. In this manner every item in the catalogue points to this variable, instead of each item having its own.

    GameManager gamemanager; //A reference to the game manager.


    private void Start()
    {
        gamemanager = GameManager.singleton; //Get an instance to the game manager singleton.
    }

    //Runs when the user clicks on an instance of this class (i.e. a cube from the catalogue).
    private void OnMouseDown()
    {
        
        
            clickCounts += 1;
            gamemanager.recipe[clickCounts - 1] = this.gameObject.tag;//Add the tagname of this object to the recipe living in the gamemanager.

            /*Check if recipe is complete (i.e. if user has clicked on enough items to fill the recipe slots). If it does, clickcouts is resetted, and the game manager is called to score/grade the recipe.
             */
            if (clickCounts == gamemanager.RecipeSize)
            {
                clickCounts = 0;
                gamemanager.Score();
            }
        
        
    }

    private void OnEnable()
    {
        TimeCounter.OnTimeOver += Disable;
    }

    private void OnDisable()
    {
        TimeCounter.OnTimeOver -= Disable;
    }

    //Disables the script given for each item in collection.
    public void Disable()
    {
        enabled = false;
    }
}
