using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFloat : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed=5f;
    [SerializeField]
    float lifeSpan=3f;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*speed,ForceMode.Force);
        rb.AddForce(Vector3.up * speed, ForceMode.Force);

    }

    // Update is called once per frame
    void Update()
    {
        if(lifeSpan>=0)
        {
            lifeSpan -= Time.deltaTime;
        }
        else Destroy(this.gameObject);
    }
}
