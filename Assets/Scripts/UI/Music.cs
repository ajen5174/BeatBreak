using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource calmMusic = null;
    [SerializeField] AudioSource anxiousMusic = null;
    [SerializeField] AudioSource crazyMusic = null;
    [SerializeField] AudioSource thunder = null;
    [SerializeField] [Range(0, 1)] float volume = 0.3f;

    
    void SetVolume()
    {
        GameObject background = GameObject.Find("Background");
        ParticleSystem ps = background.GetComponent<ParticleSystem>();
        if (BallManager.ballsActive < 3 && BallManager.ballSpeed <= 5)
        {
            anxiousMusic.volume = 0.0f;
            crazyMusic.volume = 0.0f;
            calmMusic.volume = volume;
            thunder.volume = 0.0f;
            background.GetComponent<SpriteRenderer>().color = Color.white;
            if(ps != null) ps.Stop();

        }
        else if (BallManager.ballsActive < 3 && BallManager.ballSpeed > 5)
        {
            anxiousMusic.volume = volume;
            crazyMusic.volume = 0.0f;
            calmMusic.volume = 0.0f;
            thunder.volume = 0.0f;
            background.GetComponent<SpriteRenderer>().color = Color.white;
            if(ps != null) ps.Stop();
        }
        else if (BallManager.ballsActive > 3 && BallManager.ballSpeed > 3)
        {
            anxiousMusic.volume = 0.0f;
            crazyMusic.volume = volume;
            calmMusic.volume = 0.0f;
            thunder.volume = volume * 2;
            background.GetComponent<SpriteRenderer>().color = Color.gray;
            if(ps != null) ps.Play();

        }
    }

    private void Start()
    {
        if(GameObject.Find("MusicPlaying") != null)
        {
            Destroy(gameObject);
            return;
        }
        if(GameObject.Find("MusicController") != null)
        {
            name = "MusicPlaying";
        }
        DontDestroyOnLoad(this.gameObject);

        SetVolume();
        
    }

    private void Update()
    {
        SetVolume();
        

    }
}
