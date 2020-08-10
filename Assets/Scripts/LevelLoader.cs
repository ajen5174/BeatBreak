using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] UnityEvent destroyBlock = null;

    [HideInInspector] public int blocksLeft = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(blocksLeft == 0)
        {
            Debug.Log("Level Complete");
        }
    }
}
