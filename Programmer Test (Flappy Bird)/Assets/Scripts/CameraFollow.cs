using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Vector3 offset;
    private Vector3 vel;
    public float smoothTime;
    //public float moveForce;

    //private Rigidbody rb;
    //public float upwardsForce;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref vel, smoothTime);

        Vector3 position = transform.position;
        position.y = (player.position + offset).y;
        transform.position = position;

        //transform.rotation = player.transform.rotation;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    rb.AddForce(new Vector3(0, upwardsForce));
        //}
    }
}
