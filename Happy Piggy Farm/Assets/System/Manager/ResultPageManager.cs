using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPageManager : MonoBehaviour
{
    [SerializeField] private List<ResultPagePig> resultPagePigs = new List<ResultPagePig>();
    [SerializeField] private GameManager gameManager;
    [Header("UI")]
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject mainMenuButton;

    public void LastDayCheckResult()
    {
        // kill player
        // display end game stuff
    }

    public void CheckResult(List<Pig> pigs)
    {
        SetUpPage();
        StartCoroutine(CheckResultRoutine(pigs));
    }

    private IEnumerator CheckResultRoutine(List<Pig> pigs)
    {
        int fattest = 0;
        int thinnest = 0;
        for(int x = 0; x < pigs.Count; ++x)
        {
            resultPagePigs[x].UpdateInfo(pigs[x]);
            // ignore dead pigs
            if(pigs[x].Dead)
            {
                continue;
            }
            // find fattest and thinnest pig
            if(pigs[x].Weight > pigs[fattest].Weight)
                fattest = x;
            if(pigs[x].Weight < pigs[thinnest].Weight)
                thinnest = x;
        }
        yield return new WaitForSeconds(2f);
        // kill pigs
        resultPagePigs[fattest].DieAnimation();
        yield return new WaitForSeconds(1f);
        resultPagePigs[thinnest].DieAnimation();
        yield return new WaitForSeconds(1f);
        pigs[fattest].Die();
        pigs[thinnest].Die();
        // continue or end game
        if(pigs[0].Dead)
        {
            mainMenuButton.SetActive(true);
        }else{
            nextButton.SetActive(true);
        }
    }

    private void SetUpPage()
    {
        nextButton.SetActive(false);
        mainMenuButton.SetActive(false);
        gameObject.SetActive(true);
        AudioManager.Instance.PlayMusic(BGMFileName.ResultOfTheDay);
    }

    public void ContinueButton()
    {
        AudioManager.Instance.PlaySFX(SFXFileName.UIClickPig);
        gameObject.SetActive(false);
        gameManager.SetupNewDay();
    }

    public void BackToMainMenuButton()
    {
        AudioManager.Instance.PlaySFX(SFXFileName.UIClickPig);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
