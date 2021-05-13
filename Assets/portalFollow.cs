using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalFollow : MonoBehaviour
{
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (portal.transform.position.y < -500)
        {
            transform.position = portal.transform.position + new Vector3(0, 1000, 0);
            transform.eulerAngles = portal.transform.eulerAngles - new Vector3(0, 0, 90); ;
        }
        else
        {
            transform.position = portal.transform.position - new Vector3(0, 1000, 0);
            transform.eulerAngles = portal.transform.eulerAngles - new Vector3(0, 0, 90); ;
        }
    }
}
