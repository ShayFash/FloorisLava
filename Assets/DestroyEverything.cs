using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEverything : MonoBehaviour
{

    public int damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageTaker damageTaker = collision.GetComponent<IDamageTaker>();

        if (damageTaker != null)
        {
            damageTaker.takeDamage(damage);
        }
    }
}