using System;
using System.Collections;

using UnityEngine;

public abstract class EnemyRange : Enemy, IOnAnimatonFinished
{
    public GameObject toShoot;

    public Transform shootPoint;

    new void Start()
    {
        base.Start();

    }
    public override IEnumerator attackHelper(String attackType)
    {
        animator.SetTrigger(attackType);
        yield return new WaitForSeconds(secondsPerAttack);
        isAttacking = false;
    }

    public void rangeAI()
    {


        if (hasCollisionHappened())
        {
            float playerX = player.transform.position.x;
            float playerY = player.transform.position.y;

            float currX = transform.position.x;
            if (playerX - currX > 0)
            {
                if (directionState != Direction.RIGHT)
                {
                    Helper.rotate180(transform);
                    directionState = Direction.RIGHT;
                }

            }
            else
            {
                if (directionState != Direction.LEFT)
                {
                    Helper.rotate180(transform);
                    directionState = Direction.LEFT;
                }
            }
            if (canAttack())
            {
                attack("attack");


            }


        }
    }

    
     



    
    /// <summary>
    /// Function is called when attack animation finishes
    /// Need CallFunctionOnExit behaviour attached to the attack animator state
    /// </summary>
    /// <param name="animationName"></param>

    public abstract void execute(string animationName);
    
}

