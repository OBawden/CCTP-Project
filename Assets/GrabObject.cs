using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class GrabObject : MonoBehaviour
{
    public GameObject nearestObject;

    public GameObject[] objects;

    public bool leftHand;

    UnityEngine.XR.InputDevice device;

    public int handLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (leftHand)
        {
            var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand,
                                                             leftHandDevices);
            if (leftHandDevices.Count == 1)
            {
                device = leftHandDevices[0];
                //Debug.Log(string.Format("Device name '{0}' with role '{1}'",
                                        //device.name, device.role.ToString()));
            }
            else if (leftHandDevices.Count > 1)
            {
                //Debug.Log("Found more than one left hand!");
            }
        }
        else
        {
            var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand,
                                                             rightHandDevices);
            if (rightHandDevices.Count == 1)
            {
                device = rightHandDevices[0];
                //Debug.Log(string.Format("Device name '{0}' with role '{1}'",
                                        //device.name, device.role.ToString()));
            }
            else if (rightHandDevices.Count > 1)
            {
                //Debug.Log("Found more than one right hand!");
            }
        }



        //print(velocity);

        for (int n = 0; n < objects.Length; n++)
        {
            if (Vector3.Distance(transform.position, objects[n].transform.position) < Vector3.Distance(transform.position, nearestObject.transform.position))
            {
                nearestObject = objects[n];

            }
        }


        for (int n = 0; n < objects.Length; n++)
        {
            if (nearestObject == objects[n])
            {
                objects[n].layer = handLayer;

            }
            else if(objects[n].layer == handLayer)
            {
                objects[n].layer = 0;
            }
        }



        bool pressed;

        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton,
                                      out pressed);
        if (pressed)
        {

            Vector3 velocity;

            device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity,
                                          out velocity);

            Vector3 angularVelocity;

            device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularVelocity,
                                          out angularVelocity);

            nearestObject.transform.position = transform.position;
            nearestObject.transform.eulerAngles = transform.eulerAngles;
            nearestObject.transform.GetComponent<Rigidbody>().velocity = velocity;
            nearestObject.transform.GetComponent<Rigidbody>().angularVelocity = angularVelocity;
        }
    }
}
