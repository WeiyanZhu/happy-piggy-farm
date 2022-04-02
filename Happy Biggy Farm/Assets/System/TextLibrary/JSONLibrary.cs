using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONLibrary<T> : Singleton<T> where T : JSONLibrary<T> 
{
    protected Dictionary<Language, string> languageToTextDict = new Dictionary<Language, string>(){
        {Language.English, "English"},
        {Language.Chinese, "Chinese"}
    };
}
