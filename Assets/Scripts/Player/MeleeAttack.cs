using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeAttack : MonoBehaviour , IPlayerAttack
{
    public Transform stabPoint;
    public Transform heavyPoint;
    public LayerMask attackableObjects;
    public int attackPower;
    public float stabRange;
    public float heavyRange;

    private Animator animator;
    public float attackDuration = 0.4f;
    private Vector2 attackPosition;
    private float attackRange;
    private Collider2D[] collisions;

    public GameObject stabImpact, heavyImpact;


    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Helper.MOBILE_TESTING&&PlayerAttack.canAttack())
        {
            if ( Input.GetButtonDown("Fire1") )
            {
                attack(PlayerActionType.STAB);



            }
            else if (Input.GetButtonDown("Fire2")  )
            {

                attack(PlayerActionType.HEAVY);
            }
        }
    }


    IEnumerator attack(Attack at)
    {
        PlayerAttack.lockAttacks();
        animator.SetTrigger(at.Animation);

       



        yield return new WaitForSeconds(at.AttackHitTime); 

        if (at.Type == PlayerActionType.HEAVY)
        {

            attackPosition = heavyPoint.position;
            attackRange = heavyRange;
        }
        else if (at.Type == PlayerActionType.STAB)
        {

            attackPosition = stabPoint.position;
            attackRange = stabRange;
        }

        collisions = Physics2D.OverlapCircleAll(attackPosition, attackRange, attackableObjects);


        foreach (Collider2D obj in collisions)
        {
            IDamageTaker damageTaker = obj.GetComponent<IDamageTaker>();
            if (damageTaker != null)
            {
                damageTaker.takeDamage((int)(attackPower * at.Power));
                Instantiate(stabImpact, stabPoint.position, Quaternion.identity);

            }
        }


            yield return new WaitForSeconds(at.SecondsPerAttack-at.AttackHitTime);

        PlayerAttack.unlockAttacks();


    }



   

    public void attack(PlayerActionType playerAttackType)
    {

        if (PlayerAttack.canAttack())
        {

            switch (playerAttackType)
            {
                case PlayerActionType.STAB:
                    StartCoroutine(attack(Helper.playerAttack1));

                    break;
                case PlayerActionType.HEAVY:
                    StartCoroutine(attack(Helper.playerAttack2));
                    break;

                


            }

        }
       
    }




}
