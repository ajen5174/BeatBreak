using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleManager : MonoBehaviour
{
	[SerializeField] Paddle[] paddles = null;


	private void Start()
	{
		
	}

	private void Update()
	{
		Keyboard keyboard = Keyboard.current;

		if(keyboard.dKey.wasPressedThisFrame)
		{
			paddles[0].ButtonPressed();
		}
		if (keyboard.fKey.wasPressedThisFrame)
		{
			paddles[1].ButtonPressed();
		}
		if (keyboard.jKey.wasPressedThisFrame)
		{
			paddles[2].ButtonPressed();
		}
		if (keyboard.kKey.wasPressedThisFrame)
		{
			paddles[3].ButtonPressed();
		}
	}

}
