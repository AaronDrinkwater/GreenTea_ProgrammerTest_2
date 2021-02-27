using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int time;
    public GameObject self;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            //StartCoroutine(Disabled());
            GameControl.instance.ScoreUp();
            //StartCoroutine(Disabled());
        }

        //Disabled();
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.GetComponent<PlayerMovement>() != null)
    //    {
    //        //StartCoroutine(Disabled());
    //    }
    //}

    //IEnumerator Disabled()
    //{
    //    self.SetActive(false);
    //    yield return new WaitForSeconds(time);
    //    self.SetActive(true);
    //}
}
