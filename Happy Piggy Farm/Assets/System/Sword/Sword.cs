using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(SystemManager.Instance.NewGamePlus);
    }

    private void OnTriggerStay2D(Collider2D collider){
        if(collider.GetComponent<Player>()){
            collider.GetComponent<Player>().EquipSword();
            AudioManager.Instance.PlaySFX(SFXFileName.Equip);
            Destroy(gameObject);
        }
    }
}
