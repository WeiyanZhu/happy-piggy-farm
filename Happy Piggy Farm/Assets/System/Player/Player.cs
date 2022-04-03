using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pig
{
    [SerializeField] private GameObject swordSprite;
    private bool equipedSword = false;
    public bool EquipedSword {get => equipedSword; private set => equipedSword = value; }

    protected override void Start()
    {
        base.Start();
        swordSprite.SetActive(false);
    }

    public void EquipSword()
    {
        swordSprite.SetActive(true);
        equipedSword = true;
    }
}
