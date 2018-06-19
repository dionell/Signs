using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnIsRevealed : MonoBehaviour {

    public ElectroPanelController electroPanel;
    public AudioSource sound;
    public bool playerSeesJohn = false;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PlayerCollider" && electroPanel.isActivated == true)
        {
            sound.Play();
        }
    }

}
