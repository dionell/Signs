using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour {
    
    public ParticleSystem shockwave;

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
