using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuosMovement : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer; //Layer Mask the raycast will interact with.

    [SerializeField]
    float gravity = -9.81f;

    private float fallingSpeed;

    [SerializeField][RangeAttribute(1.4f, 3f)] //Average human speed walking ( 1.4 m/s) & jogging (3m/s) speed;
    float movementSpeed= 1.4f;

    [SerializeField]
    XRNode inputSource; //Device to track.

    private Vector2 inputAxis;
    private CharacterController character; //Component used to move the VRRig, allows for customatization to set interaction with different obstacles.
    XRRig rig; //Component that contains the camera object representign the VR head.

    // Start is called before the first frame update
    void Start()
    {
       character = GetComponent<CharacterController>();
       rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource); //Get the device
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis); //Get joytick axis values from device
    }
    private void FixedUpdate() //If movement feels Jittery, reduce the FixedTimestep to 1/90, or according to the headset's refresh rate.
    {
        CapsuleFollowHead();

        Quaternion headYaw = Quaternion.Euler(0,rig.cameraGameObject.transform.eulerAngles.y,0); //Creates a rotation for the yaw movement.

        Vector3 direction = headYaw*new Vector3(inputAxis.x,0,inputAxis.y); // defines the direction of movement for the character controller.
        character.Move(direction*Time.fixedDeltaTime*movementSpeed); //moves a character. This acts on a kinematic rigid body.

        //  Add Gravity effect when not Grounded.
        if (!IsGrounded())fallingSpeed += gravity * Time.fixedDeltaTime;  
        else fallingSpeed = 0f;

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    bool IsGrounded() //Check if the character is touching an object with a layer mask set as Ground.
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y+0.02f;
        bool hasHit = Physics.SphereCast(rayStart,character.radius,Vector3.down,out RaycastHit hitinfo,rayLength,groundLayer);
        return hasHit;
    }

    void CapsuleFollowHead() //Makes Capsule Collider representing the character controller follow the user's position. Physical movement of the user is tracked by the HDM. This allows for real world mobility.
    {
        character.height = rig.cameraInRigSpaceHeight; //sets the character's capsule height equal to the camera in rig.
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position); //Transforms the camera(HDM) position to the local space of the gameobjetc this script its attached to.
        character.center = new Vector3(capsuleCenter.x,character.height/2+character.skinWidth,capsuleCenter.z);//Sets the center of the character controller equal to the cameras HDM in the local space of this gameobject.

    }


}
