using UnityEngine;
using System.Collections;

public class BottomZone : MonoBehaviour
{
    private LevelHandler levelHandler;

    public void Start()
    {
        levelHandler = GameObject.FindObjectOfType<LevelHandler>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            // play sound    
            Destroy(other.gameObject);
            Debug.Log(GameObject.FindObjectsOfType<Ball>().Length);

            if (GameObject.FindObjectsOfType<Ball>().Length == 1)
            {
                levelHandler.EndRound();
            }
        }
    }
}
