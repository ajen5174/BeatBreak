using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject[] levels = null;
    [SerializeField] int levelIndex = 0;
    [SerializeField] TextMeshProUGUI levelUI = null;
    [SerializeField] TextMeshProUGUI timeUI = null;
    [SerializeField] public BallManager ballManager = null;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI highScoreText = null;
    [SerializeField] GameObject completeLevelTextPrefab = null;

    [SerializeField] GameObject nextLevelButton = null;

    GameObject endScreenText = null;

    private GameObject currentLevel = null;

    [HideInInspector] public int blocksLeft = 0;

    int frameCounter = 0;

    [HideInInspector] public bool levelComplete = false;

    [HideInInspector] public bool levelStarted = false;

    [HideInInspector] public float time = 0.0f;

    [HideInInspector] public int score = 0;
    
    [HideInInspector] public int scoreMultiplier = 1;

    public void AddScore(int scoreToAdd)
    {
        score += BallManager.ballsActive * scoreToAdd * scoreMultiplier;
    }

    public void LoadNextLevel()
    {

        Destroy(endScreenText);

        time = 0.0f;
        
        score = 0;
        scoreMultiplier = 1;
        Destroy(currentLevel);

    }

    void Start()
    {
        levelIndex = PlayerPrefs.GetInt("levelToLoad");
        PlayerPrefs.SetInt("levelToLoad", 0);
        currentLevel = Instantiate(levels[levelIndex], transform);
        time = 0.0f;
        scoreMultiplier = 1;
    }

    void Update()
    {
        if (levelStarted)
        {
            time += Time.deltaTime;
        }
        timeUI.text = "Time: " + string.Format("{0}:{1}", Mathf.Floor(time / 60).ToString("00"), Mathf.Floor(time % 60).ToString("00"));
        scoreText.text = "Score: " + (score);
        levelUI.text = "Level: " + (levelIndex + 1);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt(levelUI.text);
        
        if(levelComplete && endScreenText == null)
        {
            levelIndex++;
            if (levelIndex < levels.Length)
            {
                nextLevelButton.SetActive(false);

                currentLevel = Instantiate(levels[levelIndex], transform);

            }
            else
            {
                //here we have completed the last level, so we need to go back to the title screen or something.
            }
            Debug.Log("Level Complete");
            levelComplete = false;
        }

        if (blocksLeft == 0)
        {
            if (frameCounter < 5)
            {
                frameCounter++;
                return;
            }
            
            if (PlayerPrefs.GetInt(levelUI.text) < score)
            {
                PlayerPrefs.SetInt(levelUI.text, score);
            }

            levelComplete = true;
            levelStarted = false;
            nextLevelButton.SetActive(true);

            if (endScreenText == null)
            {
                endScreenText = Instantiate(completeLevelTextPrefab);
            }

        }

        frameCounter = 0;
    }
}
