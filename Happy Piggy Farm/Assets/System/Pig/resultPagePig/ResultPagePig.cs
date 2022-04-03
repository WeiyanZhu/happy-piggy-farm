using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultPagePig : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI weightText;

    public void DieAnimation()
    {
        animator.SetTrigger("Die");
        AudioManager.Instance.PlaySFX(SFXFileName.Stab);
    }

    public void UpdateInfo(Pig pig)
    {
        if(pig.Dead)
        {
            gameObject.SetActive(false);
            return;
        }
        float weight = pig.Weight;
        weightText.text = TextLibrary.Instance.GetText("game", "weight") + " : " + (Mathf.Round(weight * 100) /100.0f).ToString();
    }
}
