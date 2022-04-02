using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Animator animator;
    private bool freezed = false;
    void Start()
    {
        
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
        //InputManager inputManager = SystemManager.instance.InputManager;
        float speed = player.GetSpeed();
        /*float xSpeed = inputManager.Action.Player.Move.ReadValue<Vector2>().x * speed; //* Time.deltaTime * 60;
        CheckDirection(xSpeed);
        rigid.velocity = new Vector2(xSpeed, rigid.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(xSpeed));*/
    }
}
