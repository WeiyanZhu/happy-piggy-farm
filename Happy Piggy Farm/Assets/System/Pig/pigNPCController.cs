using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigNPCController : PigController
{
    [SerializeField] private NPCManager manager;
    [SerializeField] private PigNPC npc;
    private Vector2 target;
    private float speedMod;

    void Start()
    {
        speedMod = Random.Range(0.1f, 1f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        animator.SetFloat("speed", rigid.velocity.magnitude);
        float speed = npc.GetSpeed();
        Vector2 diff = (target - new Vector2(transform.position.x, transform.position.y));
        Vector2 velocity = diff.normalized * speed * speedMod;
        CheckDirection(velocity.x);
        rigid.velocity = velocity;
        npc.ConsumeWeight(Time.fixedDeltaTime, 0.01f + 0.05f * velocity.magnitude);
        if(diff.magnitude < 0.1f){
            GetNewTarget();
        }
    }

    private void GetNewTarget()
    {
        List<Vector2> range = manager.GetMovingBoundary();
        target = new Vector2(Random.Range(range[0].x, range[0].y), Random.Range(range[1].x, range[1].y));
    }
}
