using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField] float speed = 3.0f;

    [HideInInspector] public Vector2 direction = new Vector2(-0.707f, -0.707f);

    private Rigidbody2D body = null;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = direction * BallManager.ballSpeed;
    }

    void FixedUpdate()
    {
        body.velocity = body.velocity.normalized * BallManager.ballSpeed;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{


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


    }
}
