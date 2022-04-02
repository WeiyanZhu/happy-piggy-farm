using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    [SerializeField] protected Transform spriteTransform;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Rigidbody2D rigid;
    protected void CheckDirection(float xSpeed)
    {
        if(xSpeed > 0)
        {
            TurnRight();
        }else if(xSpeed < 0)
        {
            TurnLeft();
        }
    }

    protected void TurnLeft()
    {
        Vector3 newScale = spriteTransform.transform.localScale;
        newScale.x = -Mathf.Abs(newScale.x);
        spriteTransform.transform.localScale = newScale;
    }

    protected void TurnRight()
    {
        Vector3 newScale = spriteTransform.transform.localScale;
        newScale.x = Mathf.Abs(newScale.x);
        spriteTransform.transform.localScale = newScale;
    }
}
