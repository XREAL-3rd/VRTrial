using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class JoystickLocomotion : MonoBehaviour
{
    public Rigidbody player;
    public float move_speed;

    public Transform rotator;
    public float turn_speed;

    void Update()
    {
        var RjoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
        float fixedY = player.position.y;

        player.position += (transform.right * RjoystickAxis.x + transform.forward * RjoystickAxis.y) * Time.deltaTime * move_speed;
        player.position = new Vector3(player.position.x, fixedY, player.position.z);

        var LjoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        if (LjoystickAxis.x >= .8f)
        {
            player.transform.RotateAround(rotator.position, Vector3.up, turn_speed * .1f);
        }
        if (LjoystickAxis.x <= -.8f)
        {
            player.transform.RotateAround(rotator.position, Vector3.down, turn_speed * .1f);
        }
    }
}
