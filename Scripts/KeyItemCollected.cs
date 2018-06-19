using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemCollected : MonoBehaviour {

    public bool isCollected = false;
    public DoorController door;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hand")
        {
            isCollected = true;
            door.UnlockDoor();
        }
    }
}
