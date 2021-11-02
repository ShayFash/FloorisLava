using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour,Saveable,IDamageTaker
{
    public int maxHealth;

    private int currentHealth;
    private int currentMoney;
    public HealthBar healthBar;
    public CoinBar coinBar;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < currentHealth)
            {
                PlayerAccess.getInstance().GetComponent<Animator>().SetTrigger("hurt");
            }
            currentHealth = value;
            healthBar.setHealth(currentHealth);
        }
    }

    public int CurrentMoney
    {
        get { return currentMoney; }
        set
        {
            currentMoney = value;
            coinBar.setCoins(currentMoney);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar.init(maxHealth);
        CurrentMoney = 0;
        CurrentHealth = maxHealth;

    }

 
    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public SaveableData saveObject()
    {
        SaveableData data = new PlayerData(CurrentHealth,CurrentMoney, transform.position.x,transform.position.y,PlayerAccess.getMovement().LookingRight);
        return data;
    }

    public void loadObject(SaveableData data)
    {
        try
        {
            PlayerData playerData = data as PlayerData;
            if (playerData != null)
            {
                CurrentHealth = playerData.health;
                CurrentMoney = playerData.money;
                transform.position = playerData.posData.getVector3();
                PlayerAccess.getMovement().LookingRight = playerData.isLookingRight;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void takeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
