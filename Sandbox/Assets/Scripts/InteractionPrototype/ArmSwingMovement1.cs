using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ArmSwingMovement1 : MonoBehaviour
{
    [SerializeField]
    XRNode inputSource; //Device to track. 

    public Rigidbody rg;

   
    public GameObject RightHand;
    public GameObject LeftHand;
   

    bool gripPressed; 
  
    Vector3 PositionPreviousFrameRightHand;
    Vector3 PositionCurrentFrameRightHand;
    Vector3 PositionPreviousFrameLeftHand;
    Vector3 PositionCurrentFrameLeftHand;

    Vector3 PlayerPositionPreviousFrame;
    Vector3 PlayerPositionCurrentFrame;


    Vector3 ForwardPreviousRightHand;
    Vector3 ForwardCurrentRightHand;
    Vector3 ForwardPreviousLeftHand;
    Vector3 ForwardCurrentLeftHand;


    Vector3 MoveDirecton;

    public float speed = 5f;
    private float HandSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();

        PositionPreviousFrameRightHand =RightHand.transform.position;
        PositionPreviousFrameLeftHand = LeftHand.transform.position;
        PlayerPositionPreviousFrame = this.transform.position;

        ForwardPreviousLeftHand = LeftHand.transform.forward;
        ForwardPreviousRightHand = RightHand.transform.forward;


    }

    // Update is called once per frame
    void Update()
    {

        MoveDirecton = LeftHand.transform.forward;

        PositionCurrentFrameLeftHand = LeftHand.transform.position;
        PositionCurrentFrameRightHand = RightHand.transform.position;
        PlayerPositionCurrentFrame = this.transform.position;

        ForwardCurrentRightHand = RightHand.transform.forward;
        ForwardCurrentLeftHand =LeftHand.transform.forward;

        float dot = Vector3.Dot(ForwardPreviousRightHand, ForwardCurrentRightHand);

        Debug.Log("dot= "+dot);

        

        var PlayerDisplacement = Vector3.Distance(PlayerPositionCurrentFrame, PlayerPositionPreviousFrame);
        var LeftHandDisplacement = Vector3.Distance(PositionCurrentFrameLeftHand, PositionPreviousFrameLeftHand);
        var RightHandDisplacement = Vector3.Distance(PositionCurrentFrameRightHand, PositionPreviousFrameRightHand);

        HandSpeed = (LeftHandDisplacement - PlayerDisplacement) + (RightHandDisplacement - PlayerDisplacement);

        if (Time.timeSinceLevelLoad > 1f) transform.position += MoveDirecton * HandSpeed * speed * Time.deltaTime;

        PlayerPositionPreviousFrame = PlayerPositionCurrentFrame;
        PositionPreviousFrameRightHand = PositionCurrentFrameRightHand;
        PositionPreviousFrameLeftHand = PositionCurrentFrameLeftHand;

        ForwardPreviousLeftHand = ForwardCurrentLeftHand;
        ForwardPreviousRightHand = ForwardCurrentRightHand;


        //Check if swimming mode button is press.

        //Filter movemenet. Movement is only allowed if the difference of pitch between between time0 and time1 is greater than a value.

        // Get controller displacement between time 1 and 2. the magnitude of displacement is proportionatl to force to be applied to the rigidbod


        //InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource); //Get the device
        //device.TryGetFeatureValue(CommonUsages.gripButton, out gripPressed); //Get joytick axis values from device
        //Debug.Log(gripPressed);


        //PositionCurrentFrameRightHand =RightHand.transform.position;

        //var rightHandDisplacement = Vector3.Distance(PositionPreviousFrameRightHand,PositionCurrentFrameRightHand);
        //MoveDirecton = this.transform.forward;
        //Vector3 force = MoveDirecton * rightHandDisplacement;

        //rg.AddForce(force,ForceMode.Impulse);




    }
}
