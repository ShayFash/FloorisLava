using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour
{
    // Start is called before the first frame update
    public  TextMeshProUGUI coinValueText;
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCoins(int coins)
    {
        
        coinValueText.SetText(coins.ToString());
    }
}
