using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PigController
{
    [SerializeField] private Player player;
    private DefaultInputAction inputAction;
    void Start()
    {
        inputAction = new DefaultInputAction();
        inputAction.Enable();
    }

    void FixedUpdate()
    {
        if(freezed)
            return;
        Move();
    }

    private void Move()
    {
        float speed = player.GetSpeed();
        float xSpeed = inputAction.Player.Move.ReadValue<Vector2>().x;
        float ySpeed = inputAction.Player.Move.ReadValue<Vector2>().y;
        Vector2 velocity = new Vector2(xSpeed, ySpeed).normalized * speed;
        animator.SetFloat("speed", velocity.magnitude);
        CheckDirection(velocity.x);
        rigid.velocity = velocity;
        player.ConsumeWeight(Time.fixedDeltaTime, 0.01f + 0.05f * velocity.magnitude);
    }
}
