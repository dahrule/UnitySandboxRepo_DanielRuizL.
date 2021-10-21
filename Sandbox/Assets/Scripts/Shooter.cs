using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Shooter : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject bullet;


    XRGrabInteractable grabInteractable;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(FireBubbles);
    }

    private void FireBubbles(ActivateEventArgs arg0)
    {
        Instantiate(bullet,spawnPoint.transform.position,Quaternion.identity);
    }


}
