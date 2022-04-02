using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float secondsInDay;
    private float timer = 0;
    private bool active = false;
    [SerializeField] private Image timerFillImage;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            timer += Time.deltaTime;
            UpdateUI();
            if(timer > secondsInDay){
                active = false;
            }
        }
    }

    private void UpdateUI()
    {
        timerFillImage.fillAmount = timer / secondsInDay;
    }

    public void ReStart()
    {
        timer = 0;
        active = true;
    }

    public void TimerFinish()
    {
        gameManager.EndDay();
    }
}
