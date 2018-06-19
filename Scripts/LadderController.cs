using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour {

    public bool ladderIsGrounded = false;
    public GameObject stepsCollider;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            ladderIsGrounded = true;
            stepsCollider.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            ladderIsGrounded = false;
            stepsCollider.SetActive(false);
        }
    }
}
