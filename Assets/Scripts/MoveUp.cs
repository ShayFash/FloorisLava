using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 5f;
    public float currentSpeed;
    private Rigidbody2D rb;
    public bool toStop = false;
    private float startingPositionY;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start();

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
        rb.velocity= transform.up * currentSpeed;

    }

    public void stop()
    {
        currentSpeed = 0;
    }

    public void start()
    {
        currentSpeed = speed;
    }
}
