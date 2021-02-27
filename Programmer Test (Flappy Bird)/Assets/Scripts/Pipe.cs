using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public AudioClip audioClip;
    new AudioSource audio;
    public bool alreadyPlayed = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            GameControl.instance.ScoreUp();

            audio.PlayOneShot(audioClip);

            //if (!alreadyPlayed)
            //{
            //    audio.PlayOneShot(audioClip);
            //    alreadyPlayed = true;
            //}
        }
    }
}
