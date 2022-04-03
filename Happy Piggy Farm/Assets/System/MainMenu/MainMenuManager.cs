using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private bool canControl = true;

    void Start(){
        AudioManager.Instance.PlayMusic(BGMFileName.MainMenu);
    }

    public void NewGameButton()
    {
        if(!canControl)
            return;
        canControl = false;

        AudioManager.Instance.PlaySFX(SFXFileName.UIClickPig);
        SceneManager.LoadScene("Game");
    }

    [Header("Language")]
    [SerializeField] private SetTextWithJSON[] mainMenuTexts;

    public void ChangeLanguageButton()
    {
        AudioManager.Instance.PlaySFX(SFXFileName.UIClickPig);
        int len = System.Enum.GetNames(typeof(Language)).Length;
        //switch to the next language
        Language newLan = (Language) (((int)(SystemManager.Instance.Language) + 1)%len);
        ChangeLanguage(newLan);
    }

    public void ChangeLanguage(Language lan)
    {
        if(SystemManager.Instance.Language != lan)
        {
            SystemManager.Instance.Language = lan;
            foreach(SetTextWithJSON t in mainMenuTexts){
                t.UpdateValue();
            }
        }
    }
}
