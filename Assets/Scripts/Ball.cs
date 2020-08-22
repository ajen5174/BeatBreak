using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField] float speed = 3.0f;

    [HideInInspector] public Vector2 direction = new Vector2(-0.707f, -0.707f);

    private Rigidbody2D body = null;
    private SpriteRenderer sprite = null;
    private TrailRenderer trail = null;
    private bool collidedThisFrame = false;

    public int colorIndex = 0;
    private Color[] trailColors = { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta, Color.white};

    public void ChangeColor(int ballSpeedLevel)
    {
        colorIndex = ballSpeedLevel;
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0].color = trailColors[colorIndex];
        colorKeys[0].time = 0.0f;
        colorKeys[1].color = Color.white; 
        colorKeys[1].time = 1.0f;

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 0.0f;
        alphaKeys[1].time = 1.0f;

        gradient.SetKeys(colorKeys, trail.colorGradient.alphaKeys);
        trail.colorGradient = gradient;

    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        body.velocity = direction * BallManager.ballSpeed;
        ChangeColor(colorIndex);
    }

    void FixedUpdate()
    {
        body.velocity = body.velocity.normalized * BallManager.ballSpeed;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collidedThisFrame)
        {
            Debug.Log("Double collided???");
            return;
        }

        Vector2 fromCollider = transform.position - collision.transform.position;

        float angle = Vector2.Angle(Vector2.up, fromCollider);

        float topRightAngle = Vector2.Angle(Vector2.up, new Vector2(collision.bounds.extents.x, collision.bounds.extents.y));

        float bottomRightAngle = Vector2.Angle(Vector2.up, new Vector2(collision.bounds.extents.x, -collision.bounds.extents.y));

        if(angle < topRightAngle || angle > bottomRightAngle)
		{
            //top or bottom hit
            body.velocity = new Vector2(body.velocity.x, -body.velocity.y);
		}
        else
		{
            //left or right hit
            body.velocity = new Vector2(-body.velocity.x, body.velocity.y);
		}
        //if(collision.CompareTag("Block"))
        {
            collidedThisFrame = true;
        }

        SpriteRenderer collidedSprite = collision.GetComponent<SpriteRenderer>();

        if(collidedSprite != null)
        {
            //sprite.color = new Color(0.5f, 0.5f, 0.5f) + collidedSprite.color;

        }

    }

    private void LateUpdate()
    {
        collidedThisFrame = false;
    }
}
