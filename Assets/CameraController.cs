using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float dx, dy, dz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt= Time.deltaTime*0.005f;
        dz+= dt;
        transform.position = transform.position + new Vector3(dx, dy, dz);
    }
}
