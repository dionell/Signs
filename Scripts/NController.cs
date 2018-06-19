using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NController : MonoBehaviour {

    public GameObject resetPosition;
    public ParticleSystem shockwave;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            transform.position = resetPosition.transform.position;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Flashlight")
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

    }
}
