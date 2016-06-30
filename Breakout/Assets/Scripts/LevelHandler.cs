using UnityEngine;
using System.Collections;

public class LevelHandler : MonoBehaviour
{
    // Gameplay
    public GameObject PadObject;
    public float startHeignt;
    public GameObject StartBallPrefab;

    private bool hasStarted = false;

    // Score & Statistics
    private int score = 0;
    private int amountOfBlocks;
    private int totalAmountOfBlocks;


    // Use this for initialization
    void Start()
    {
        amountOfBlocks = GameObject.FindObjectsOfType<Brick>().Length;
        totalAmountOfBlocks = amountOfBlocks;

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
    }
}
