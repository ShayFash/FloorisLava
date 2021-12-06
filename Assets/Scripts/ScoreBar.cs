using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{

    public TextMeshProUGUI scoreTextGUI;

    private int currentScore;
    // Start is called before the first frame update
    public int CurrentScore
    {
        get{return currentScore;}
        set
        {
            currentScore = value;
            scoreTextGUI.SetText(currentScore.ToString());
        }
    }
    void Start()
    {
        CurrentScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
