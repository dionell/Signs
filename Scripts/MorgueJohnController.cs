using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MorgueJohnController : MonoBehaviour
{

    public Animator anim;
    public bool hasReachedPlayer = false;
    public Transform target;
    public float damping = 5f;
    public AudioSource walkingSound;
    public AudioSource deadSound;
    public TryAgain reset;
    public SpawnJohn johnSpawner;
    public MorgueController morgue;

    void Update()
    {
        if (hasReachedPlayer)
        {
            //still needs work
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
        }
        else if (!hasReachedPlayer)
        {
            walkingSound.Play();
        }

        if (morgue.isDead == true)
        {
            deadSound.Play();
            walkingSound.Stop();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Morgue")
        {
            anim.SetBool("isWalking", true);
        }

        if (col.gameObject.tag == "Flashlight")
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            johnSpawner.agent.speed = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Target")
        {
            reset.ResetGame();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Flashlight" && morgue.isDead == false)
        {
            anim.SetBool("isWalking", true);
            johnSpawner.agent.speed = 3;

        }
    }
}
