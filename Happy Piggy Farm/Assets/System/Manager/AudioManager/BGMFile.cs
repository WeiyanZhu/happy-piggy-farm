using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public enum BGMFileName
{
    None = 0,
    MainMenu = 1,
    Farm = 2,
    ResultOfTheDay = 3
}

public enum SFXFileName
{
    UIClickPig = 3,
    UIHover = 0,
    Eat = 1,
    Stab = 2,
    TimeUp = 4,
    Equip = 5
}

[System.Serializable]
public class BGMFile
{
    public BGMFileName name;
    public AudioClip clip;
}

[System.Serializable]
public class SFXFile
{
    public SFXFileName name;
    public AudioClip clip;
}