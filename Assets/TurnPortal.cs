using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPortal : MonoBehaviour
{
    public GameObject player;

    public Transform portal;

    float turnSpeed;

    float turnStrength = 100;

    float turnDecay = 3;

    float frameGap = 0.35f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        turnSpeed = Mathf.Lerp(turnSpeed, 0 , Time.deltaTime * turnDecay);
        portal.transform.eulerAngles += new Vector3(0, turnSpeed * Time.deltaTime, 0);


    }

    void OnTriggerStay(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            if (Vector3.Distance(new Vector3 (transform.position.x, player.transform.position.y, transform.position.z) , player.transform.position) > frameGap)
            {

                Plane normalPlane = new Plane(transform.right, transform.position);
                Plane tangentPlane = new Plane(transform.up, transform.position);


                float distanceStrength = normalPlane.GetDistanceToPoint(player.transform.position);
                if(distanceStrength != 0)
                    distanceStrength =  Mathf.Abs(1 / distanceStrength);



                if (normalPlane.GetSide(player.transform.position))
                {
                    if (tangentPlane.GetSide(player.transform.position))
                        turnSpeed += Time.deltaTime * turnStrength * distanceStrength;
                    else
                        turnSpeed -= Time.deltaTime * turnStrength * distanceStrength;
                }
                else
                {
                    if (tangentPlane.GetSide(player.transform.position))
                        turnSpeed -= Time.deltaTime * turnStrength * distanceStrength;
                    else
                        turnSpeed += Time.deltaTime * turnStrength * distanceStrength;
                }


            }

        }
        

        
    }

}
