using UnityEngine;
using System.Collections;

public class ScoreAnimation : MonoBehaviour
{
    public float time = 1f;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, time);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.4f * Time.deltaTime);
    }

    public void SetLabel(string s)
    {
        GetComponent<TextMesh>().text = s;
    }
}
