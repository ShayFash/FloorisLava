using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpear : EnemyMelee
{

    private int direction = 1; //can only be 1 or -1

    private bool playerFound = false;

    public Transform forwardPoint;

    [SerializeField]
    private Transform leftBlocker ;

    [SerializeField]
    private Transform rightBlocker;


    private float leftBlockerPosition, rightBlockerPosition;


    private void Awake()
    {

        leftBlockerPosition = leftBlocker.position.x;

        rightBlockerPosition = rightBlocker.position.x;

        leftBlocker.SetParent(null);
        rightBlocker.SetParent(null);


    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector2(leftBlockerPosition + Mathf.Abs(rightBlockerPosition - leftBlockerPosition) / 2, transform.position.y), new Vector2(Mathf.Abs(rightBlockerPosition - leftBlockerPosition), enemyHeight));

        Gizmos.DrawWireCube(attackPoint.position,new Vector2(weaponLengthX,weaponHeightY));


    }



    void changeDirection()
    {
        direction *= -1;
        transform.RotateAround(transform.position, transform.up, 180f);

    }





    void FixedUpdate()
    {
        if (!isDead())
        {
            Collider2D collision = Physics2D.OverlapBox(new Vector2(leftBlockerPosition+Mathf.Abs(rightBlockerPosition - leftBlockerPosition)/2,transform.position.y), new Vector2(Mathf.Abs(rightBlockerPosition-leftBlockerPosition), enemyHeight), 0, playerLayer);
            if (collision != null)
            {
                playerFound = true;
            }
            else
            {
                playerFound = false;
            }


            Collider2D nearCollision = Physics2D.OverlapCircle(forwardPoint.position, 0.5f, obstacleLayer);


            if ((Mathf.Abs(leftBlockerPosition - transform.position.x) <= 0.1f && direction == -1)

                || (Mathf.Abs(rightBlockerPosition - transform.position.x) <= 0.1f && direction == 1))
            {
                changeDirection();
            }
            else
            {
                if (!playerFound)
                {

                    if (nearCollision != null)
                    {
                        changeDirection();

                    }


                    enemy.velocity = new Vector2(movementSpeed * direction, enemy.velocity.y);

                }
                else if (playerFound && nearCollision != null)
                {

                    //when object in the way is destroyable
                    if (nearCollision.gameObject.GetComponent<DestroyableObject>() != null)
                    {
                        enemy.velocity = new Vector2(0, 0);
                        attack();
                    }
                    else
                    {
                        direction *= -1;
                        transform.RotateAround(transform.position, transform.up, 180f);

                    }



                }
                else if (playerFound)
                {

                    float distance = player.position.x - forwardPoint.position.x;



                    int dir = distance < 0 ? -1 : 1;



                    if (Mathf.Abs(distance) <= Helper.playerWidth)
                    {

                        attack();

                        enemy.velocity = new Vector2(0, 0);


                    }
                    else
                    {
                        if (dir != direction)
                        {
                            direction = dir;
                            Helper.rotate180(transform);
                        }

                        enemy.velocity = new Vector2(dir * movementSpeed, enemy.velocity.y);


                    }




                }


                
            }

            if (Mathf.Abs(enemy.velocity.x) > 0.1f)
            {
                animator.SetBool("running", true);

            }
            else
            {
                animator.SetBool("running", false);

            }

        }



       




    }

   
}
