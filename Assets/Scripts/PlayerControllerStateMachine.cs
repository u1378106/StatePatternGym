using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerStateMachine : StateMachine
{
    [HideInInspector]
    public Idle idleState;

    [HideInInspector]
    public Moving movingState;

    [HideInInspector]
    public Grappling grappleState;

    [HideInInspector]
    public Dashing dashingState;

    [HideInInspector]
    public GroundPound groundPoundState;

    public Rigidbody2D rb;

    public float speed = 4f;

    [HideInInspector]
    public bool isGrounded = false;

    private void Awake()
    {
        idleState = new Idle(this);
        //idleState = new Idle(this, () => {
        //});
        movingState = new Moving(this);
        grappleState = new Grappling(this);
        dashingState = new Dashing(this);
        groundPoundState = new GroundPound(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
            Debug.Log("isGrounded : " + isGrounded);
        }
      
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
            Debug.Log("isGrounded : " + isGrounded);
        }
    }
}