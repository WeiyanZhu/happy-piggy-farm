using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : Singleton<SystemManager> 
{
    private Language language = Language.English;
    public Language Language {get => language; set => language = value;}
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
