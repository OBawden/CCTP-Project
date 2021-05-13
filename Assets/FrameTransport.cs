using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTransport : MonoBehaviour
{

    public GameObject positionPoint;
    public GameObject velocityPoint;
    //public GameObject angularVelocityPoint;

    public GameObject partnerPositionPoint;
    public GameObject partnerVelocityPoint;

    public GameObject reverse;
    //public GameObject partnerAngularVelocityPoint;

    public GameObject[] objects;

    public static float refresh;


    public GameObject thisFrame;
    public GameObject partnerFrame;

    public GameObject frame;

    // Start is called before the first frame update
    void Start()
    {
        refresh = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        refresh -= Time.deltaTime;
        if (refresh < 0)
        {

            for (int n = 0; n < objects.Length; n++)
            {
                if (GetComponent<Collider>().bounds.Contains(objects[n].transform.position))
                {
                    positionPoint.transform.position = objects[n].transform.position;
                    positionPoint.transform.eulerAngles = objects[n].transform.eulerAngles;

                    velocityPoint.transform.position = objects[n].transform.GetComponent<Rigidbody>().velocity + transform.position - thisFrame.transform.GetComponent<Rigidbody>().velocity;
                    velocityPoint.transform.eulerAngles = objects[n].transform.GetComponent<Rigidbody>().angularVelocity + transform.eulerAngles;



                    partnerPositionPoint.transform.localPosition = positionPoint.transform.localPosition;
                    partnerPositionPoint.transform.localEulerAngles = positionPoint.transform.localEulerAngles;

                    partnerVelocityPoint.transform.localPosition = velocityPoint.transform.localPosition;
                    partnerVelocityPoint.transform.localEulerAngles = velocityPoint.transform.localEulerAngles;


                    objects[n].transform.position = partnerPositionPoint.transform.position;
                    objects[n].transform.eulerAngles = partnerPositionPoint.transform.eulerAngles;

                    objects[n].transform.GetComponent<Rigidbody>().velocity = partnerVelocityPoint.transform.position - reverse.transform.position + partnerFrame.transform.GetComponent<Rigidbody>().velocity;
                    objects[n].transform.GetComponent<Rigidbody>().angularVelocity = partnerVelocityPoint.transform.eulerAngles - reverse.transform.eulerAngles;

                    refresh = 0.5f;

                }
            }
        }
        */

    }

    void OnTriggerStay(Collider other)
    {
        Plane portalPlane = new Plane(frame.transform.right, frame.transform.position);

        for (int n = 0; n < objects.Length; n++)
        {
            if (other == objects[n].GetComponent<Collider>() && !portalPlane.GetSide(objects[n].transform.position))
            {
                positionPoint.transform.position = objects[n].transform.position;
                positionPoint.transform.eulerAngles = objects[n].transform.eulerAngles;


                velocityPoint.transform.position = objects[n].transform.GetComponent<Rigidbody>().velocity + transform.position - thisFrame.transform.GetComponent<Rigidbody>().velocity;
                velocityPoint.transform.eulerAngles = objects[n].transform.GetComponent<Rigidbody>().angularVelocity + transform.eulerAngles;


                partnerPositionPoint.transform.localPosition = positionPoint.transform.localPosition;
                partnerPositionPoint.transform.localEulerAngles = positionPoint.transform.localEulerAngles;

                partnerVelocityPoint.transform.localPosition = velocityPoint.transform.localPosition;
                partnerVelocityPoint.transform.localEulerAngles = velocityPoint.transform.localEulerAngles;

                objects[n].transform.position = partnerPositionPoint.transform.position;
                objects[n].transform.eulerAngles = partnerPositionPoint.transform.eulerAngles;

                objects[n].transform.GetComponent<Rigidbody>().velocity = partnerVelocityPoint.transform.position - reverse.transform.position + partnerFrame.transform.GetComponent<Rigidbody>().velocity;
                objects[n].transform.GetComponent<Rigidbody>().angularVelocity = partnerVelocityPoint.transform.eulerAngles - reverse.transform.eulerAngles;

            }
        }
    }
}
