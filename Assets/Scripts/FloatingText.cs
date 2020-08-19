using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float displayTime = 1.0f;
    [SerializeField] float moveSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, displayTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f);
    }
}
