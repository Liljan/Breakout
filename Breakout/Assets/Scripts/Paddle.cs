using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    // public
    public float speed = 10f;

    // private
    private float xAxis;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        Debug.Log(xAxis);

        if (xAxis == 0f)
            rb2d.velocity = Vector2.zero;
        else if (xAxis < 0f)
            rb2d.velocity = new Vector2(-speed, 0f);
        else //if (xAxis > 0f)
            rb2d.velocity = new Vector2(speed, 0f);
    }
}
