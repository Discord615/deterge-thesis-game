using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GloveBehavior : MonoBehaviour
{
    public static GloveBehavior instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Glove Behavior in current scene");
        }
        instance = this;
    }

    [SerializeField] private GameObject gloveObject;

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;
        GameWorldStatsManager.instance.hasGlove = true;
        gloveObject.SetActive(false);
        GetComponent<SphereCollider>().enabled = false;
    }

    public void removeGlove(){
        GameWorldStatsManager.instance.hasGlove = false;
        gloveObject.SetActive(true);
        GetComponent<SphereCollider>().enabled = true;
    }
}
