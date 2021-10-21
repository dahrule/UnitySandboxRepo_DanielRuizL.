using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    HingeJoint joint;
    [SerializeField]
    GameObject bubbleGun;
    

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joint.angle==joint.limits.min)
        {
            bubbleGun.SetActive(true);
        }
    }
}
