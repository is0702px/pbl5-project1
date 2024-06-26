using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Car3; // 将你的车3 GameObject 拖动到此字段
    private Vector3 offset;

    void Start()
    {
        // 检查 Car3 是否被赋值
        if (Car3 == null)
        {
            Debug.LogError("Car3 has not been assigned.");
            return;
        }

        // 初始化摄像机位置相对于car3的位置偏移
        offset = transform.position - Car3.transform.position;
        
        // 提高摄像机的Y和Z值，比如增加Y轴1.2个单位，增加Z轴1.5个单位
        offset.y += 1.2f;
        offset.z -= 1.5f; // 使用负的Z偏移以确保摄像机位于汽车后方
    }

    void LateUpdate()
    {
        // 确保 Car3 被赋值
        if (Car3 == null)
        {
            Debug.LogError("Car3 has not been assigned.");
            return;
        }

        // 更新摄像机位置以跟随car3
        Vector3 desiredPosition = Car3.transform.position + Car3.transform.TransformDirection(offset);
        transform.position = desiredPosition;
        
        // 更新摄像机的旋转以保持与car3一致
        transform.LookAt(Car3.transform.position + Car3.transform.forward * 5);
    }
}