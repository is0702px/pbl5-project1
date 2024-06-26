using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ApplyBlurEffect : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // 后处理卷 / Post-process volume
    private DepthOfField depthOfField;          // 景深模糊效果 / Depth of field blur effect
    private bool isBlurActive = false;          // 记录模糊效果是否激活 / Records if the blur effect is active
    public float initialBlurIntensity = 10.0f;  // 初始模糊强度 / Initial blur intensity
    public float blurIncrement = 50.0f;         // 每次增加的模糊强度 / Blur intensity increment
    public int maxBlurSteps = 5;                // 最大模糊步数 / Maximum blur steps
    private int currentBlurStep = 0;            // 当前模糊步数 / Current blur step

    void Start()
    {
        // 确保后处理卷存在 / Ensure the post-process volume is assigned
        if (postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume is not assigned.");
            return;
        }

        // 获取景深模糊效果 / Get the depth of field effect
        postProcessVolume.profile.TryGetSettings(out depthOfField);

        // 设置初始模糊强度 / Set the initial blur intensity
        SetBlurIntensity(initialBlurIntensity);
    }

    void Update()
    {
        // 按下空格键切换和增加模糊效果 / Toggle and increase blur effect with space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncrementBlur();
        }

        // 按下数字键1设置模糊强度为50 / Set blur intensity to 50 with key 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetBlurIntensity(50.0f);
        }

        // 按下数字键2设置模糊强度为100 / Set blur intensity to 100 with key 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetBlurIntensity(100.0f);
        }

        // 按下数字键3设置模糊强度为150 / Set blur intensity to 150 with key 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetBlurIntensity(150.0f);
        }
    }

    // 增加模糊效果 / Increment blur effect
    public void IncrementBlur()
    {
        if (currentBlurStep < maxBlurSteps)
        {
            currentBlurStep++;
            SetBlurIntensity(initialBlurIntensity + currentBlurStep * blurIncrement);
        }
    }

    // 切换模糊效果 / Toggle blur effect
    public void ToggleBlur()
    {
        isBlurActive = !isBlurActive;
        depthOfField.active = isBlurActive;
    }

    // 设置模糊强度 / Set blur intensity
    public void SetBlurIntensity(float intensity)
    {
        if (depthOfField != null)
        {
            depthOfField.aperture.value = intensity;
        }
    }
}
