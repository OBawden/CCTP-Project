using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamClipPlane : MonoBehaviour
{
    public GameObject[] corners;

    GameObject closestCorner;

    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        closestCorner = corners[0];

        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int n = 0; n < 4; n++)
        {
            if(Vector3.Distance(transform.position, corners[n].transform.position) < Vector3.Distance(transform.position, closestCorner.transform.position))
            {
                closestCorner = corners[n];
                //cam.nearClipPlane = Vector3.Distance(transform.position, corners[n].transform.position);
            }
        }
    }
}
