using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour,IPlayerAttack
{
    public Transform firePoint;
    public GameObject bullet;
    public float secondPerBullet = 0.55f;
    private Animator animator;
    private int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        multiplier = PlayerAccess.getStats().IsRaging ? 3 : 1;

        if (!Helper.MOBILE_TESTING&&PlayerAttack.canAttack())
        {
            if (Input.GetKeyDown("m"))
            {
                    StartCoroutine(attack());
            }
        }
    }



    IEnumerator attack()
    {
        animator.SetTrigger("magic1");
        PlayerAttack.lockAttacks();
        yield return new WaitForSeconds(0.25f);
        // bullet will be instatiated after animation finished from state behaviour
        Instantiate(bullet, firePoint.position, firePoint.rotation);

        yield return new WaitForSeconds(secondPerBullet-0.1f);
        PlayerAttack.unlockAttacks();

    }

    public void attack(PlayerActionType type)
    {
        if (PlayerAttack.canAttack())
        {
            switch (type)
            {
                case PlayerActionType.FIREBALL:
                    StartCoroutine(attack());
                    break;
            }
        }
    }

 
}
