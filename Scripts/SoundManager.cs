using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public SpawnJohn spawnJohn;
    public GameObject beforeJohn;
    public GameObject afterJohn;
    

    // Update is called once per frame
    void Update () {
        if (spawnJohn.johnIsSpawned == true)
        {
            beforeJohn.SetActive(false);
            afterJohn.SetActive(true);
        }
        else
        {
            beforeJohn.SetActive(true);
            afterJohn.SetActive(false);
        }
	}
}
