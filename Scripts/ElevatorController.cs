using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    public ElectroPanelController electroPanel;
    public bool isPoweredOn = false;
    public bool isOpen = false;
    public Animator anim;
    public Material material;
    public Renderer rend;

    public AudioSource elevatorOpenSound;
    public AudioSource elevatorNoPower;

    void Update()
    {
        if (electroPanel.isActivated)
        {
            rend.material = material;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hand" && electroPanel.isActivated == true)
        {
            CallElevator();
            elevatorOpenSound.Play();
        }
        else if (col.gameObject.tag == "Hand" && electroPanel.isActivated == false)
        {
            elevatorNoPower.Play();
        }
    }

    public void CallElevator()
    {
        anim.SetBool("OpenDoor", true);
    }

    public void CloseElevatorDoors()
    {
        anim.SetBool("OpenDoor", false);
    }
}
