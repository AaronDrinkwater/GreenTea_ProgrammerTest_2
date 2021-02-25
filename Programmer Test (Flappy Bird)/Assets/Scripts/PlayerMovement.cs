using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public AudioClip deathClip;
    public AudioClip jumpClip;
    public AudioClip floorClip;
    AudioSource audio;
    public float volume;

    private Animator anim;

    private Rigidbody rb;

    public float upwardsForce;
    public float moveFoward;
    private bool isDead = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!isDead)
        {
            //using mouse input for test circiumstances to begin with
            if (Input.GetMouseButtonDown(0))
            {
                //anim.SetTrigger("");

                rb.velocity = Vector3.zero;

                rb.AddForce(new Vector3(0, upwardsForce, moveFoward));

                audio.PlayOneShot(jumpClip, volume);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;

        isDead = true;

        GameControl.instance.Died();

        if(collision.gameObject.tag == "Pipe")
        {
            audio.PlayOneShot(deathClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            audio.PlayOneShot(floorClip, 0.15f);
        }
    }
}
