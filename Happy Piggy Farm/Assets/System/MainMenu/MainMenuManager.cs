using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private bool canControl = true;
    [SerializeField] private GameObject playerSwordSprite;
    [SerializeField] private GameObject curtain;

    void Start(){
        AudioManager.Instance.PlayMusic(BGMFileName.MainMenu);
        playerSwordSprite.SetActive(SystemManager.Instance.NewGamePlus);
    }

    public void NewGameButton()
    {
        if(!canControl)
            return;
        canControl = false;
        AudioManager.Instance.PlaySFX(SFXFileName.UIClickPig);
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine()
    {
        curtain.SetActive(true);
        yield return new WaitForSeconds(1);
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
