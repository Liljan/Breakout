using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float forceMag = 1f;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.AddForce(new Vector2(forceMag, forceMag));
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure the ball is not stuck in x-axis

        if (rb2d.velocity.x > 0f && rb2d.velocity.x < 0.3f)
        {
            rb2d.velocity = new Vector2(0.3f, rb2d.velocity.y);
        }
        else if (rb2d.velocity.x < 0 && rb2d.velocity.x > -0.3f)
        {
            rb2d.velocity = new Vector2(-0.3f, rb2d.velocity.y);
        }

        // Make sure the ball is not stuck in y-axis

        if (rb2d.velocity.y > 0f && rb2d.velocity.y < 0.3f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0.3f);
        }
        else if (rb2d.velocity.x < 0 && rb2d.velocity.x > -0.3f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -0.3f);
        }
    }

    public void EnableKinematic(bool b)
    {
        rb2d.isKinematic = b;
    }

    public float GetForceMag()
    {
        return forceMag;
    }

    public void SetForceMag(float f)
    {
        forceMag = f;
    }

    public void AddForce(float f)
    {
        rb2d.AddForce(new Vector2(f, forceMag));
    }

    public void AddForce()
    {
        rb2d.AddForce(new Vector2(forceMag, forceMag));
    }

    public void AddForce(bool right)
    {
        if (right)
            rb2d.AddForce(new Vector2(-forceMag, forceMag));
        else
            rb2d.AddForce(new Vector2(forceMag, forceMag));
    }
}
