using System;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow;
    public GrabInteractable grabInteractable;
    public HandGrabInteractable handGrabInteractable;

    public void Update()
    {
        if (grabInteractable.State == InteractableState.Hover || grabInteractable.State == InteractableState.Select ||
            handGrabInteractable.State == InteractableState.Hover ||
            handGrabInteractable.State == InteractableState.Select)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                var projectile = Instantiate(arrow, transform.position, Quaternion.LookRotation(-transform.right));
                projectile.GetComponent<Rigidbody>().velocity = 10 * projectile.transform.forward;
            }
        }
    }
}