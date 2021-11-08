using System;
using UnityEngine;
public static class Helper
{

    public const float playerWidth = 0.7f;

    public static bool MOBILE_TESTING=false;


    public const DevMode DEV_MODE = DevMode.DEBUG;

    public static void rotate180(Transform transform)
    {
        transform.RotateAround(transform.position, transform.up, 180f);
    }



    

    public static readonly Attack playerAttack1=new Attack(0.6f,0.4f,1f,"attack",PlayerActionType.STAB);
    public static readonly Attack playerAttack2 = new Attack(0.8f,0.5f,1.6f, "attack_heavy",PlayerActionType.HEAVY);

    public static bool collisionHappened(Collider2D collision, LayerMask layers)
    {
        if (((1 << collision.gameObject.layer) & layers) != 0)
        {
            return true;
        }
        return false;
    }

    public static bool collisionHappened(Collision2D collision, LayerMask layers)
    {
        if (((1 << collision.gameObject.layer) & layers) != 0)
        {
            return true;
        }
        return false;
    }


    public static bool playerCollisionHappened(Collider2D collision)
    {
        return collision.gameObject.Equals(PlayerAccess.getInstance());
    }

    public static bool playerCollisionHappened(Collision2D collision)
    {
        return collision.gameObject.Equals(PlayerAccess.getInstance());

    }
}
