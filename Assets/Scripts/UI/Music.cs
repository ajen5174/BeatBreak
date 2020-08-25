using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic = null;

    private void Start()
    {
        if(GameObject.Find("MusicPlaying") != null)
        {
            Destroy(gameObject);
            return;
        }
        if(GameObject.Find("Music") != null)
        {
            name = "MusicPlaying";
        }
        DontDestroyOnLoad(this.gameObject);
        if (backgroundMusic.isPlaying == false)
        {
            backgroundMusic.Play();
        }
    }
}
