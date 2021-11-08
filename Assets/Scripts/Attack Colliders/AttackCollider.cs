using System;
using UnityEngine;
public abstract class AttackCollider:MonoBehaviour
{
    [SerializeField]
    protected Vector2 viewCentre;

    [SerializeField]
    protected float viewLength;


    [SerializeField]
    protected float viewHeight;
    [SerializeField]
    protected bool bothSide;

    protected bool playerCollision;

    protected PolygonCollider2D polygonCollider;

    protected Enemy enemy;

    protected int numPaths;
    public void Start()
    {
        numPaths = bothSide ? 2 : 1;
        playerCollision = false;
        polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.pathCount = numPaths;
        enemy = GetComponentInParent<Enemy>();

       
    }


    public abstract ColliderType getColliderType();

    public abstract void OnDrawGizmosSelected();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Helper.playerCollisionHappened(collision))
        {
            playerCollision = true;
            enemy.onPlayerEncountered();
            
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Helper.playerCollisionHappened(collision))
        {
            playerCollision = false;

        }
    }

    public bool hasCollisionHappened()
    {
        return playerCollision;
    }




}
