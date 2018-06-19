using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour {

    public string sceneName;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hand")
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(sceneName);

    }
}
