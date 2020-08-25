using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic = null;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (backgroundMusic.isPlaying == false)
        {
            backgroundMusic.Play();
        }
    }
}
