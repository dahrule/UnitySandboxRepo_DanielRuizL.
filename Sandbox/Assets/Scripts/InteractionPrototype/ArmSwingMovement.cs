using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ArmSwingMovement : MonoBehaviour
{
    [SerializeField]
    XRNode inputSource; //Device to track. 

    public Rigidbody rg;

   
    public GameObject RightHand;
    public GameObject LeftHand;
   

    bool gripPressed; 
  
    Vector3 previousPosRightHand;
    Vector3 currentPosRightHand;
    Vector3 previousPosLeftHand;
    Vector3 currentPosLeftHand;

    Vector3 playerPosPreviousFrame;
    Vector3 playerPosCurrentFrame;

    Vector3 MoveDirecton;

    Vector3 previousFrameLeftHandRotation;
    Vector3 currentFrameLeftHandRotation;
   

    public int angle = 30;
    public float speed = 20f;
    private float HandSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();

        previousPosRightHand =RightHand.transform.position;
        previousPosLeftHand = LeftHand.transform.position;
        playerPosPreviousFrame = this.transform.position;

        Vector3 previousFrameLeftHandRotation=LeftHand.transform.localEulerAngles;
       

    }

    // Update is called once per frame
    void Update()
    {
        MoveDirecton = LeftHand.transform.forward;

        currentPosLeftHand = LeftHand.transform.position;
        currentPosRightHand = RightHand.transform.position;
        playerPosCurrentFrame = this.transform.position;

        currentFrameLeftHandRotation = LeftHand.transform.localEulerAngles;

        var PlayerDisplacement = Vector3.Distance(playerPosCurrentFrame, playerPosPreviousFrame);
        var LeftHandDisplacement = Vector3.Distance(currentPosLeftHand, previousPosLeftHand);
        var RightHandDisplacement = Vector3.Distance(currentPosRightHand, previousPosRightHand);

       var LeftHandRotationChange = currentFrameLeftHandRotation- previousFrameLeftHandRotation;

        HandSpeed = (LeftHandDisplacement - PlayerDisplacement) + (RightHandDisplacement - PlayerDisplacement);

        //if (Time.timeSinceLevelLoad > 1f) transform.position += MoveDirecton * HandSpeed * speed * Time.deltaTime;
        if (Time.timeSinceLevelLoad > 1f)

            if (Mathf.Abs(LeftHandRotationChange.x) > angle)

                rg.AddForce(MoveDirecton * LeftHandDisplacement, ForceMode.Impulse);

        //
        // transform.position += MoveDirecton * HandSpeed * speed * Time.deltaTime; //
        //
        

        //if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("Key Down");
        //Debug.Log(LeftHand.transform.localRotation);

        playerPosPreviousFrame = playerPosCurrentFrame;
        previousPosRightHand = currentPosRightHand;
        previousPosLeftHand = currentPosLeftHand;

        previousFrameLeftHandRotation = currentFrameLeftHandRotation;


        //Check if swimming mode button is press.

        //Filter movemenet. Movement is only allowed if the difference of pitch between between time0 and time1 is greater than a value.

        // Get controller displacement between time 1 and 2. the magnitude of displacement is proportionatl to force to be applied to the rigidbod


        //InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource); //Get the device
        //device.TryGetFeatureValue(CommonUsages.gripButton, out gripPressed); //Get joytick axis values from device
        //Debug.Log(gripPressed);


        //PositionCurrentFrameRightHand =RightHand.transform.position;

        //var rightHandDisplacement = Vector3.Distance(previousFramePosRightHand,PositionCurrentFrameRightHand);
        //MoveDirecton = this.transform.forward;
        //Vector3 force = MoveDirecton * rightHandDisplacement;

        //rg.AddForce(force,ForceMode.Impulse);




    }
}
