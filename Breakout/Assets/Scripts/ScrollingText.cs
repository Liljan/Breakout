using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour {

    public float speed = 0.1f;
    private float x, y, z;

	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        y += speed * Time.deltaTime;
        transform.position = new Vector3(x, y, z);
	}
}
