using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : Singleton<SystemManager> 
{
    private Language language = Language.English;
    public Language Language {get => language; set => language = value;}
    private bool newGamePlus = false;
    public bool NewGamePlus {get => newGamePlus; set => newGamePlus = value;}
    protected override void Awake()
    {
        base.Awake();
        if(PlayerPrefs.HasKey("NewGamePlus") && PlayerPrefs.GetString("NewGamePlus") == "true")
        {
            SystemManager.Instance.NewGamePlus = true;
        }
        SystemManager.Instance.NewGamePlus = true;
    }

    void Update()
    {
        
    }
}
