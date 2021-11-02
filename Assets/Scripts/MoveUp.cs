using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public bool toStop = false;
    private float startingPositionY;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity= transform.up * speed;

        if (toStop)
        {
            startingPositionY = transform.position.y;
        }
    }
    private void Awake()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (toStop)
        {
            if (transform.position.y > startingPositionY + height)
            {
                Destroy(gameObject);
            }
        }

    }
}
