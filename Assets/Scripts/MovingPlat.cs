using UnityEngine;
using System.Collections;

public class MovingPlat : MonoBehaviour
{


    public GameObject platform;

    public float movespeed;

    public Transform currentPoint;

    public Transform[] point;

    public int pointSelection;

    // Use this for initialization
    void Start()
    {
        currentPoint = point[pointSelection];


    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * movespeed);

        if (platform.transform.position == currentPoint.position)
        {
            //what the platform does when cycle is over
            pointSelection++;

            if (pointSelection == point.Length)
            {
                pointSelection = 0;
            }
            currentPoint = point[pointSelection];

        }
    }


}
