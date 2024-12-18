using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderManager : MonoBehaviour
{
    public static SliderManager Instance;
    private Slider m_Slider;
    
    void Awake()
    {
        Instance = this;
        m_Slider = gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
    public void SetProgress(float value)
    {
        m_Slider.value = value;
    }
}
