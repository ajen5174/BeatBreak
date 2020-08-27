using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float cooldown = 2.0f;
    [SerializeField] float secondsToLast = 0.5f;
    [SerializeField] SpriteRenderer effectRenderer = null;
    [SerializeField] GameObject controlText = null;

    float cooldownTimer = 0.0f;
    float secondsActiveTimer = 0.0f;

    bool active = false;

    BoxCollider2D collider = null;
    SpriteRenderer renderer = null;

    void TogglePaddle(bool fadeIn)
	{
        Color tempColor = renderer.color;
        tempColor.a = fadeIn ? 1.0f : 0.0f;
        renderer.color = tempColor;

        active = fadeIn;
        cooldownTimer = 0.0f;
        collider.enabled = fadeIn;

    }

    public void ButtonPressed()
    {
        if (cooldownTimer > cooldown)
        {
            TogglePaddle(true);
            if(controlText != null)
            {
                Destroy(controlText);
            }
        }
    }

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        TogglePaddle(false);

        cooldownTimer = cooldown + 1.0f;
    }

    void Update()
    {

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
        else
        {
            cooldownTimer += Time.deltaTime;
            Vector2 scale = Vector2.zero + Vector2.one * (cooldownTimer / cooldown);
            effectRenderer.transform.localScale = scale.x > 1 ? Vector2.one : scale;
        }
    }
}
