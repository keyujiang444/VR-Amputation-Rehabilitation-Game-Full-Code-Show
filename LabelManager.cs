using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
    public static LabelManager Instance;

    public TextMeshProUGUI m_Text;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowText(string[] msg, float duration = 3)
    {
        StartCoroutine(CoShowTexts(msg, duration));
    }

    IEnumerator CoShowTexts(string[] messages, float duration = 3)
    {
        foreach (var msg in messages)
        {
            m_Text.text = msg;
            yield return new WaitForSeconds(duration);
        }

        m_Text.text = "";
    }
}