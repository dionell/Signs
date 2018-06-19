using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MorgueController : MonoBehaviour {

    public PlayerIsInsideElevator playerIsInsideElevator;
    public videoPlayerController videoPlayerController;
    public SpawnJohn spawnJohn;
    public GameObject morgueJohn;
    public videoPlayerController videoPlayer;
    public JohnController john;
    public MorgueJohnController morgueJohnController;
    public Animator johnAnim;
    public Animator morgueJohnAnim;
    public SpawnMorgueJohn spawnMorgueJohn;
    public bool isDead = false;
    
    public Animator anim;

    public string[] keywords;
    private KeywordRecognizer recognizer;

    void Start()
    {
        keywords = new string[1];
        keywords[0] = "Noah";
        recognizer = new KeywordRecognizer(keywords);
        recognizer.OnPhraseRecognized += OnPhraseRecognized;
        recognizer.Start();
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if(args.text == keywords[0])
        {
            //Debug.Log("voice activated");
            //destroys Noah when you call out his name
            john.anim.SetBool("isDead", true);
            morgueJohnController.anim.SetBool("isDead", true);
            spawnJohn.agent.speed = 0;
            spawnMorgueJohn.agent.speed = 0;
            videoPlayer.videoGotPlayed = false;
            john.anim.SetBool("isWalking", false);
            morgueJohnController.anim.SetBool("isWalking", false);
            isDead = true;
        }
    }

    // Update is called once per frame
    void Update () {
		if(playerIsInsideElevator.playerInside == true && videoPlayerController.videoGotPlayed == true){
            morgueJohn.SetActive(true);
            spawnMorgueJohn.johnIsSpawned = true;
            isDead = false;
        }

        if(playerIsInsideElevator.hasTeleportedToMorgueEntrance == true)
        {
            anim.SetBool("OpenDoor", true);
        }
	}


}
