using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ShootingPower
{ 

    private float targetX;
    private float targetY;
    private float initialX;
    private float initialY;
    private bool isLinear;

    public float minTime = 1f;

    public float variable = 0f;





    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    private float speed,linearSpeed;
    private float maxHeight;
    private float maxHeightDownward;

    private float downwardSpeedGravityDecrease = 2f;






    public void setTarget(float x, float y, float maxHeight,float maxHeightDownward, float gSpeed = 1f, bool isLinear = false, float lSpeed = 1f)
    {
        targetX = x;
        targetY = y;
        speed = gSpeed;
        this.maxHeightDownward = maxHeightDownward;
        this.maxHeight = maxHeight;
        this.isLinear = isLinear;
        linearSpeed = lSpeed;
    }

    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        initialX = transform.position.x;
        initialY = transform.position.y;
        float distX = targetX - initialX;

        float distY = targetY - initialY;

        float time = 0f;
        float yVelocity = 0f;
        float xVelocity;

        if (distY > maxHeight)
        {
            Debug.Log("should not happen");
        }
        if (distY > -0.5f && distY < 0.5f&&isLinear)
        {
            rb.gravityScale = 0;
            rb.velocity = transform.right * linearSpeed;

        }
        else
        {

            if (distY < 0f)
            {
                float gravScaleChange = 1f; // divide the scale and gravity with this value
                float constantTime = 0.8f;
                if (maxHeightDownward <= 0f)
                {
                    yVelocity = 0;
                    time = 0f;
                    gravScaleChange = (Physics2D.gravity.y * constantTime * constantTime) / (2 * -1 * (maxHeightDownward - distY)  );

                    rb.gravityScale /=gravScaleChange;


                }
                else
                {
                    yVelocity = Mathf.Sqrt(2f * -1 * Physics2D.gravity.y * maxHeightDownward); // velocity to reach maxheight as the heighest point

                    float determinant = Mathf.Pow(yVelocity, 2) + (2 * Physics2D.gravity.y * maxHeightDownward);
                    if (determinant > -0.001f)
                    {
                        determinant = 0f;
                    }
                    time = (-1 * yVelocity + Mathf.Sqrt(determinant)) / Physics2D.gravity.y;

                    Debug.Log(time);
                    if (time < 0f)
                        time = (-1 * yVelocity - Mathf.Sqrt(determinant)) / Physics2D.gravity.y;

                }




                float extraTime = Mathf.Sqrt(2 * -1 * (maxHeightDownward - distY) / (Physics2D.gravity.y/gravScaleChange));
                time += extraTime;
                Debug.Log(time + " " + extraTime);
                
               
            }

            else
            {
                yVelocity = Mathf.Sqrt(2f * -1 * Physics2D.gravity.y * maxHeight); // velocity to reach maxheight as the heighest point
               
                float determinant = Mathf.Pow(yVelocity, 2) + (2 * Physics2D.gravity.y * maxHeight);
                if (determinant > -0.001f)
                {
                    determinant = 0f;
                }
                time = (-1 *yVelocity+ Mathf.Sqrt(determinant))/ Physics2D.gravity.y;

                if(time<0f)
                    time = (-1 * yVelocity - Mathf.Sqrt(determinant)) / Physics2D.gravity.y;


                float extraTime = Mathf.Sqrt(2 * -1*(maxHeight - distY) / Physics2D.gravity.y);
                time += extraTime;
                

            }


            xVelocity = distX * speed / time;
            rb.velocity = new Vector2(xVelocity, yVelocity);

        }







    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    private void FixedUpdate()
    {

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg));


      


    }

  
}
