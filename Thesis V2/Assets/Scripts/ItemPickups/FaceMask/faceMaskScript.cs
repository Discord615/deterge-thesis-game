using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class faceMaskScript : MonoBehaviour
{
    public static faceMaskScript instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Face Mask Script in current scene");
        }
        instance = this;
    }

    [SerializeField] private GameObject faceMaskObject;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        GameWorldStatsManager.instance.hasFaceMask = true;
        faceMaskObject.SetActive(false);
        GetComponent<SphereCollider>().enabled = false;
    }

    public void removeFaceMask()
    {
        GameWorldStatsManager.instance.hasFaceMask = false;
        faceMaskObject.SetActive(true);
        GetComponent<SphereCollider>().enabled = true;
    }
}
