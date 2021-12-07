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
    private int multiplier;
    private bool isRaging,isRaginCont;
    private Animator animator;

    private int healthPotions,snowPotions;
    private int rageModes;
    public float RagingTime=7f;
    public int defense;
    public PowerUpCanvas powerUpCanvas;
    public GameObject blood;
    public ScoreBar scoreBar;
    public Transform bloodPoint;
    private int currentScore;



    public int HealthPotions
    {
        get { return healthPotions; }
        set
        {
            if (value >= 0)
            {
                healthPotions = value;
                powerUpCanvas.NumHealthPotions = value;
            }
        }
    }

 
    public int RageModes
    {
        get { return rageModes; }
        set
        {
            if (rageModes >= 0)
            {
                rageModes = value;
                powerUpCanvas.NumRageModes = value;
            }
        }
    }
    

    public bool IsRaging{
        get{return isRaging;}
        set{
            if (value)
            {
                StartCoroutine(startRaging());
            }
            
            animator.SetBool("isRaging",value);

            
            isRaging=value;
            
        }
    }

    private IEnumerator startRaging()
    {

        yield return new WaitForSeconds(RagingTime);
        IsRaging = false;
    }

    public int Multipler{
        get{return multiplier;}
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < currentHealth)
            {
                Instantiate(blood, bloodPoint.position, Quaternion.identity);
                PlayerAccess.getInstance().GetComponent<Animator>().SetTrigger("hurt");
            }
            currentHealth = value>0?value:0;
            healthBar.setHealth(currentHealth);
        }
    }

    public int CurrentScore{
        get{return currentScore;}
        set{
            currentScore=value;
            scoreBar.CurrentScore = currentScore;

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
        multiplier=1;
        animator=GetComponent<Animator>();
        healthPotions=0;
        rageModes=0;
        isRaging = false;
        isRaginCont = false;

    }

 
    
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            useHealthPotion();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            useRageMode();
            
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            useSnowPotion();
        }
    }

    public SaveableData saveObject()
    {
        SaveableData data = new PlayerData(CurrentHealth,CurrentMoney,CurrentScore, transform.position.x,transform.position.y,PlayerAccess.getMovement().LookingRight);
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
                CurrentScore = playerData.score;
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
        CurrentHealth -= damage/defense;
    }

    public void addHealthPotion()
    {
        HealthPotions++;
    }

    public void useHealthPotion(){
        if(CurrentMoney>RewardSystem.HEALTH_POTION_COINS){
            CurrentHealth += HealthPotion.PotionPower;
            CurrentMoney -= RewardSystem.HEALTH_POTION_COINS;
        }
    }
    
    public void useRageMode(){
        if(CurrentMoney>RewardSystem.RAGE_MODE_COINS&&!IsRaging)
        {
            CurrentMoney -= RewardSystem.RAGE_MODE_COINS;
            IsRaging = true;
        }
    }

    public void useSnowPotion()
    {
        if(CurrentMoney>RewardSystem.SNOW_POTION_COINS)
        {
            CurrentMoney -= RewardSystem.SNOW_POTION_COINS;
            LavaAccess.getInstance().Freeze();
        }
        
    }

    public void addRageMode()
    {
        RageModes++;
    }
    
}
