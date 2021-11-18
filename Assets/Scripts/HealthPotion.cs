using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickupItem
{
    [SerializeField] private static int potionPower;
    // Start is called before the first frame update


 

    public override void interactSpecific()
    {
        PlayerAccess.getStats().CurrentHealth += potionPower;
    }
}
