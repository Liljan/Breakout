using UnityEngine;
using System.Collections;

public class BottomZone : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            // play sound
            Debug.Log("Zed's dead.");
            Destroy(other.gameObject);
        }
    }


}
