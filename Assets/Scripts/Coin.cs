using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickupItem
{
    [Range(70,300)]
    [SerializeField] private int maxMoney;

    private int minMoney = 50;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
        money = Random.Range(minMoney, maxMoney);
        
    }

    // Update is called once per frame
    public override void interactSpecific()
    {
        PlayerAccess.getStats().CurrentMoney += money;
    }
}
