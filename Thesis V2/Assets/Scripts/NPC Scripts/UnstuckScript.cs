using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstuckScript : MonoBehaviour
{
    private Vector3 currentPosition;
    private float waitingTime = 4f;
    private void FixedUpdate() {
        if (!GetComponent<NPCAnimScript>().isLayingDown){
            waitingTime -= Time.deltaTime;
        }

        if (waitingTime <= 0){
            GetComponent<NPCAnimScript>().stopped = true;
            waitingTime = 4f;
        }

        if (Mathf.CeilToInt(currentPosition.x) == Mathf.CeilToInt(transform.position.x) && Mathf.CeilToInt(currentPosition.z) == Mathf.CeilToInt(transform.position.z)) return;
            currentPosition = transform.position;
            waitingTime = 4f;
    }
}
