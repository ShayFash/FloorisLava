using System;
using System.Collections;

using UnityEngine;

 public abstract class EnemyMelee : Enemy
{
    public Transform attackPoint;
    public float weaponLengthX;
    public float weaponHeightY;
    public float attackHitDuration;
    public float distanceBetweenCenters = 3f;
    public LayerMask obstacleLayer;


    private Vector2 attackSize;
    new void Start()
    {
        base.Start();
        attackSize = new Vector2(weaponLengthX, weaponHeightY);

    }

    public override IEnumerator attackHelper(String attackType)
    {



        animator.SetTrigger(attackType);
        yield return new WaitForSeconds(attackHitDuration);

       
        if (attackPoint != null)
        {
            Collider2D[] allCollisons = Physics2D.OverlapBoxAll(attackPoint.position, attackSize, 0, playerLayer);
            foreach (Collider2D collider in allCollisons)
            {

                IDamageTaker dTaker = collider.GetComponent<IDamageTaker>();
                if (dTaker != null)
                {
                    dTaker.takeDamage(attackPower);
                }
            }
        }

        

        yield return new WaitForSeconds(secondsPerAttack - attackHitDuration);
        isAttacking = false;

    }


  
}

