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
    public float jumpAmount;

    private bool landed;

    void Update()
    {
        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);

        Vector3 movement = (transform.right * joystickAxis.x + transform.forward * joystickAxis.y) *
                           (Time.deltaTime * speed);
        if (landed && OVRInput.GetDown(OVRInput.Button.Two)) movement.y = jumpAmount;

        player.velocity = movement;
    }

    private void FixedUpdate()
    {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        landed = Physics.CheckSphere(
            new Vector3(colli.bounds.center.x, colli.bounds.center.y,
                colli.bounds.center.z - ((colli.height - 1f) / 2 + 0.1f)),
            0.4f, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore);
    }
}