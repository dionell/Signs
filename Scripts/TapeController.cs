using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeController : MonoBehaviour {

    public GameObject resetPosition;
    public ParticleSystem shockwave;
    public videoPlayerController videoPlayer;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground" || videoPlayer.videoGotPlayed == true)
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
