using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject[] levels = null;
    [SerializeField] int levelIndex = 0;

    private GameObject currentLevel = null;

    [HideInInspector] public int blocksLeft = 0;

    int frameCounter = 0;

    void Start()
    {
        levelIndex = PlayerPrefs.GetInt("levelToLoad");
        Debug.Log(levelIndex);
        PlayerPrefs.SetInt("levelToLoad", 0);
        currentLevel = Instantiate(levels[levelIndex], transform);
    }

    void Update()
    {
        if(blocksLeft == 0)
        {
            if(frameCounter < 5)
			{
                frameCounter++;
                return;
			}
            Destroy(currentLevel);
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
