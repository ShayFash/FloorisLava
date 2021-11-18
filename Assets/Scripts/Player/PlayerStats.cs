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

    private int healthPotions;
    private int rageModes;
    public float RagingTime=5f;

    public PowerUpCanvas powerUpCanvas;

    

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
                PlayerAccess.getInstance().GetComponent<Animator>().SetTrigger("hurt");
            }else
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

    public void addHealthPotions(){
        healthPotions++;
        powerUpCanvas.NumHealthPotions=healthPotions;

    }

    public void useHealthPotion(){
        if(healthPotions>0){
            healthPotions--;
            
        }
    }
    
    public void useRageMode(){
        if(rageModes>0&&!IsRaging){
            rageModes--;
            IsRaging = true;
        }
    }

    public void addRageMode(){
        rageModes++;
        powerUpCanvas.NumRageModes=rageModes;

    }
    
}
