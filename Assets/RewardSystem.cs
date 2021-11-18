using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    private int totalPlayerKills=0;
    public int killsForHealthPotion=10;
    public int killsForRageMode=20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increaseKill(){
        this.totalPlayerKills++;
        if(totalPlayerKills%2==0){
            PlayerAccess.getStats().addRageMode();
        }
        if(totalPlayerKills%1==0){
            PlayerAccess.getStats().addHealthPotions();

        }
    }


}
