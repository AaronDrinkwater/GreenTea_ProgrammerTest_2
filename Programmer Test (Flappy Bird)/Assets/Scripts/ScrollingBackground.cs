using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private BoxCollider groundCollider;
    private float groundLength;
    private float offset = 20f;
    void Start()
    {
        groundCollider = GetComponent<BoxCollider>();
        groundLength = groundCollider.size.z;
    }

    void Update()
    {
        if(transform.position.z - offset < -groundLength)
        {
            BackgroundReposition();
        }
    }

    private void BackgroundReposition()
    {
        Vector3 groundOffset = new Vector3(0, 0, groundLength * 2f);
        transform.position = (Vector3)transform.position + groundOffset;
    }
}
