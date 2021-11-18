using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PowerUpCanvas : MonoBehaviour
{

    public TextMeshProUGUI numHealthPotionsText;
    public TextMeshProUGUI numRageModesText;

    private int numHealthPotions;
    public int NumHealthPotions{
        get{return numHealthPotions;}
        set{
            numHealthPotions=value;
            numHealthPotionsText.SetText(numHealthPotions.ToString());
        }
    }

    private int numRageModes;
    public int NumRageModes{
        get{return numRageModes;}
        set{
            numRageModes=value;
            numRageModesText.SetText(numRageModes.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

}