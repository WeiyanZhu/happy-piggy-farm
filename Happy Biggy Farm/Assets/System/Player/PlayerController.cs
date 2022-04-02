using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;
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
        float xSpeed = inputAction.Player.Move.ReadValue<Vector2>().x * speed;
        float ySpeed = inputAction.Player.Move.ReadValue<Vector2>().y * speed;
        CheckDirection(xSpeed);
        rigid.velocity = new Vector2(xSpeed, ySpeed);
        animator.SetFloat("speed", Mathf.Abs(xSpeed));
    }

    private void CheckDirection(float xSpeed)
    {
        if(xSpeed > 0)
        {
            TurnRight();
        }else if(xSpeed < 0)
        {
            TurnLeft();
        }
    }

    public void TurnLeft()
    {
        Vector3 newScale = spriteRenderer.transform.localScale;
        newScale.x = -Mathf.Abs(newScale.x);
        spriteRenderer.transform.localScale = newScale;
    }

    public void TurnRight()
    {
        Vector3 newScale = spriteRenderer.transform.localScale;
        newScale.x = Mathf.Abs(newScale.x);
        spriteRenderer.transform.localScale = newScale;
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
