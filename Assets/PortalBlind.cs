using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBlind : MonoBehaviour
{
    public GameObject frameLink;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = frameLink.transform.localPosition;
        transform.localEulerAngles = frameLink.transform.localEulerAngles;
    }
}