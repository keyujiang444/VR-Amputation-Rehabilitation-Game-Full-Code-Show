using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShow : MonoBehaviour
{
    public string[] messages;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LabelManager.Instance.ShowText(messages);
        }
    }
}
