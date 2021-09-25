using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer objRenderer;
    [SerializeField]
    float timeInterval =2f;

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();

        InvokeRepeating("ColorChange", 1f,timeInterval);
    }

    private void ColorChange()
    {
        objRenderer.material.color = Random.ColorHSV();
    }
}
