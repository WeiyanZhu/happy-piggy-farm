using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int day = 1;
    [SerializeField] List<Pig> pigs;
    [SerializeField] Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        SetupNewDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Enter End Day to show result of the day, then go to next day
    public void EndDay()
    {

    }

    public void SetupNewDay()
    {
        timer.ReStart();
    }
}
