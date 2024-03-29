﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    enum ePowerUp{
        NONE,
        EXTRA_BALL,
        SCORE_MULTIPLIER_TWO,
        SCORE_MULTIPLIER_THREE
    }

    [SerializeField] Sprite pinballSprite = null;
    [SerializeField] Sprite timesTwoSprite = null;
    [SerializeField] Sprite timesThreeSprite = null;
    [SerializeField] SpriteRenderer powerUpRenderer = null;
    [SerializeField] ePowerUp powerUp = ePowerUp.NONE;
    [SerializeField] GameObject particles = null;
    [SerializeField] int scoreValue = 100;
    [SerializeField] public bool spawnAnotherBlock = false;
    [SerializeField] GameObject blockSpawned = null;
    [SerializeField] Color blockSpawnedColor = default;

    [HideInInspector] public static int blocksDestroyed = 0;

    LevelLoader levelLoader = null;

    void Start()
    {
        levelLoader = GetComponentInParent<LevelLoader>();
        if(levelLoader != null)
		{
            levelLoader.blocksLeft += 1;
		}
        if(powerUp == ePowerUp.EXTRA_BALL)
        {
            powerUpRenderer.sprite = pinballSprite;
        }
        else if(powerUp == ePowerUp.SCORE_MULTIPLIER_TWO)
        {
            powerUpRenderer.sprite = timesTwoSprite;
        }
        else if(powerUp == ePowerUp.SCORE_MULTIPLIER_THREE)
        {
            powerUpRenderer.sprite = timesThreeSprite;
        }
    }

    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag("Ball"))
		{
            if(levelLoader == null)
            {
                levelLoader = GetComponentInParent<LevelLoader>();
            }


            GameObject go = Instantiate(particles, transform.position, Quaternion.identity);
            ParticleSystem ps = go.GetComponent<ParticleSystem>();
            var settings = ps.main;
            Color c = GetComponent<SpriteRenderer>().color;
            settings.startColor = c;
            TextMeshPro text = go.GetComponentInChildren<TextMeshPro>();
            text.color = c;

            if(powerUp == ePowerUp.EXTRA_BALL)
            {
                levelLoader.ballManager.MakeBall(true, transform);
                powerUp = ePowerUp.NONE;
            }
            else if (powerUp == ePowerUp.SCORE_MULTIPLIER_TWO)
            {
                levelLoader.scoreMultiplier *= 2;
                go.GetComponentInChildren<FloatingText>().playMultiplierAudio = true;
            }
            else if (powerUp == ePowerUp.SCORE_MULTIPLIER_THREE)
            {
                levelLoader.scoreMultiplier *= 3;
                go.GetComponentInChildren<FloatingText>().playMultiplierAudio = true;
            }
            if(levelLoader != null)
            {
                text.text = "" + scoreValue * BallManager.ballsActive * levelLoader.scoreMultiplier;
                blocksDestroyed++;
                levelLoader.blocksLeft -= 1;
                levelLoader.AddScore(scoreValue);
            }

            if(spawnAnotherBlock)
            {
                LevelLoader loader = GetComponentInParent<LevelLoader>();
                blockSpawned.GetComponent<SpriteRenderer>().color = blockSpawnedColor;
                blockSpawned.transform.position = transform.position;
                blockSpawned.transform.rotation = transform.rotation;
                loader.CreateBlock(blockSpawned, transform.parent);
            }
            

            Destroy(this);
            Destroy(go, 1.0f);
            Destroy(gameObject, 0.01f);

            

        }
	}
}
