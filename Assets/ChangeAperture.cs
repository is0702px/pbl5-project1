using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeAperture : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // 后处理卷 / Post-process volume
    private DepthOfField depthOfField;          // 景深模糊效果 / Depth of field blur effect
    private int currentApertureIndex = 0;       // 当前光圈索引 / Current aperture index
    private float[] apertureValues = { 10f, 6f, 3f, 1f }; // 光圈值数组 / Aperture values array

    void Start()
    {
        // 确保后处理卷存在 / Ensure the post-process volume is assigned
        if (postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume is not assigned.");
            return;
        }

        // 获取景深模糊效果 / Get the depth of field effect
        if (!postProcessVolume.profile.TryGetSettings(out depthOfField))
        {
            Debug.LogError("Depth of Field is not found in the PostProcessVolume profile.");
            return;
        }

        // 初始化光圈值 / Initialize aperture value
        SetAperture(apertureValues[currentApertureIndex]);
    }

    void Update()
    {
        // 按下C键切换光圈值 / Change aperture value when the C key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentApertureIndex = (currentApertureIndex + 1) % apertureValues.Length;
            SetAperture(apertureValues[currentApertureIndex]);
        }
    }

    // 设置光圈值 / Set aperture value
    private void SetAperture(float aperture)
    {
        if (depthOfField != null)
        {
            depthOfField.aperture.value = aperture;
            Debug.Log("Aperture set to: " + aperture);
        }
    }
}
