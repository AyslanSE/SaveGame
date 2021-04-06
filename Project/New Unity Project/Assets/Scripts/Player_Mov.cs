using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player_Mov : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] private float speed;
    private bool lookD, lookE, run;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift))
            run = true;
        else
            run = false;

        if (Input.GetKey(KeyCode.D))
        {
            speed += 1;

            if (run == true)
            {
                if (speed >= 50)
                    speed = 50;
            }
            else
            {
                if (speed >= 5)
                speed = 5;
            }
            lookD = false;
            Flip();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed += -1;

            if (run == true)
            {
                if (speed <= -50)
                    speed = -50;
            }
            else
            {
                if (speed <= -5)
                    speed = -5;
            }
            lookD = true;
            Flip();
        }
        else
            speed = 0;
    }
    void Flip()
    {
        if((lookD && !lookE)||(!lookD && lookE))
        {
            lookE = !lookE;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}