using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroPanelController : MonoBehaviour {

    //public ElevatorController elevator;
    public bool isActivated = false;
    public AudioSource sound;
    public GameObject lights;
    public SpawnJohn spawnJohn;
    public ParticleSystem shockwave;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hand" && !isActivated)
        {
            isActivated = true;
            if(isActivated == true)
            {
                sound.Play();
                lights.SetActive(true);
                spawnJohn.johnIsSpawned = true;

            }
        }
        
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
