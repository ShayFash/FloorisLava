using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour
{

    public GameObject player;
    public GameObject Coin;
    [SerializeField] private GameObject glory;
    public static int HEALTH_POTION_COINS = 300;
    public static int RAGE_MODE_COINS = 600;

    public static int SNOW_POTION_COINS = 400;

    private float playerHeight;
    private int totalKills;
    private int totalPlayerKills=0;
    public int killsForHealthPotion=10;
    public int killsForRageMode=20;
    public ScoreBar scoreBar;
    private int score;
    // private bool check;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            PlayerAccess.getStats().CurrentScore=score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalKills = 0;
        score = 0;
        playerHeight = 0;
        Score = 0;
        // check = true;
        Glory();
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.transform.position.y;
        calculateScore();
        Glory();
        
    }

    private void calculateScore()
    {
        int updatedScore = (int)(playerHeight * 10) + totalPlayerKills * 100;
        if (updatedScore > Score)
        {
            Score = updatedScore;
            
        }
    }

    public void increaseKill()
    {
        this.totalPlayerKills++;
        this.totalKills++;
        if (totalPlayerKills % 3 == 0)
        {
            PlayerAccess.getStats().addRageMode();
        }

        if (totalPlayerKills % 2 == 0)
        {
            PlayerAccess.getStats().addHealthPotion();

        }
    }
    public void Glory()
    {
        glory = GameObject.FindWithTag("glory");
        player= GameObject.FindWithTag("Player");
        Debug.Log(totalKills);
        if (totalKills>0)
        {        Debug.Log("total");

            glory.GetComponent<Text>().enabled = true;
            
            if (!PlayerAccess.getMovement().LookingRight)
            {
                Helper.rotate180(glory.transform);
            }
            else
            {
                Helper.rotate180(glory.transform);
            }
                
            Invoke("Hide",5f);
            
                
        }
        else
        {
            glory.GetComponent<Text>().enabled = false;

        }
            
        
        
    }

    private void Hide()
    {
        glory.GetComponent<Text>().enabled = false;
        totalKills = 0;

    }
    
}


