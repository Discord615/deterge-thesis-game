using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class VirusAreaScript : MonoBehaviour
{
    [SerializeField] private bool flu;
    [SerializeField] private bool covid;
    [SerializeField] private bool tuber;

    private void OnTriggerStay(Collider other) {
        if (!other.tag.Equals("Player")) return;

        if (!dangerourArea()) return;

        PlayerHealthManager.instance.reduceHealth(3f);
    }

    private bool dangerourArea(){
        bool isDangerous = false;

        switch (GameWorldStatsManager.instance.activeVirusName)
        {
            case "flu":
                if (flu) isDangerous = true;
                break;

            case "tuber":
                if (tuber) isDangerous = true;
                break;

            case "covid":
                if (covid) isDangerous = true;
                break;

            default:
                // None
                break;
        }

        return isDangerous;
    }
}
