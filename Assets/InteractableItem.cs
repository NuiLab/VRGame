using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour {
    public Rigidbody rigidbody;
    private bool currentlyinteracting;
    private trackcontroler attachedWand;
    private Transform interactionPoint;
    private Vector3 posDelta;
    private float velocityfactor = 20000f;
    private float rotationFactor = 400f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        interactionPoint = new GameObject().transform;

        velocityfactor /= rigidbody.mass;
        rotationFactor /= rigidbody.mass;
	}
	
	// Update is called once per frame
	void Update () {
        if(attachedWand && currentlyinteracting)
        {
            posDelta = attachedWand.transform.position - interactionPoint.position;
            this.rigidbody.velocity = posDelta * velocityfactor * Time.fixedDeltaTime;
            rotationDelta = attachedWand.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);
            if(angle > 180)
            {
                angle -= 360;
            }
            this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor; 
        }
	
	}

    public void BeginInteraction(trackcontroler wand)
    {
        attachedWand = wand;
        interactionPoint.position = wand.transform.position;
        interactionPoint.rotation = wand.transform.rotation;
        interactionPoint.SetParent(transform, true);

        currentlyinteracting = true;
    }
    public void EndInteraction(trackcontroler wand)
    {
        if (wand == attachedWand)
        {
            attachedWand = null;
            currentlyinteracting = false;
        }
    }
    public bool IsInteracting()
    {
        return currentlyinteracting;
    }

}
