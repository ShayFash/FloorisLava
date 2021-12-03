using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{

    public GameObject player;
    public GameObject Coin;

    private float playerHeight;
    private int totalKills;
    private int totalPlayerKills=0;
    public int killsForHealthPotion=10;
    public int killsForRageMode=20;
    public ScoreBar scoreBar;
    private int score;

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
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.transform.position.y;
        calculateScore();
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
        if (totalPlayerKills % 3 == 0)
        {
            PlayerAccess.getStats().addRageMode();
        }

        if (totalPlayerKills % 2 == 0)
        {
            PlayerAccess.getStats().addHealthPotion();

        }
    }


}
