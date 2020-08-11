using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
	int levelToLoad = 0;

    public void OnClick()
	{
		//load the level
		string number = name.Substring(5);
		
		levelToLoad = int.Parse(number) - 1;

		SceneManager.LoadScene("GameScene");

	}

	private void OnDisable()
	{
		if(levelToLoad != 0)
		{
			PlayerPrefs.SetInt("levelToLoad", levelToLoad);
		}
	}
}
