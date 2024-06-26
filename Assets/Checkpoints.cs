using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Material newBuildingMaterial;

    private bool pointAReached = false;
    private bool pointBReached = false;
    private bool pointCReached = false;
    private bool pointDReached = false;

    void Update()
    {
        CheckPointReached();
    }

    void CheckPointReached()
    {
        if (!pointAReached && Vector3.Distance(transform.position, pointA.position) < 1f)
        {
            pointAReached = true;
            Debug.Log("Point A reached");
            ChangeBuildingMaterials();
        }
        else if (pointAReached && !pointBReached && Vector3.Distance(transform.position, pointB.position) < 1f)
        {
            pointBReached = true;
            Debug.Log("Point B reached");
            ChangeBuildingMaterials();
        }
        else if (pointBReached && !pointCReached && Vector3.Distance(transform.position, pointC.position) < 1f)
        {
            pointCReached = true;
            Debug.Log("Point C reached");
            ChangeBuildingMaterials();
        }
        else if (pointCReached && !pointDReached && Vector3.Distance(transform.position, pointD.position) < 1f)
        {
            pointDReached = true;
            Debug.Log("Point D reached");
            ChangeBuildingMaterials();
        }
    }

    void ChangeBuildingMaterials()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject building in buildings)
        {
            Renderer[] renderers = building.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.material = newBuildingMaterial;
            }
        }
    }
}
