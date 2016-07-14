using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public int health = 1;
    public int score = 100;

    public GameObject ScoreTextPrefab;
    public GameObject ParticlePrefab;

    private static LevelHandler levelhandler;

    // Use this for initialization
    void Start()
    {
        levelhandler = GameObject.FindObjectOfType<LevelHandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag.Equals("Ball"))
        {
            this.TakeDamage(1);
            if (health <= 0)
                Kill();
        }
    }

    void TakeDamage(int d) { health -= d; Debug.Log("Take damage"); }

    private void Kill()
    {
        Instantiate(ParticlePrefab, transform.position, transform.rotation);
        GameObject sa = Instantiate(ScoreTextPrefab, transform.position, transform.rotation) as GameObject;
        sa.GetComponent<TextMesh>().text = score.ToString();

        levelhandler.AddScore(score);
        Destroy(this.gameObject);
    }
}
