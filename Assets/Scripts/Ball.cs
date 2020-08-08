using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    private Rigidbody2D body = null;
    bool collidedThisFrame = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(-0.707f, -0.707f) * speed;
    }

    void FixedUpdate()
    {
        collidedThisFrame = false;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Ball") || collidedThisFrame)
		{
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
        collidedThisFrame = true;

    }
}
