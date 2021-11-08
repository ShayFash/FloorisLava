using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ShootingPower
{
    public float speed = 20f;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb.velocity = transform.right * speed;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
