using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ButtonTest : MonoBehaviour
{

    UnityEngine.XR.InputDevice device;
    bool triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        triggerValue = false;
    }

    // Update is called once per frame
    void Update()
    {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand,
                                                         leftHandDevices);
        if (leftHandDevices.Count == 1)
        {
            device = leftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'",
                                    device.name, device.role.ToString()));
        }
        else if (leftHandDevices.Count > 1)
        {
            //Debug.Log("Found more than one left hand!");
        }

        Vector3 velocity;

        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity,
                                      out velocity);
        print(velocity);

        bool pressed;

        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton,
                                      out pressed);
        print(pressed);
    }
}
