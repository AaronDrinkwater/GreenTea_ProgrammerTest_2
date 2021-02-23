using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    public float upwardsForce;
    private bool isDead = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!isDead)
        {
            //using  ouse input for test circiumstances to begin with
            if (Input.GetMouseButtonDown(0))
            {
                //anim.SetTrigger("");

                rb.velocity = Vector3.zero;

                rb.AddForce(new Vector3(0, upwardsForce, 0));
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;

        isDead = true;



    }
}
