using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    int score = 0;
    public List<string> dish = new List<string>();

    public int dishSize;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                var selectionIngredient = selection.GetComponent<Ingredient>();
                if (selectionIngredient != null)
                {
                    if (dish.Count != dishSize) dish.Add(selection.tag);
                    else
                    {
                        score +=GameManager.singleton.Score(dish);
                        Debug.Log("Score: " + score);
                        
                    }
                }
            }

        }

    }



}
