using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameCamFollow : MonoBehaviour
{

    public GameObject attachedFrame;

    public GameObject partnerFrame;

    public GameObject playerCam;

    public GameObject track;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = track.transform.localPosition;
        //transform.localPosition = playerCam.transform.InverseTransformPoint(partnerFrame.transform.position);
        transform.localEulerAngles = track.transform.localEulerAngles;

        //cam.nearClipPlane = Vector3.Distance(attachedFrame.transform.position, transform.position);
    }
}
