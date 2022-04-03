using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodManager manager;   
    [SerializeField] private float weightGain = 1;
    public float WeightGain {get => weightGain; private set => weightGain = value;}
    private float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
    }

    public void SetManager(FoodManager manager)
    {
        this.manager = manager;
    }

    private void OnTriggerStay2D(Collider2D collider){
        // cannot be eaten when playing appear animation
        if(lifeTime < 1)
            return;
        if(collider.GetComponent<Pig>()){
            collider.GetComponent<Pig>().EatFood(this);
            manager.RemoveFood(this);
            AudioManager.Instance.PlaySFX(SFXFileName.Eat);
            Destroy(gameObject);
        }
    }
}
