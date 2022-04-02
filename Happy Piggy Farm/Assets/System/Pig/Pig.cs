using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pig : MonoBehaviour
{
    protected float weight = 50;
    private float speedBase = 2;
    [SerializeField] private TextMeshProUGUI weightText;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        OnWeightChange();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }

    public void EatFood(Food food)
    {
        ChangeWeight(weight + food.WeightGain);
    }

    public void ConsumeWeight(float deltaTime, float lostWeightSpeed = 1)
    {
        float weightLost = deltaTime * lostWeightSpeed;
        ChangeWeight(weight - weightLost);
    }

    private void ChangeWeight(float newWeight){
        //make sure weight doesnt become negative or unreasonably low
        weight = Mathf.Max(10, newWeight);
        OnWeightChange();
    }

    public float GetSpeed(){
        return speedBase;
    }

    private void OnWeightChange(){
        weightText.text = TextLibrary.Instance.GetText("game", "weight") + " : " + (Mathf.Round(weight * 100) /100.0f).ToString();
    }
}
