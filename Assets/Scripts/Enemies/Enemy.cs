using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageTaker, IAttacker,IEnemy
{
    public float health = 100f;
    public float movementSpeed = 5f;
    public float viewRange = 3f;
    public float defense = 10f;
    public int attackPower = 30;
    public float enemyHeight = 1.3f;


    protected Direction directionState=Direction.RIGHT;

    protected AttackCollider attackCollider;
    

    public float secondsPerAttack;


    public LayerMask playerLayer;

    protected Animator animator;
    protected Rigidbody2D enemy;
    protected Rigidbody2D player;


    private bool dead = false;

    protected bool isAttacking = false;

    public void Start()
    {  
        animator = GetComponent<Animator>();

        enemy = GetComponent<Rigidbody2D>();
        player = PlayerAccess.getInstance().GetComponent<Rigidbody2D>();
        attackCollider = GetComponentInChildren<AttackCollider>();
    }

    public bool canAttack()
    {
        return !isAttacking;
    }

    public void takeDamage(int damage)
    {
        animator.SetTrigger("hurt");

        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public bool isDead()
    {
        return dead;
    }

    public void attack(String attackType="attack")
    {
        if (!isAttacking && !isDead())
        {
            isAttacking = true;
        


            StartCoroutine(attackHelper( attackType));
        }
        else
        {
            return;
        }
    }

    public abstract IEnumerator attackHelper(String attackType);


    public bool hasCollisionHappened()
    {
        return attackCollider.hasCollisionHappened();
    }



    IEnumerator Die()
    {
        dead = true;

        animator.SetBool("dead", true);
        yield return new WaitForSeconds(0.8f);

        gameObject.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);




    }

    public  void onPlayerEncountered()
    {

    }
    
}
