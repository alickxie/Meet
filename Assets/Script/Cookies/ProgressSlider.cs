using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        fill.color = gradient.Evaluate(0f);
    }

    public void UpdateProgress(float progress)
    {
        slider.value = progress;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public float GetProgress()
    {
        return slider.value;
    }
}
