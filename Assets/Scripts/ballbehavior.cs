using UnityEngine;
using System.Collections;



public class ballbehavior : MonoBehaviour {

    public float fiveframe;
    public int time;
    public bool stuff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {/*
        while(time > 0)
        {
            time = 50;
            float Translate = Time.deltaTime * fiveframe;
            transform.Translate(Translate, 0, 0);
            time--;

        }
        while(time <=0)
        {
            time = -50;
            float Translate = Time.deltaTime * fiveframe;
            transform.Translate(-Translate, 0, 0);
            time++;
        }
    */}

}
