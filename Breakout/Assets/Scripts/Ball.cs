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
        rb2d.AddForce(new Vector2(forceMag, forceMag));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetForceMag()
    {
        return forceMag;
    }
}
