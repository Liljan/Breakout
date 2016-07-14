using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    // public
    public float speed = 10f;

    public float xMin = -2.27f, xMax = 2.27f;

    // private
    private float xAxis;

    private Rigidbody2D rb2d;
    private FixedJoint2D fixJoint2d;
    private BoxCollider2D bc2d;

    private bool hasStarted = false;

    // sticky pad
    /* private int stickyBounces = 0;
     private int maxStickyBounces;*/

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fixJoint2d = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");

        if (xAxis == 0f)
            rb2d.velocity = Vector2.zero;
        else if (xAxis < 0f)
            rb2d.velocity = new Vector2(-speed, 0f);
        else //if (xAxis > 0f)
            rb2d.velocity = new Vector2(speed, 0f);


        // shoot ball
        if (Input.GetButtonDown("Shoot") && !hasStarted)
        {
            Ball ball = fixJoint2d.connectedBody.GetComponentInParent<Ball>();
            if (ball != null)
            {
                fixJoint2d.connectedBody = null;
                fixJoint2d.enabled = false;
                hasStarted = false;

                ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                if (rb2d.velocity.x > 0f)
                {    
                    ball.AddForce(new Vector2(1f,1f));
                }
                else if(rb2d.velocity.x < 0f)
                {
                    ball.AddForce(new Vector2(-1f,1f));
                }
                else
                {
                    ball.AddForce(new Vector2(0f, 1f));
                }
            }
        }

        // debug speed
        if (Input.GetButtonDown("Speed"))
        {
            Time.timeScale = GLOBALS.SPEED_UP_SCALE;
        }
        else if (Input.GetButtonUp("Speed"))
        {
            Time.timeScale = 1f;
        }

        //clamp x-position
        /* transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax),
           transform.position.y); */
    }

    public void Reset()
    {
        hasStarted = false;
        fixJoint2d.enabled = true;
    }
}
