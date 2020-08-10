using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [HideInInspector] public static int blocksDestroyed = 0;

    LevelLoader levelLoader = null;

    void Start()
    {
        levelLoader = GetComponentInParent<LevelLoader>();
        levelLoader.blocksLeft += 1;
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
            levelLoader.blocksLeft -= 1;
		}
	}
}
