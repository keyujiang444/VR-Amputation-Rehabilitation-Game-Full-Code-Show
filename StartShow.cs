using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShow : MonoBehaviour
{
    public string[] messages;

    private void Start()
    {
        LabelManager.Instance.ShowText(messages);
    }
}