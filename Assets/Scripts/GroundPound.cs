using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPound : BaseState
{
    private PlayerControllerStateMachine _sm;

    private float dashingPower = 24f;

    private bool isGroundPound;

    public GroundPound(PlayerControllerStateMachine stateMachine) : base("GroundPound", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            isGroundPound = false;
            _sm.GetComponent<TrailRenderer>().enabled = false;
            stateMachine.ChangeState(_sm.idleState);         
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        GroundPoundActivate();
    }

    
    private void GroundPoundActivate()
    {
        if (!isGroundPound)
        {
            _sm.GetComponent<TrailRenderer>().enabled = true;

            float originalGravity = _sm.GetComponent<Rigidbody2D>().gravityScale;
            _sm.GetComponent<Rigidbody2D>().gravityScale = 0f;
            _sm.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -_sm.transform.localScale.y * dashingPower);
            _sm.GetComponent<TrailRenderer>().emitting = true;

            _sm.GetComponent<Rigidbody2D>().gravityScale = originalGravity;
            if (_sm.isGrounded)
            {
                Camera.main.GetComponent<CameraShake>().enabled = true;
                isGroundPound = true;
            }
           
        }
    }
}