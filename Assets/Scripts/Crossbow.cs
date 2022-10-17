using System;
using System.Linq;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.XR;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow;
    public OVRHand leftHand;
    public OVRHand rightHand;
    public GrabInteractable grabInteractable;
    public HandGrabInteractable handGrabInteractable;

    public void Update()
    {
        if (grabInteractable.State is InteractableState.Hover or InteractableState.Select &&
            OVRInput.GetDown(OVRInput.Button.One))
        {
        }
        else if (handGrabInteractable.State is InteractableState.Hover or InteractableState.Select &&
                 handGrabInteractable.InteractorViews.Any(i =>
                     i is HandGrabInteractor hi && hi.Hand.Handedness == Handedness.Left) &&
                 leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) == 1 ||
                 rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) == 1)

        {
        }
        else return;


        var projectile = Instantiate(arrow, transform.position, Quaternion.LookRotation(-transform.right));
        projectile.GetComponent<Rigidbody>().velocity = 10 * projectile.transform.forward;
    }
}