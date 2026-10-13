using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public RawImage fill;

    public void setMaxIce(float timerValue)
    {
        slider.maxValue = timerValue;
        slider.value = timerValue;
        fill.color = gradient.Evaluate(1f);
    }
    public void setIce(float timerValue)
    {
        slider.value = timerValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
