using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMorgueJohn : MonoBehaviour
{

    public GameObject john;
    public GameObject spawnLocation;
    public GameObject player;
    public NavMeshAgent agent;
    public bool johnIsSpawned = false;
    public float time;
    public float johnTimer;
    public videoPlayerController video;
    public PlayerIsInsideElevator playerElevator;

    // Use this for initialization
    void Start()
    {
        johnTimer = 60f;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (johnIsSpawned) //if john is walking around the game
        {
            john.SetActive(true); //activates john
            agent.enabled = true; //enables agent component
            agent.destination = player.transform.position; //walk towards player
            john.transform.position = transform.position; //where john will transform

            time += Time.deltaTime; //sets timer for John
            if (time > johnTimer) //if time is up for john
            {
                deactivateJohn();
            }


        }
        else if (!johnIsSpawned) //if john is deactivated
        {
            agent.enabled = false;
            john.SetActive(false);
        }
    }

    void deactivateJohn()
    {
        time = 0;
        johnTimer = 60f;
        johnIsSpawned = false;
    }
}
