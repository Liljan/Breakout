using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    public Material mat;
    public Vector2 scrollSpeed;
    private Vector2 offset; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        mat.mainTextureOffset += scrollSpeed*Time.deltaTime;

       // mat.SetTextureOffset(texID,offset + scrollSpeed * Time.deltaTime);
	}
}
