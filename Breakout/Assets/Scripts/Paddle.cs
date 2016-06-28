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
    private BoxCollider2D bc2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        // clamp x-position
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax), 
            transform.position.y);
    }
}
