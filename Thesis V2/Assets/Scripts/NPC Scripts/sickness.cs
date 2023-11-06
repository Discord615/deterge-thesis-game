using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sickness : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("npc")) return;

        UnitTargetManager.GetInstance().getSick(other.gameObject);
    }
}
