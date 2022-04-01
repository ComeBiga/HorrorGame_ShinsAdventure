using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager instance;

    public PostProcessVolume v;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<PostProcessVolume>();

        v.profile.GetSetting<ColorGrading>().postExposure.value = -0.5f;
        v.profile.GetSetting<ColorGrading>().temperature.value = -17f;
        v.profile.GetSetting<Vignette>().intensity.value = 0.11f;

        //Debug.Log("HI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPostExposure(float value)
    {
        v.profile.GetSetting<ColorGrading>().postExposure.value = value;
    }

    public void SetVignetteIntensity(float value)
    {
        v.profile.GetSetting<Vignette>().intensity.value = value;
    }

    public void SetTemperature(float value)
    {
        v.profile.GetSetting<ColorGrading>().temperature.value = value;
    }
}
