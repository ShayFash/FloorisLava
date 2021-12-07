using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour,IOnAnimatonFinished
{
    private MoveUp moveUp;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        moveUp = GetComponent<MoveUp>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Freeze()
    {
        animator.SetTrigger("freeze");
        moveUp.stop();
        
    }

    public void execute(string animationName)
    {
        moveUp.start();
    }
}
