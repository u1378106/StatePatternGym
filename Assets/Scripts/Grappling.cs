using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _horizontalInput;

    private bool isGrapple;
    public Grappling(PlayerControllerStateMachine stateMachine) : base("Grappling", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (!isGrapple)
        {
            Debug.Log("grapple state");
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _sm.GetComponent<LineRenderer>().SetPosition(0, mousePos);
            _sm.GetComponent<LineRenderer>().SetPosition(1, _sm.transform.position);
            _sm.GetComponent<DistanceJoint2D>().connectedAnchor = mousePos;
            _sm.GetComponent<DistanceJoint2D>().enabled = true;
            _sm.GetComponent<LineRenderer>().enabled = true;
            isGrapple = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isGrapple = false;
            Debug.Log("grapple leave state");
            _sm.GetComponent<DistanceJoint2D>().enabled = false;
            _sm.GetComponent<LineRenderer>().enabled = false;
            stateMachine.ChangeState(_sm.movingState);
        }

        if (_sm.GetComponent<DistanceJoint2D>().enabled)
        {
            _sm.GetComponent<LineRenderer>().SetPosition(1, _sm.transform.position);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.GetComponent<Rigidbody2D>().velocity;
        vel.x = _horizontalInput * _sm.speed;
        _sm.GetComponent<Rigidbody2D>().velocity = vel;
    }
}