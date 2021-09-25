using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float ySpeed=1f;
    [SerializeField] [Range(0,5)]
    public float yRange=1f;

   
    // Update is called once per frames
    void Update()
    {
        float x = transform.position.x;
        float y = Mathf.PingPong(Time.time* ySpeed, 1) * yRange;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
   
}
