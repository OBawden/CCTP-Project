using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRipple : MonoBehaviour
{

    public Material water;
    float offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * 0.05f; ;
        if (offset > 10)
        {
            offset -= 10;
        }
        water.SetTextureOffset("_MainTex", new Vector3(offset, offset));
    }
}
