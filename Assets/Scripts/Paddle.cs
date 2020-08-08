using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float cooldown = 2.0f;
    [SerializeField] float secondsToLast = 0.5f;

    float cooldownTimer = 0.0f;
    float secondsActiveTimer = 0.0f;

    bool active = false;

    BoxCollider2D collider = null;
    SpriteRenderer renderer = null;

    void Fade(bool fadeIn)
	{
        Color tempColor = renderer.color;
        tempColor.a = fadeIn ? 1.0f : 0.0f;
        renderer.color = tempColor;

        active = fadeIn;
        cooldownTimer = 0.0f;
        collider.enabled = !fadeIn;

    }

    public void ButtonPressed()
    {
        if (cooldownTimer > cooldown)
        {
            Color tempColor = renderer.color;
            tempColor.a = 1.0f;
            renderer.color = tempColor;

            active = true;
            cooldownTimer = 0.0f;
            collider.enabled = true;
        }
    }

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        Color tempColor = renderer.color;
        tempColor.a = 0.0f;
        renderer.color = tempColor;

        active = false;
        secondsActiveTimer = 0.0f;
        collider.enabled = false;

        cooldownTimer = cooldown;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(active)
		{
            secondsActiveTimer += Time.deltaTime;

            //fade here
            


            if(secondsActiveTimer > secondsToLast)
			{
                Color tempColor = renderer.color;
                tempColor.a = 0.0f;
                renderer.color = tempColor;

                active = false;
                secondsActiveTimer = 0.0f;
                collider.enabled = false;
			}
		}
    }
}
