using UnityEngine;
using System.Collections;

public class ShootingPower : MonoBehaviour
{
    public int damage = 40;
    public LayerMask destroyableLayers;
    public GameObject impactEffect;
    protected Rigidbody2D rb;

    // Use this for initialization
    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & destroyableLayers) != 0)
        {
            IDamageTaker dObject = collision.GetComponentInParent<IDamageTaker>();


            if (dObject != null)
            {
                dObject.takeDamage(damage);
            }


            Instantiate(impactEffect, transform.position + transform.right, transform.rotation);

            Destroy(gameObject);
        }

    }
}
