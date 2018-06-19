using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    
    public KeyController key;
    public bool isLocked = true;
    public bool isOpen = false;
    public Animator anim;
    public BoxCollider boxCol;
    public AudioSource sound;
    public AudioSource lockedSound;

    void OnTriggerEnter(Collider col)
    {
        //when player touches door and had collected the key required
        if (col.gameObject.tag == "Hand" && key.isCollected == true)
        {
            UnlockDoor();
            //when player press down the grip button
            if (!isOpen)
            {
                OpenDoor();
                boxCol.enabled = false;
            }
        }
        else if(col.gameObject.tag == "Hand" && !key.isCollected)
        {
            //play sound
            Debug.Log("Find a key");
            lockedSound.Play();
        }
    }

    void OpenDoor()
    {
        sound.Play();
        isOpen = true;
        anim.SetBool("OpenDoor", true);
        boxCol.enabled = false;
    }
    void CloseDoor()
    {
        boxCol.enabled = true;
        isOpen = false;
        anim.SetBool("OpenDoor", false);
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
