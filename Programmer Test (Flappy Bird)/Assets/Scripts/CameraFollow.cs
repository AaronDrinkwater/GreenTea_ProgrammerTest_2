using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    [SerializeField] private Transform player;
    public Vector3 offset;
    public Vector3 raycastOffset;
    private Vector3 vel;
    public float smoothTime;
    public float raycastSmoothTime;
    private Vector3 lastPosition;
    private float transitionTime = 1.0f;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref vel, smoothTime);

        Vector3 position = transform.position;
        position.y = (player.position + offset).y;
        transform.position = position;

    }

    void LateUpdate()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, /*ray*/ out hit))
        {
            if (hit.transform.tag == "Pipe")
            {
                //cam.transform.position = Vector3.Lerp(transform.position, player.position + offset * cam.targetDisplay, transitionTime);
                //transform.position = Vector3.SmoothDamp(transform.position, player.position - raycastOffset, ref vel, raycastSmoothTime);
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref vel, raycastSmoothTime);
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
