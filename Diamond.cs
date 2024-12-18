using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Diamond : MonoBehaviour
{
    private XRSimpleInteractable m_Interactable;
    private Animator m_Animator;
    private SphereCollider m_Collider;
    public float PickTime = 5;
    public Slider m_Slider;
    private bool selecting;
    private float selectTime;
    public bool ShowTips;
    public string[] Tips;

    void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Collider = gameObject.GetComponent<SphereCollider>();
        m_Interactable = gameObject.GetComponent<XRSimpleInteractable>();
        m_Interactable.selectEntered.AddListener(OnSelected);
        m_Interactable.selectExited.AddListener(OnExited);
        m_Animator.enabled = false;
    }

    private void Start()
    {
        m_Slider.gameObject.SetActive(false);
    }

    private void OnExited(SelectExitEventArgs arg0)
    {
        selecting = false;
        m_Slider.gameObject.SetActive(false);
        SliderManager.Instance.SetActive(false);
    }

    private void OnSelected(SelectEnterEventArgs arg0)
    {
        selecting = true;
        SliderManager.Instance.SetActive(true);
        // m_Slider.gameObject.SetActive(true);
        var parent = m_Slider.transform.parent;
        parent.forward = parent.position - Camera.main.transform.position;
        parent.up = parent.position - transform.position;
    }

    private void Update()
    {
        if (selecting)
        {
            selectTime += Time.deltaTime;
            var percent = selectTime / PickTime;
            // m_Slider.value = percent;
            SliderManager.Instance.SetProgress(percent);

            if (selectTime > PickTime)
            {
                selecting = false;
                m_Animator.enabled = true;
                m_Collider.enabled = false;
                // m_Slider.gameObject.SetActive(false);
                SliderManager.Instance.SetActive(false);

                if (ShowTips)
                {
                    LabelManager.Instance.ShowText(Tips);
                }
            }
        }
    }
}