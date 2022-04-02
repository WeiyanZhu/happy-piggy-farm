using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D movingArea;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Get a point on map that the NPC can move to
    public List<Vector2> GetMovingBoundary()
    {
        Vector2 xRange = new Vector2(movingArea.bounds.center.x - movingArea.bounds.extents.x,
                                    movingArea.bounds.center.x + movingArea.bounds.extents.x);
        Vector2 yRange = new Vector2(movingArea.bounds.center.y - movingArea.bounds.extents.y,
                                    movingArea.bounds.center.y + movingArea.bounds.extents.y);
        List<Vector2> result = new List<Vector2>();
        result.Add(xRange);
        result.Add(yRange);
        return result;
    }
}
