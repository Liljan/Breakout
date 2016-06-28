using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject BallPrefab;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ball"))
        {
            float oldForceMag = coll.gameObject.GetComponent<Ball>().GetForceMag();
            GameObject newBall = Instantiate(BallPrefab, transform.position, transform.rotation) as GameObject;
            newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-oldForceMag, oldForceMag));
        }
    }
}
