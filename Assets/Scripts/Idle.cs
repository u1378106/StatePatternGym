using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _horizontalInput;

    public Idle(PlayerControllerStateMachine stateMachine) : base("Idle", stateMachine)
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
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.movingState);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(_sm.grappleState);

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            stateMachine.ChangeState(_sm.groundPoundState);
        }
    }
}