using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAttackCollider : AttackCollider
{
    private Vector2[] vertices,verticesReverse;

    new void Start()
    {
        base.Start();
        vertices = new Vector2[4]
        {
            new Vector2(viewCentre.x-viewLength/2,viewCentre.y-viewHeight/2),
            new Vector2(viewCentre.x-viewLength/2,viewCentre.y+viewHeight/2),
            new Vector2(viewCentre.x+viewLength/2,viewCentre.y+viewHeight/2),
            new Vector2(viewCentre.x+viewLength/2,viewCentre.y-viewHeight/2),

        };

        polygonCollider.SetPath(0, vertices);

        if (bothSide)
         {
                verticesReverse = new Vector2[4]
                   {
                        new Vector2(-viewCentre.x-viewLength/2,viewCentre.y-viewHeight/2),
                        new Vector2(-viewCentre.x-viewLength/2,viewCentre.y+viewHeight/2),
                        new Vector2(-viewCentre.x+viewLength/2,viewCentre.y+viewHeight/2),
                        new Vector2(-viewCentre.x+viewLength/2,viewCentre.y-viewHeight/2),

                   };
            polygonCollider.SetPath(1, verticesReverse);

        }
    }

    public override ColliderType getColliderType()
    {
        return ColliderType.BOX;
    }


    public override void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(viewCentre, new Vector2(viewLength, viewHeight));

    }
}
