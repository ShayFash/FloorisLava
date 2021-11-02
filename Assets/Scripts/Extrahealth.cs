using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Extrahealth : MonoBehaviour
{

    private int maxhealth;
    public Image fill;
    public void SetmaxHealth(int health)
    {
        maxhealth = health;
        fill.fillAmount = (float)health/(float)maxhealth;

    }

    public void SetHealth(int health)
    {
        fill.fillAmount = (float)health / (float)maxhealth;
    }

}

