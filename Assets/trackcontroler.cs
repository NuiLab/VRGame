using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class trackcontroler : MonoBehaviour {
    private Valve.VR.EVRButtonId grip = Valve.VR.EVRButtonId.k_EButton_Grip;

    private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    
    private Valve.VR.EVRButtonId trackbtn = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private Valve.VR.EVRButtonId menu = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

    HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();
    private InteractableItem closestItem;
    private InteractableItem interactingItem;


    //private GameObject pickup;

    private SteamVR_TrackedObject trackobj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackobj.index); } }
	// Use this for initialization
	void Start () {
        trackobj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if(controller == null)
        {
            Debug.Log("Controller not initialized!");
            return;
        }
        if (controller.GetPressDown(menu) == true)
        {
            OnApplicationMenuEnter();
        }
        if(controller.GetPressDown(trigger) == true )
        {
            float minDist = float.MaxValue;
            float distance;
            foreach(InteractableItem item in objectsHoveringOver)
            {
                distance = (item.transform.position - transform.position).sqrMagnitude;
                if (distance < minDist)
                {
                    minDist = distance;
                    closestItem = item;
                }
            }
            interactingItem = closestItem;
            closestItem = null;
            if (interactingItem)
            {
                if(interactingItem.IsInteracting())
                {
                    interactingItem.EndInteraction(this);
                }
                interactingItem.BeginInteraction(this);
            }

        }
        if(controller.GetPressUp(trigger) == true && interactingItem != null )
        {
            interactingItem.EndInteraction(this);
        }
      
	}
    private void OnTriggerEnter(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if(collidedItem)
        {
            objectsHoveringOver.Add(collidedItem);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            objectsHoveringOver.Remove(collidedItem);
        }
    }
    private void OnApplicationMenuEnter()
    {
        if (Application.loadedLevel == 1)
            Application.LoadLevel(0);
        else
            Application.LoadLevel(1);
    }
}
