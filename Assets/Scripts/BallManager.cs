using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallManager : MonoBehaviour
{
    public static float ballSpeed = 4;

    public static int ballsActive = 0;


    [SerializeField] GameObject ballPrefab = null;

    [SerializeField] int blocksDestroyedToSpeedUp = 5;
    [SerializeField] float speedUpAmount = 1;
    [SerializeField] float maxSpeed = 9.0f;

    List<Ball> balls = new List<Ball>();

    void Start()
    {
        
    }

    void Update()
    {
        if (balls.Count == 0)
        {
            //reset
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
			{
                GameObject ball = Instantiate(ballPrefab, transform);
                balls.Add(ball.GetComponent<Ball>());
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
