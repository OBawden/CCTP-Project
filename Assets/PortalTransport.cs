using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject player;
    public GameObject rig;

    public Vector3 teleportVector;


    public GameObject frame;

    public bool portalSide;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for(int n = 0; n < objects.Length; n++)
        {
            if (GetComponent<Collider>().bounds.Contains(objects[n].transform.position))
            {
                objects[n].transform.position += teleportVector;
            }
        }

        if (GetComponent<Collider>().bounds.Contains(player.transform.position))
        {
            rig.transform.position += teleportVector;
        }*/
    }

    void OnTriggerStay(Collider other)
    {
        Plane portalPlane = new Plane(frame.transform.right, frame.transform.position);

        for (int n = 0; n < objects.Length; n++)
        {
            if (other == objects[n].GetComponent<Collider>() && portalPlane.GetSide(objects[n].transform.position) == portalSide)
            {
                objects[n].transform.position += teleportVector;
            }
        }

        if (other == player.GetComponent<Collider>() && portalPlane.GetSide(player.transform.position) == portalSide)
        {
            rig.transform.position += teleportVector;
        }
    }
}
