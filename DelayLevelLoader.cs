using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class DelayLevelLoader : MonoBehaviour
{
    private XRSimpleInteractable m_interactable;

    public GameObject m_Particle;
    public GameObject m_3DScene;
    public GameObject m_Tunneling;

    public float DelayTime = 5;
    
    void Start()
    {
        m_interactable = gameObject.GetComponent<XRSimpleInteractable>();
        m_interactable.selectEntered.AddListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs arg0)
    {
        m_Particle.SetActive(false);
        m_3DScene.SetActive(false);
        m_Tunneling.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(DelayLoadLevel());
    }

    IEnumerator DelayLoadLevel()
    {
        yield return new WaitForSeconds(DelayTime);
        SceneManager.LoadScene(1);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Particle.SetActive(false);
            m_3DScene.SetActive(false);
            m_Tunneling.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(DelayLoadLevel());
        }
    }
}
