using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : BaseState
{
    private PlayerControllerStateMachine _sm;

    private float dashingPower = 20f;

    bool isDashing = false;

    public Dashing(PlayerControllerStateMachine stateMachine) : base("Dashing", stateMachine)
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
        Dash();

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDashing = false;
            _sm.GetComponent<TrailRenderer>().enabled = false;
            stateMachine.ChangeState(_sm.movingState);        
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    
    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            _sm.GetComponent<TrailRenderer>().enabled = true;
            float originalGravity = _sm.GetComponent<Rigidbody2D>().gravityScale;
            _sm.GetComponent<Rigidbody2D>().gravityScale = 0f;
            _sm.GetComponent<Rigidbody2D>().velocity = new Vector2(-_sm.transform.localScale.x * dashingPower, 0f);
            _sm.GetComponent<TrailRenderer>().emitting = true;

            _sm.GetComponent<Rigidbody2D>().gravityScale = originalGravity;
        }
    }
}