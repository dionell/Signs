using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlayerController : MonoBehaviour {

    public ElectroPanelController electroPanel;
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;
    public int videoClipIndex;
    public bool videoGotPlayed = false;
    public GameObject morgueJohn;
	
	// Update is called once per frame
	void Update () {
		if(electroPanel.isActivated == true)
        {
            videoPlayer.enabled = true;

        }
        else
        {
            videoPlayer.enabled = false;
        }

        if(videoGotPlayed == true)
        {

            morgueJohn.SetActive(true);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Tape")
        {
            //change clip
            videoGotPlayed = true;
            videoPlayer.clip = videoClip;
        }
    }
}
