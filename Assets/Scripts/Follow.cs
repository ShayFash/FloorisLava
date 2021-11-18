using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public float speed = 1f;

    private float startX;
    private float endX;

    private float dist;

    public Animator animator;
    private float nextX;
    

    
    // Start is called before the first frame update
    void Start()
    {
        //initialising gameobjects
        start = GameObject.FindGameObjectWithTag("Enemy");
        end = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed",Mathf.Abs(speed));
        // x positions
        startX = start.transform.position.x;
        endX = end.transform.position.x;
        
        //distance
        dist = endX - startX;
        //next x location
        nextX = Mathf.MoveTowards(transform.position.x, endX, speed * Time.deltaTime);
        Vector3 move = new Vector3(nextX, transform.position.y,transform.position.z);
        transform.position = move;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("is_ded",true);
            Invoke("destroy", 0.75f);
        }
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
