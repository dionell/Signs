using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
    
    public DoorController door; //which door to open
    public bool isCollected = false;
    public GameObject key;
    public ParticleSystem shockwave;
    public AudioSource sound;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hand")
        {
            isCollected = true;
            sound.Play();
        }

        if(col.gameObject.tag == "Flashlight")
        {
            shockwave.Play();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Flashlight")
        {
            shockwave.Stop();
        }

        if (col.gameObject.tag == "Hand")
        {
            key.SetActive(false);
        }

    }
}
