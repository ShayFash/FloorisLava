using System;
using UnityEngine;
public class TriangleAttackCollider : AttackCollider
{
   

    private Vector2[] vertices,verticesReverse;

    new void Start()
    {
        base.Start();



        vertices = new Vector2[3]
        {
             new Vector2(viewCentre.x- (viewLength/2),-(viewHeight/2)),
                    new Vector2(viewCentre.x- (viewLength/2),(viewHeight/2)),
                    new Vector2(viewCentre.x,0)
        };

        if (bothSide)
        {
            verticesReverse = new Vector2[3]
            {
                new Vector2(viewCentre.x+ (viewLength/2),-(viewHeight/2)),
                new Vector2(viewCentre.x+ (viewLength/2),(viewHeight/2)),
                new Vector2(viewCentre.x,0)


            };
        }

        polygonCollider.SetPath(0, vertices);
        if(bothSide)
        polygonCollider.SetPath(1, verticesReverse);

    }

   
    public override ColliderType getColliderType()
    {
        return ColliderType.TRIANGLE;
    }



    public override void OnDrawGizmosSelected()
    {

        if (Helper.DEV_MODE!=DevMode.DEPLOY)
        {

          
            Gizmos.DrawWireMesh(getMesh(), Vector3.zero, Quaternion.identity);

            if (bothSide)
            {
              
                Gizmos.DrawWireMesh(getMesh(true), Vector3.zero, Quaternion.identity);


            }

        }
    }

    private Mesh getMesh(bool reverse=false)
    {
        Mesh triangleMesh = new Mesh();
        if (reverse)
        {
            triangleMesh.vertices = new Vector3[3]
             {
                    new Vector2(viewCentre.x- (viewLength/2),-(viewHeight/2)),
                    new Vector2(viewCentre.x- (viewLength/2),(viewHeight/2)),
                    new Vector2(viewCentre.x,0),


             };
        }
        else
        {
            triangleMesh.vertices = new Vector3[3]
            {
                new Vector3(viewCentre.x+ (viewLength/2),-(viewHeight/2),0),
                new Vector3(viewCentre.x+ (viewLength/2),(viewHeight/2),0),
                new Vector3(viewCentre.x,0,0),


            };
        }

        triangleMesh.triangles = new int[3] { 0, 1, 2 };

        triangleMesh.normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward };
        return triangleMesh;
    }
  
}
