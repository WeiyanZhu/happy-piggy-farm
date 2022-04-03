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
    [SerializeField] private GameObject surviveText;
    [SerializeField] private GameObject deadText;
    [SerializeField] private GameObject badEndText;


    public void CheckResult(List<Pig> pigs, int day)
    {
        SetUpPage();
        StartCoroutine(CheckResultRoutine(pigs, day));
    }

    private IEnumerator CheckResultRoutine(List<Pig> pigs, int day)
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
        pigs[fattest].Die();
        yield return new WaitForSeconds(1f);
        // if it's day 6 enter bad end
        if(day >= 6)
        {
            badEndText.SetActive(true);
            mainMenuButton.SetActive(true);
            yield break;
        }
        resultPagePigs[thinnest].DieAnimation();
        yield return new WaitForSeconds(1f);
        pigs[thinnest].Die();
        // continue or end game
        if(pigs[0].Dead)
        {
            deadText.SetActive(true);
            mainMenuButton.SetActive(true);
        }else{
            surviveText.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    private void SetUpPage()
    {
        nextButton.SetActive(false);
        mainMenuButton.SetActive(false);
        surviveText.SetActive(false);
        deadText.SetActive(false);
        badEndText.SetActive(false);

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
