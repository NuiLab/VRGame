namespace VRTK
{

    using UnityEngine;
    using System.Collections;

    public class KeyScript : VRTK_InteractableObject
    {

        public GameObject skinnycube;
        public GameObject cube;
        public Rigidbody crb;
        public Rigidbody srb;


        // Use this for initialization
        void Start()
        {
            base.Start();
            skinnycube.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        }
        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            if(skinnycube.active)
            {
                skinnycube.SetActive(false);
                cube.SetActive(true);
                cube.transform.position = skinnycube.transform.position;
            }
            else
            {
                skinnycube.SetActive(true);
                cube.SetActive(false);
                skinnycube.transform.position = cube.transform.position;
            }
        }
        public override void Grabbed(GameObject currentGrabbingObject)
        {
            base.Grabbed(currentGrabbingObject);
            crb.useGravity = false;
            crb.detectCollisions = true;
            srb.useGravity = false;
            srb.detectCollisions = true;
        }
        public override void Ungrabbed(GameObject previousGrabbingObject)
        {
            base.Ungrabbed(previousGrabbingObject);
            crb.useGravity = true;
            srb.useGravity = true; 
        }
    }
}