using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusHandInteraction : MonoBehaviour {
    public float throwForce = 1.5f;
    private OVRInput.Controller thisController;
    public bool leftHand;
    public GameObject player;
    public GameObject parentObject;
    public float speed = 1f;

    //Swipe
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;
    public float menuStickX;
    public bool menuIsSwipable;


    public bool hasInteracted;

    public bool isHoldingFlashlight;

    public FlashlightController flashlight;

	// Use this for initialization
	void Start () {
        hasInteracted = false;


        isHoldingFlashlight = false;
        if (leftHand)
        {
            thisController = OVRInput.Controller.LTouch;
        }
        else
        {
            thisController = OVRInput.Controller.RTouch;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //when player holds down trigger
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, thisController))
        {
            if (isHoldingFlashlight)
            {
                flashlight.ToggleFlashlight();
            }
        }





        if (leftHand) //if player uses the left joystick/touchpad
        {
            menuStickX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick,
                 thisController).x;

            if (menuStickX < 0.45f && menuStickX > -0.45f)
            {
                menuIsSwipable = true;
            }
            if (menuIsSwipable)
            {
                if (menuStickX >= 0.45f)
                {
                    //fire function that looks at menuList,
                    //disables current item, and enables next item
                    SwipedLeft();
                    menuIsSwipable = false;
                }
                else if (menuStickX <= -0.45f)
                {
                    SwipedRight();
                    menuIsSwipable = false;
                }
            }
        }
    }
    
    void SwipedLeft()
    {
        //rotate player to the left
        parentObject.transform.Rotate((0), (90f), (0));
    }

    void SwipedRight()
    {
        //rotate player to the right
        parentObject.transform.Rotate((0), (-90f), (0));
    }

    void OnTriggerStay(Collider col)
    {
        //grip trigger
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, thisController))
        {
            transform.SetParent(transform);
            if (col.gameObject.tag == "Flashlight")
            {
                if(isHoldingFlashlight == false)
                {
                    isHoldingFlashlight = true;
                }
            }
            //other gameobjects
        }
        //other buttons
    }

    void OnTriggerExit(Collider col)
    {
        isHoldingFlashlight = false;
    }

    /*
        void GrabObject(Collider col)
        {
            Rigidbody rigidbody = col.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
        }

        void ThrowObject(Collider col)
        {
            Rigidbody rigidbody = col.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(thisController) * throwForce; //velocity based on controller's movement
            rigidbody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(thisController) * throwForce;

        }
        */
}
