using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float weightGain = 1;
    public float WeightGain {get => weightGain; private set => weightGain = value;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.GetComponent<Pig>()){
            collider.GetComponent<Pig>().EatFood(this);
            Destroy(gameObject);
        }
    }
}
