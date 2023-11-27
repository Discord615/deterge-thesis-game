using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarReference : MonoBehaviour
{
    public static HealthBarReference instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public GameObject healthPanel;
}
