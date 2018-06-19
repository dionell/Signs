using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIsInsideElevator : MonoBehaviour {

    public ElevatorController elevator;
    public bool playerInside = false;
    public Animator anim;
    public GameObject player;
    public GameObject morgueEntrance;
    public GameObject morgueJohn;

    public float time;
    public float cooldownTimer = 3f;

    public bool FadedOut = false;
    public bool hasTeleportedToMorgueEntrance = false;

    void Update()
    {
        if (playerInside)
        {
            elevator.CloseElevatorDoors();
            if(hasTeleportedToMorgueEntrance == false)
            {
                time += Time.deltaTime;
                if (time >= cooldownTimer)
                {
                    player.transform.position = morgueEntrance.transform.position;
                    hasTeleportedToMorgueEntrance = true;
                }

            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "PlayerCollider")
        {
            playerInside = true;
            //play ending scene
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.name == "PlayerCollider")
        {
            playerInside = false;
            //play ending scene
        }
    }
}
