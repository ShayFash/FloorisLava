using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour,IDamageTaker
{

    public float defense;
    public float health;
    private Animator animator;
    



   public void setParams(float defense , float health, Animator animator)
    {
        this.defense = defense;
        this.health = health;
        this.animator = animator;

    }

    public void takeDamage(int attStrength)
    {
        health -= attStrength;
        if (health <= 0)
        {
            StartCoroutine(destruct());
        }

    }


    IEnumerator destruct()
    {
        animator.SetBool("destroyed", true);
        yield return new WaitForSeconds(0.4f);

        gameObject.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);

    }

 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
