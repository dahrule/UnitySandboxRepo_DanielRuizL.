using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBehaviour : MonoBehaviour
{
    static int clickCounts=0; //clickCounts is static to ensure the existance of only one variable for all instances of this class in the game.
    GameManager gamemanager;


    private void Start()
    {
        gamemanager = GameManager.singleton; //Get instance to the game manager singleton.
    }
    private void OnMouseDown()
    {
        clickCounts += 1;
        gamemanager.recipe[clickCounts - 1] = this.gameObject.tag;

        /*Check if dish is complete. If not complete, add the clicked object's tag to recipe.
         * else if complete, call game logic  to score, and reset click counts to zero.
         */

        if (clickCounts== gamemanager.recipeSize)
        {
            clickCounts = 0;
            gamemanager.Score();
            
           
        }
    }

  
}
