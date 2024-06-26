using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 30f;
    public float turnSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 150;  // 设置较大的质量
    }

    void Update()
    {
        // 获取用户输入
        float moveDirection = Input.GetAxis("Vertical") * speed;
        float turnDirection = Input.GetAxis("Horizontal") * turnSpeed;

        // 计算运动和转向
        Vector3 move = transform.forward * moveDirection * Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f, turnDirection * Time.deltaTime, 0f);

        // 应用运动和转向
        rb.MovePosition(rb.position + move);
        rb.MoveRotation(rb.rotation * turn);
    }
}