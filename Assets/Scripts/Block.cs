using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [HideInInspector] public static int blocksDestroyed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Ball"))
		{
            Destroy(gameObject, 0.01f);
            blocksDestroyed++;
		}
	}
}
