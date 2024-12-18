using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bone : MonoBehaviour
{
    private XRSimpleInteractable m_Interactable;
    private bool entering;
    private float enterTime;
    public float HoldTime = 10;
    public GameObject flowerEffect;
    // public Slider m_Slider;

    public bool ShowTips;
    public string[] Tips;
    void Start()
    {
        m_Interactable = gameObject.GetComponent<XRSimpleInteractable>();
        m_Interactable.selectEntered.AddListener(OnEnter);
        m_Interactable.selectExited.AddListener(OnExit);
    }

    private void OnExit(SelectExitEventArgs arg0)
    {
        entering = false;
        // m_Slider.gameObject.SetActive(false);
        SliderManager.Instance.SetActive(false);
    }

    private void OnEnter(SelectEnterEventArgs arg0)
    {
        entering = true;
        enterTime = Time.time;
        // m_Slider.gameObject.SetActive(true);
        SliderManager.Instance.SetActive(true);
    }

    private void Update()
    {
        if (entering)
        {
            var duration = Time.time - enterTime;
            // m_Slider.value = duration / HoldTime;
            SliderManager.Instance.SetProgress(duration / HoldTime);

            if (duration >= HoldTime)
            {
                entering = false;
                // m_Slider.gameObject.SetActive(false);
                SliderManager.Instance.SetActive(false);
                flowerEffect.SetActive(true);

                if (ShowTips)
                {
                    StartCoroutine(DelayShowText(10));
                }
            }
        }
    }
    
    IEnumerator DelayShowText(float delay)
    {
        yield return new WaitForSeconds(delay);
        LabelManager.Instance.ShowText(Tips,5);
    }
}