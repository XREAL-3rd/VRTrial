using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class JoystickLocomotion : MonoBehaviour
{
    public Rigidbody player;
    public CapsuleCollider colli;
    public float speed;
    public float turnSpeed;
    public float jumpAmount;

    private bool landed;

    void Update()
    {
        var lJoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);

        var prevY = player.velocity.y;
        Vector3 movement = (transform.right * lJoystickAxis.x + transform.forward * lJoystickAxis.y) * speed;

        if (landed && OVRInput.GetDown(OVRInput.Button.Two)) movement.y = jumpAmount;
        else movement.y = prevY;

        player.velocity = movement;

        var rJoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
        if (rJoystickAxis.x >= .8f)
        {
            player.transform.RotateAround(player.transform.position, Vector3.up, turnSpeed * .1f);
        }

        if (rJoystickAxis.x <= -.8f)
        {
            player.transform.RotateAround(player.transform.position, Vector3.down, turnSpeed * .1f);
        }
    }

    private void FixedUpdate()
    {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.//1 << 6은 Ground의 레이어가 6이기 때문.
        landed = Physics.CheckSphere(
            new Vector3(colli.bounds.center.x, colli.bounds.center.y - ((colli.height - 1f) / 2 + 0.1f),
                colli.bounds.center.z),
            0.4f, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore);
    }
}