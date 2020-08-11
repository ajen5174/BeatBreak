using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallManager : MonoBehaviour
{
    public static float ballSpeed = 4;

    public static int ballsActive = 0;

    [SerializeField] int baseBallSpeed = 4;

    [SerializeField] GameObject ballPrefab = null;

    [SerializeField] int blocksDestroyedToSpeedUp = 5;
    [SerializeField] float speedUpAmount = 1;
    [SerializeField] float maxSpeed = 9.0f;
    [SerializeField] GameObject playBallText = null;

    List<Ball> balls = new List<Ball>();

    void Start()
    {

    }

    Vector2 RandomDirection()
    {
        Vector2 direction = Vector2.up;

        float angle = Random.Range(30, 60);

        direction = Quaternion.Euler(0, 0, angle) * direction;

        direction.x *= Random.Range(0, 100) > 50 ? -1.0f : 1.0f;
        direction.y *= Random.Range(0, 100) > 50 ? -1.0f : 1.0f;


        return direction.normalized;
    }

    void Update()
    {
        if (balls.Count == 0)
        {
            playBallText.SetActive(true);
            Block.blocksDestroyed = 0;
            ballSpeed = baseBallSpeed;
            //reset
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
			{
                GameObject go = Instantiate(ballPrefab, transform);
                Ball ball = go.GetComponent<Ball>();
                ball.direction = RandomDirection();
                balls.Add(ball);
                playBallText.SetActive(false);
			}
        }

        if (Block.blocksDestroyed >= blocksDestroyedToSpeedUp)
        {
            Block.blocksDestroyed -= blocksDestroyedToSpeedUp;
            ballSpeed = Mathf.Min(ballSpeed + speedUpAmount, maxSpeed);
            Debug.Log("Speed up");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //the ball manager's collider is below the paddles
    {
        if (collision.CompareTag("Ball"))
        {
            balls.Remove(collision.GetComponent<Ball>());
            Destroy(collision.gameObject);

            //we've lost a ball
        }
    }
}
