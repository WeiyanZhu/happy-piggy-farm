using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int day = 1;
    [SerializeField] private List<Pig> pigs;
    [SerializeField] private Timer timer;
    [SerializeField] private FoodManager foodManager;
    [SerializeField] private ResultPageManager resultPageManager;
    // Start is called before the first frame update
    void Start()
    {
        day = 0;
        SetupNewDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Enter End Day to show result of the day, then go to next day
    public void EndDay()
    {
        resultPageManager.CheckResult(pigs);
        foodManager.Freeze();
        foreach(Pig p in pigs)
            p.GetComponent<PigController>().Freeze();
    }

    public void SetupNewDay()
    {
        day += 1;
        foodManager.Reset();
        timer.ReStart();
        foreach(Pig p in pigs)
            p.GetComponent<PigController>().UnFreeze();
    }
}
