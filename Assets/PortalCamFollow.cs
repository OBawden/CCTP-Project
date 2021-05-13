using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamFollow : MonoBehaviour
{
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.transform.position.y < -500)
        {
            transform.position = Camera.transform.position + new Vector3(0, 1000, 0);
            transform.eulerAngles = Camera.transform.eulerAngles;
        }
        else
        {
            transform.position = Camera.transform.position - new Vector3(0, 1000, 0);
            transform.eulerAngles = Camera.transform.eulerAngles;
        }
    }
}
