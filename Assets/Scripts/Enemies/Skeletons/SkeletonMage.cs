using System;
using UnityEngine;

public class SkeletonMage : EnemyRange
{

    public static float arrowDamage = 30f;







    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, 0f), new Vector3(2 * viewRange, enemyHeight, 0f));
    }
    private void FixedUpdate()
    {

        rangeAI();

    }

    public void instantiateArrow()
    {
        GameObject arr = Instantiate(toShoot, shootPoint.position, transform.rotation);
    }



    public override void execute(string animationName)
    {
        instantiateArrow();

    }


}

