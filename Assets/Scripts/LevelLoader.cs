using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
    [SerializeField] AudioSource nextLevelAudio = null;
    [SerializeField] AudioSource levelCompleteAudio = null;

    GameObject endScreenText = null;

    private GameObject currentLevel = null;

    [HideInInspector] public int blocksLeft = 0;

    int frameCounter = 0;

    [HideInInspector] public bool levelComplete = false;

    [HideInInspector] public bool levelStarted = false;

    [HideInInspector] public float time = 0.0f;

    [HideInInspector] public int score = 0;
    
    [HideInInspector] public int scoreMultiplier = 1;

    bool audioPlayed = false;

    public void CreateBlock(GameObject block, Transform parent)
    {
        blocksLeft++;
        Vector3 position = block.transform.position;
        Quaternion rotation = block.transform.rotation;
        GameObject copy = Instantiate(block, new Vector3(-1000, 0, 0), Quaternion.identity);
        block.GetComponent<Block>().spawnAnotherBlock = false;
        StartCoroutine(CreateBlockAfter(copy, parent, position, rotation, 0.05f));

    }

    IEnumerator CreateBlockAfter(GameObject block, Transform parent, Vector3 position, Quaternion rotation, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        block.transform.parent = parent;
        block.transform.position = position;
        block.transform.rotation = rotation;
    }

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
        audioPlayed = false;
        nextLevelAudio.Play();
        frameCounter = 0;
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
                SceneManager.LoadScene("LevelSelect");
            }
            levelComplete = false;
        }

        if (transform.GetComponentInChildren<Block>() == null)
        {


            if (frameCounter < 30)
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

            //audio
            if(!audioPlayed)
            {
                levelCompleteAudio.Play();
                audioPlayed = true;
            }

            if (endScreenText == null)
            {
                endScreenText = Instantiate(completeLevelTextPrefab);
            }

        }

        frameCounter = 0;
    }
}
