using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemLightController : MonoBehaviour {

    public KeyItemCollected keyItem;
    public GameObject lightToBeDestroyed;

    void Update()
    {
        if(keyItem.isCollected)
        {
            lightToBeDestroyed.SetActive(false);
        }
    }
}
