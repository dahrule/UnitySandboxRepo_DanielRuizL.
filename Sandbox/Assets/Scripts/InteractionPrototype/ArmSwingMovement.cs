using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwingMovement : MonoBehaviour
{
    //public GameObject LeftHand;
    public GameObject RightHand;
    Vector3 MoveDirecton;

    //Vector3 PositionPreviousFrameLeftHand;
    Vector3 PositionPreviousFrameRightHand;
    //Vector3 PositionCurrentFrameLeftHand;
    Vector3 PositionCurrentFrameRightHand;

    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        PositionPreviousFrameRightHand =RightHand.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //PositionCurrentFrameRightHand-PositionPreviousFrameRightHand
        //Vector3 forward = LeftHand.transform.TransformDirection(Vector3.forward) * 100;
        //Debug.DrawRay(LeftHand.transform.position, forward, Color.green);
    }
}
