using UnityEngine;
using System.Collections;

public class LargerPad : MonoBehaviour
{
    private LevelHandler levelHandler;
    public float time = GLOBALS.LONGER_PAD_TIME;
    public float scale = 2f;

    void Start()
    {
        levelHandler = GameObject.FindObjectOfType<LevelHandler>();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ball"))
        {
            levelHandler.StartCoroutine(levelHandler.EnableLongerPad(time, scale));
        }
    }
}
