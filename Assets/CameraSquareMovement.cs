using UnityEngine;

public class CameraSquareMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector3[] points;
    private Quaternion[] rotations;
    private int currentPoint = 0;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        // in the road point and rotation 
        points = new Vector3[5];
        rotations = new Quaternion[5];

        points[0] = new Vector3(110, 35, -158);   // A point
        points[1] = new Vector3(137, 35, 142);    // B point
        points[2] = new Vector3(-132, 35, 166);   // C point
        points[3] = new Vector3(-180, 35, -106);  // D point
        points[4] = points[0];                    // go back to A point 

        rotations[0] = Quaternion.Euler(0, 5, 0);
        rotations[1] = Quaternion.Euler(0, -85, 0);
        rotations[2] = Quaternion.Euler(0, -170, 0);
        rotations[3] = Quaternion.Euler(0, -265, 0);
        rotations[4] = rotations[0];  // go back the rotations

        // 初始化运动
        startTime = Time.time;
        journeyLength = Vector3.Distance(points[currentPoint], points[(currentPoint + 1) % points.Length]);

        Debug.Log("Script Initialized. Points and Rotations set.");
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        // move camera
        Vector3 newPosition = Vector3.Lerp(points[currentPoint], points[(currentPoint + 1) % points.Length], fractionOfJourney);
        transform.position = newPosition;

        Debug.Log("Camera Position: " + newPosition);

        if (fractionOfJourney >= 1)
        {
            currentPoint = (currentPoint + 1) % points.Length;
            transform.rotation = rotations[currentPoint];
            startTime = Time.time;
            journeyLength = Vector3.Distance(points[currentPoint], points[(currentPoint + 1) % points.Length]);

            Debug.Log("Camera Rotation: " + transform.rotation);
        }
    }
}
