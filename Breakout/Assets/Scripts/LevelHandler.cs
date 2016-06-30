using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    // UI
    public Text scoreText;
    public Text ballsText;

    // Gameplay
    public GameObject PadObject;
    public float startHeignt;
    public GameObject StartBallPrefab;

    private bool hasStarted = false;

    // Score & Statistics
    private int score = 0;
    private int amountOfBalls = 3;
    private int amountOfBlocks;
    private int totalAmountOfBlocks;


    // Use this for initialization
    void Start()
    {
        amountOfBlocks = GameObject.FindObjectsOfType<Brick>().Length;
        totalAmountOfBlocks = amountOfBlocks;

        scoreText.text = score.ToString();
        ballsText.text = amountOfBalls.ToString();

        StartRound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRound()
    {
        Transform rootTrans = PadObject.transform;
        Vector2 pos = new Vector2(rootTrans.position.x,rootTrans.position.y + startHeignt);
        GameObject newBall = Instantiate(StartBallPrefab, pos, rootTrans.rotation) as GameObject;

        PadObject.GetComponent<FixedJoint2D>().connectedBody = newBall.GetComponent<Rigidbody2D>();
        PadObject.GetComponent<Paddle>().Reset();
    }

    public void EndRound()
    {
        amountOfBalls--;
        ballsText.text = amountOfBalls.ToString();
        if(amountOfBalls > 0)
        {
            StartRound();
        }
    }
}
