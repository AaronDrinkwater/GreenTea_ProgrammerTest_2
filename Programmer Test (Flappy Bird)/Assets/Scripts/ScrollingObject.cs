using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, GameControl.instance.scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameControl.instance.isGameOver)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
