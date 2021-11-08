using System;
using UnityEngine;

public class SkeletonArrow:EnemyRange
{

    public static float arrowDamage = 30f;
    public float linearArrowSpeed = 10f;
    [SerializeField]
    private float maxHeight;

    [SerializeField]
    private float maxHeightDownward;

   
    private void FixedUpdate()
    {

        rangeAI();

    }

    public  void instantiateArrow()
    {
        GameObject arr = Instantiate(toShoot, shootPoint.position, transform.rotation);
        arr.GetComponent<Projectile>().setTarget(player.transform.position.x, player.transform.position.y,maxHeight,maxHeightDownward,1f,true,linearArrowSpeed);
    }



    public override void execute(string animationName)
    {
        instantiateArrow();

    }

   
}

