using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PigController
{
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Animator animator;
    private DefaultInputAction inputAction;
    private bool freezed = false;
    void Start()
    {
        inputAction = new DefaultInputAction();
        inputAction.Enable();
    }

    void FixedUpdate()
    {
        if(freezed)
        {
            animator.SetFloat("speed", 0);
            return;
        }
        Move();
    }

    private void Move()
    {
        float speed = player.GetSpeed();
        float xSpeed = inputAction.Player.Move.ReadValue<Vector2>().x;
        float ySpeed = inputAction.Player.Move.ReadValue<Vector2>().y;
        Vector2 velocity = new Vector2(xSpeed, ySpeed).normalized * speed;
        CheckDirection(velocity.x);
        rigid.velocity = velocity;
        player.ConsumeWeight(Time.fixedDeltaTime, 0.01f + 0.05f * velocity.magnitude);
    }

    public void Freeze()
    {
        freezed = true;
        rigid.velocity = Vector2.zero;
    }

    public void UnFreeze()
    {
        freezed = false;
    }
}
