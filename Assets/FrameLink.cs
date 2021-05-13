using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLink : MonoBehaviour
{
    public GameObject linkedFrame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = linkedFrame.transform.position;
        transform.eulerAngles = linkedFrame.transform.eulerAngles;
    }
}
