using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    private CharacterController cc;
    public float speed;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(xAxisValue, 0.0f, zAxisValue);
        cc.Move(move * speed);
        //if (Camera.current != null)
        //{
        //    Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
        //}
    }
}
