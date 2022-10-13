using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class JoystickLocomotion : MonoBehaviour
{
    public Rigidbody player;
    public Transform rotator;
    public float speed;

    void Update() {
        var LjoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
		float fixedY = player.position.y;
        //VR movement
        player.position +=(transform.right*LjoystickAxis.x + transform.forward * LjoystickAxis.y)*Time.deltaTime*speed;
        player.position = new Vector3(player.position.x,fixedY,player.position.z);
        ////continuous turn
        if(LjoystickAxis.x >= .8f) {
            player.transform.RotateAround(rotator.position, Vector3.down, speed * .1f);
        }
        if(LjoystickAxis.x <= -.8f) {
            player.transform.RotateAround(rotator.position, Vector3.down, speed * .1f);
        }

    }
}