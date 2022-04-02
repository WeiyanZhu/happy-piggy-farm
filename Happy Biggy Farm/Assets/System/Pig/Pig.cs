using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pig : MonoBehaviour
{
    protected float weight = 50;
    private float speedBase = 10;
    [SerializeField] private TextMeshProUGUI weightText;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }

    public void EatFood(Food food)
    {
        
    }

    public float GetSpeed(){
        return speedBase;
    }

    private void OnWeightChange(){
        
    }
}
