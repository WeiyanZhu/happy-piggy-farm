using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPageManager : MonoBehaviour
{
    [SerializeField] private List<ResultPagePig> resultPagePigs = new List<ResultPagePig>();
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject surviveUI;

    public void LastDayCheckResult()
    {
        // kill player
        // display end game stuff
    }

    public void CheckResult(List<Pig> pigs)
    {
        SetUpPage();
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

        // kill pigs
        resultPagePigs[fattest].DieAnimation();
        resultPagePigs[thinnest].DieAnimation();
        pigs[fattest].Die();
        pigs[thinnest].Die();
        // continue or end game
        if(pigs[0].Dead)
        {

        }else{
            surviveUI.SetActive(true);
        }
    }

    private void SetUpPage()
    {
        surviveUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        gameObject.SetActive(false);
        gameManager.SetupNewDay();
    }

    public void BackToMainMenuButton()
    {

    }
}
