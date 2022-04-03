using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int day = 0;
    [SerializeField] private List<Pig> pigs;
    [SerializeField] private Timer timer;
    [SerializeField] private FoodManager foodManager;
    [SerializeField] private ResultPageManager resultPageManager;
    [SerializeField] private TextMeshProUGUI dayText;
    // Start is called before the first frame update
    void Start()
    {
        day = 0;
        foreach(Pig p in pigs)
            p.GetComponent<PigController>().Freeze();
        AudioManager.Instance.PlayMusic(BGMFileName.Farm);
        SetupNewDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Enter End Day to show result of the day, then go to next day
    public void EndDay()
    {
        AudioManager.Instance.PlayMusic(BGMFileName.None);
        AudioManager.Instance.PlaySFX(SFXFileName.TimeUp);
        foodManager.Freeze();
        foreach(Pig p in pigs)
            p.GetComponent<PigController>().Freeze();
        resultPageManager.CheckResult(pigs);
    }

    public void SetupNewDay()
    {
        day += 1;
        dayText.text = string.Format(TextLibrary.Instance.GetText("game", "day_x"), day);
        foodManager.Reset();
        timer.ReStart();
        AudioManager.Instance.PlayMusic(BGMFileName.Farm);
        foreach(Pig p in pigs)
            p.GetComponent<PigController>().UnFreeze();
    }
}
