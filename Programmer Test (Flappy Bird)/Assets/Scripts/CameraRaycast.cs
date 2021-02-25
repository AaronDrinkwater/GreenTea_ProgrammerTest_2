using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    Camera cam;
    public Transform player;
    public Vector3 offset;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, /*ray*/ out hit))
        {
            if(hit.transform.tag == "Pipe")
            {
                Vector3 position = transform.position;
                position.x = (player.position + offset).x;
                transform.position = position;
                Destroy(gameObject);
            }

            Debug.Log(hit.collider.tag);

            //Vector3 raycastDir = transform.position - player.transform.position;
            //Debug.DrawRay(player.position, raycastDir, Color.black);
            //print("I'm looking at " + hit.transform.name);
        }

        else
            print("I'm looking at nothing!");

    }
}
