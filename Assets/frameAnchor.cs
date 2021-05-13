using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameAnchor : MonoBehaviour
{
    public GameObject anchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = anchor.transform.position;
        transform.eulerAngles = anchor.transform.eulerAngles + new Vector3(0,0,0);
    }
}
