using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : SpawnableObject
{
private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Helper.playerCollisionHappened(collision))
        {
            //Debug.Log("Contact");
            animator.SetBool("inContact", true);
            Invoke("destroy", 3f);
        }

    }

    private void destroy()
    {
        Destroy(gameObject);
    }

}
