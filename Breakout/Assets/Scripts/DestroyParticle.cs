using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

    public float time = 1f;

	void Start () {
        Destroy(this.gameObject, time);
	}
}
