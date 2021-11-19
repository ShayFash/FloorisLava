using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickupItem
{
    [SerializeField] public int potionPower;
    // Start is called before the first frame update

    public static int PotionPower;
    private void Start()
    {
        PotionPower = potionPower;
    }


    public override void interactSpecific()
    {
        PlayerAccess.getStats().CurrentHealth += potionPower;
    }
}
