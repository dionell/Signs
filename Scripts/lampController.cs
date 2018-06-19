using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampController : MonoBehaviour {

    public Material material;
    public Renderer rend;
    public ElectroPanelController electroPanel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (electroPanel.isActivated)
        {
            rend.sharedMaterials[1].color = material.color;
        }
	}
}
