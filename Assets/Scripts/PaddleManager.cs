using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleManager : MonoBehaviour
{
	[SerializeField] Paddle[] paddles = null;

	[SerializeField] PlayerInput input = null;

	private void Start()
	{

	}

	void OnDAction()
	{
		paddles[0].ButtonPressed();
	}

	void OnFAction()
	{
		paddles[1].ButtonPressed();
	}

	void OnJAction()
	{
		paddles[2].ButtonPressed();
	}

	void OnKAction()
	{
		paddles[3].ButtonPressed();
	}

	private void Update()
	{
		//if (input.actions.FindAction("DAction").triggered)
		//{
		//	paddles[0].ButtonPressed();
		//	//Debug.Log("D");
		//}
		//if (input.actions.FindAction("FAction").triggered)
		//{
		//	paddles[1].ButtonPressed();
		//	//Debug.Log("F");
		//}
		//if (input.actions.FindAction("JAction").triggered)
		//{
		//	paddles[2].ButtonPressed();
		//	//Debug.Log("J");
		//}
		//if (input.actions.FindAction("KAction").triggered)
		//{
		//	paddles[3].ButtonPressed();
		//	//Debug.Log("K");
		//}
	}

}
