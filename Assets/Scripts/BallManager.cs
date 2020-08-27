using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallManager : MonoBehaviour
{
    public static int ballSpeed = 4;

    public static int ballsActive = 0;

    [SerializeField] int baseBallSpeed = 4;
    [SerializeField] int pointsLostOnBallLost = 100;

    [SerializeField] GameObject ballPrefab = null;

    [SerializeField] int blocksDestroyedToSpeedUp = 5;
    [SerializeField] int speedUpAmount = 1;
    [SerializeField] int maxSpeed = 9;
    [SerializeField] GameObject playBallText = null;
    [SerializeField] TextMeshProUGUI nextBallText = null;
    [SerializeField] TextMeshProUGUI activeBallText = null;
    [SerializeField] GameObject speedUpText = null;
    [SerializeField] AudioSource ballSpawnAudio = null;
    [SerializeField] AudioSource ballDestroyAudio = null;


    [SerializeField] GameObject ballDestroyText = null;

    [SerializeField] LevelLoader levelLoader = null;

    List<Ball> balls = new List<Ball>();

    float ballStartTime = 0.0f;

    void Start()
    {

    }

    public static Vector2 RandomDirection(bool canFaceDown)
    {
        Vector2 direction = Vector2.up;

        float angle = Random.Range(30, 60);

        direction = Quaternion.Euler(0, 0, angle) * direction;

        direction.x *= Random.Range(0, 100) > 50 ? -1.0f : 1.0f;
        direction.y *= (Random.Range(0, 100) > 50 && canFaceDown) ? -1.0f : 1.0f;


        return direction.normalized;
    }

    public void MakeBall(bool canFaceDown, Transform t)
    {
        GameObject go = Instantiate(ballPrefab, t.position, t.rotation);
        go.transform.parent = transform;
        Ball ball = go.GetComponent<Ball>();
        ball.direction = RandomDirection(canFaceDown);
        balls.Add(ball);
        ball.colorIndex = (ballSpeed - baseBallSpeed);
        ballSpawnAudio.Play();
    }
    public void MakeBall(bool canFaceDown)
    {
        MakeBall(canFaceDown, transform);
    }

    void SetBallActiveText()
    {
        string text = "Active Balls: ";

        if(balls.Count < 4)
        {
            text += balls.Count;
        }
        else if(balls.Count < 6)
        {
            text += "A lot!";
        }
        else
        {
            text += "Woah!";
        }

        activeBallText.text = text;
    }

    void Update()
    {
        ballsActive = balls.Count;

        float nextBallTime = Mathf.Max(0.0f, Mathf.Min(15.0f, 15.0f - (levelLoader.time - ballStartTime)));

        nextBallText.text = "Next Ball In: 00:" + string.Format("{0}", Mathf.Floor(nextBallTime).ToString("00"));
        SetBallActiveText();

        if (balls.Count == 0)
        {

            playBallText.SetActive(!levelLoader.levelComplete);
            
            Block.blocksDestroyed = 0;
            ballSpeed = baseBallSpeed;
            //reset
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
			{
                MakeBall(true);
                playBallText.SetActive(false);
                levelLoader.levelStarted = true;
                ballStartTime = levelLoader.time;
			}
        }
        else
        {
            if (levelLoader.time - ballStartTime > 15)
            {
                MakeBall(false);
                ballStartTime = levelLoader.time;
            }


        }

        if (Block.blocksDestroyed >= blocksDestroyedToSpeedUp)
        {
            Block.blocksDestroyed -= blocksDestroyedToSpeedUp;
            if(ballSpeed < maxSpeed)
            {
                Instantiate(speedUpText);
                foreach(Ball b in balls)
                {
                    b.ChangeColor((ballSpeed - baseBallSpeed) + 1);
                }
            }
            ballSpeed = Mathf.Min(ballSpeed + speedUpAmount, maxSpeed);
        }

        if(levelLoader.levelStarted == false)
        {
            foreach(Ball b in balls)
            {
                Destroy(b.gameObject);
            }
            balls.Clear();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //the ball manager's collider is below the paddles
    {
        if (collision.collider.CompareTag("Ball"))
        {
            balls.Remove(collision.collider.GetComponent<Ball>());
            Destroy(collision.gameObject);

            levelLoader.score = Mathf.Max(0, levelLoader.score - pointsLostOnBallLost);
            //we've lost a ball

            GameObject go = Instantiate(ballDestroyText, collision.transform.position, Quaternion.identity);
            go.GetComponent<TextMeshPro>().text = "-" + pointsLostOnBallLost;
            ballDestroyAudio.Play();
        }
    }
}
