using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject particles = null;

    [HideInInspector] public static int blocksDestroyed = 0;

    LevelLoader levelLoader = null;

    void Start()
    {
        levelLoader = GetComponentInParent<LevelLoader>();
        if(levelLoader != null)
		{
            levelLoader.blocksLeft += 1;
		}
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Ball"))
		{
            GameObject go = Instantiate(particles, transform.position, transform.rotation);
            ParticleSystem ps = go.GetComponent<ParticleSystem>();
            var settings = ps.main;
            Color c = GetComponent<SpriteRenderer>().color;
            Debug.Log(c);
            settings.startColor = c;
            Destroy(go, 1.0f);
            Destroy(gameObject, 0.01f);
            blocksDestroyed++;
            levelLoader.blocksLeft -= 1;
		}
	}
}
