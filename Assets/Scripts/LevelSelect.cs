﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    [SerializeField] GameObject[] levels = null;
    [SerializeField] GameObject content = null;
    [SerializeField] GameObject levelSelectionUI = null;
    [SerializeField] Camera levelCamera = null;

    private RenderTexture originalTex = null;

    public void ToTitle()
    {
        SceneManager.LoadScene("TitleScreen");

    }

    void Start()
    {
        originalTex = levelCamera.targetTexture;
        for(int i = 0; i < levels.Length; i++)
		{
            RenderTexture renderTexture = new RenderTexture(1024, 720, 16, RenderTextureFormat.ARGB32);
            GameObject current = Instantiate(levelSelectionUI, content.transform);
            current.name = "Level" + (i + 1);
            current.GetComponentInChildren<TextMeshProUGUI>().text = "" + (i + 1);
            //current.transform.position += new Vector3((i % 5) * (Camera.main.scaledPixelWidth / 5), -1 * (i / 5) * (Camera.main.scaledPixelHeight / 3), 0.0f);
            GameObject currentLevelBlocks = Instantiate(levels[i], new Vector3(-30.0f, 0.0f, 0.0f), Quaternion.identity);
            levelCamera.targetTexture = renderTexture;
            levelCamera.Render();
            current.GetComponentInChildren<RawImage>().texture = renderTexture;
            currentLevelBlocks.SetActive(false);
            Destroy(currentLevelBlocks);
        }
        levelCamera.targetTexture = originalTex;
    }

    void Update()
    {
        
    }
}
