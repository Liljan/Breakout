using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    // UI
    public Text scoreText;
    public Text ballsText;
    public Text fpsText;
    public Text timeScaleText;
    public Text timeText;
    public float elapsedTime;

    // Gameplay
    public GameObject PadObject;
    public float startHeignt;
    public GameObject StartBallPrefab;

    private bool hasStarted = false;

    // power ups


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

        UpdateLabels();

        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDebugLabels();
        elapsedTime += Time.deltaTime;
    }

    public void StartRound()
    {
        Transform rootTrans = PadObject.transform;
        Vector2 pos = new Vector2(rootTrans.position.x, rootTrans.position.y + startHeignt);
        GameObject newBall = Instantiate(StartBallPrefab, pos, rootTrans.rotation) as GameObject;

        PadObject.GetComponent<FixedJoint2D>().connectedBody = newBall.GetComponent<Rigidbody2D>();
        PadObject.GetComponent<Paddle>().Reset();
    }

    public void EndRound()
    {
        amountOfBalls--;
        ballsText.text = amountOfBalls.ToString();
        if (amountOfBalls > 0)
        {
            StartRound();
        }
    }

    public void AddScore(int s)
    {
        score += s;
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        scoreText.text = score.ToString();
        ballsText.text = amountOfBalls.ToString();
    }

    private void UpdateDebugLabels()
    {
        fpsText.text = (1f / Time.deltaTime).ToString();
        timeScaleText.text = Time.timeScale.ToString();
        timeText.text = elapsedTime.ToString();
    }

    public IEnumerator EnableLongerPad(float time)
    {
        PadObject.transform.localScale = new Vector3(1f, 2f, 1f);
        yield return new WaitForSeconds(time);
        PadObject.transform.localScale = Vector3.one;
    }


}
