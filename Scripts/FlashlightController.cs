using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {

    public bool lightIsOn;
    public GameObject flashlightLight;
    public GameObject flashlightHolster;
    public Rigidbody rb;
    public GameObject keyItemLight;
    public AudioSource sound;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            transform.position = flashlightHolster.transform.position;
            transform.rotation = flashlightHolster.transform.rotation;
            transform.SetParent(flashlightHolster.transform);
            rb.isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hand")
        {
            keyItemLight.SetActive(false);
        }
    }

    public void ToggleFlashlight()
    {
        sound.Play();
        if (lightIsOn)
        {
            flashlightLight.SetActive(false);
            lightIsOn = false;
        }
        else
        {
            flashlightLight.SetActive(true);
            lightIsOn = true;
        }
    }
}
