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

    private GameObject currentLevel = null;

    [HideInInspector] public int blocksLeft = 0;

    int frameCounter = 0;

    [HideInInspector] public bool levelStarted = false;

    [HideInInspector] public float time = 0.0f;

    void Start()
    {
        levelIndex = PlayerPrefs.GetInt("levelToLoad");
        PlayerPrefs.SetInt("levelToLoad", 0);
        currentLevel = Instantiate(levels[levelIndex], transform);
        time = 0.0f;
    }

    void Update()
    {
        timeUI.text = "Time: " + string.Format("{0}:{1}", Mathf.Floor(time / 60).ToString("00"), Mathf.Floor(time % 60).ToString("00"));
        if(levelStarted)
        {
            time += Time.deltaTime;
        }
        
        levelUI.text = "Level: " + levelIndex;
        if (blocksLeft == 0)
        {
            if(frameCounter < 5)
			{
                frameCounter++;
                return;
			}
            Destroy(currentLevel);

            time = 0.0f;
            levelStarted = false;
            levelIndex++;
            if(levelIndex < levels.Length)
			{
                currentLevel = Instantiate(levels[levelIndex], transform);

			}
			else
			{
                //here we have completed the last level, so we need to go back to the title screen or something.
			}
            Debug.Log("Level Complete");
        }

        frameCounter = 0;
    }
}
