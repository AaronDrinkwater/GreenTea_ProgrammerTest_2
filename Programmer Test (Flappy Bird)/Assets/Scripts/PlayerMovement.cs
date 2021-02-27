using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class PlayerMovement : MonoBehaviour
{
    
    public AudioClip deathClip;
    public AudioClip jumpClip;
    public AudioClip floorClip;
    new AudioSource audio;
    public float volume;

    private Animator anim;

    private Rigidbody rb;
    Vector3 savedVelocity;
    Vector3 savedAngularVelocity;

    public float upwardsForce;
    public float moveFoward;
    private bool isDead = false;
 

    public bool checkOnce = false;

    //Touch touch;
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
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                //Debug.Log("I have touched: " + Camera.main.ScreenToWorldPoint(touch.position));

                //anim.SetTrigger("");

                rb.velocity = Vector3.zero;

                rb.AddForce(new Vector3(0, upwardsForce, moveFoward));

                audio.PlayOneShot(jumpClip, volume);

                if(transform.position.y > 6.8f)
                {
                    rb.AddForce(new Vector3(0, -upwardsForce, -moveFoward));
                }
            }

        }
    }

    public void OnPauseGame()
    {
        rb.isKinematic = true;
        savedVelocity = rb.velocity;
        savedVelocity = Vector3.zero;
        //isDead = true;
        //rb.sleepThreshold = 0;
        //Destroy(gameObject);
        //Destroy(GetComponent<Rigidbody>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;

        isDead = true;

        GameControl.instance.Died();

        GameControl.instance.EndScore();

        GameControl.instance.ScoreUp();

        if(collision.gameObject.tag == "Pipe")
        {
            audio.PlayOneShot(deathClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor" && !checkOnce)
        {
            audio.PlayOneShot(floorClip, 0.15f);

            checkOnce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkOnce = false;
    }
}
