using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstuckScript : MonoBehaviour
{
    private Vector3 currentPosition;
    private float waitingTime = 4f;
    private float secondWait = 6f;
    private void FixedUpdate() {
        if (GetComponent<NPCAnimScript>().isLayingDown){
            secondWait = 6f;
            waitingTime = 4f;
            return;
        }

        waitingTime -= Time.deltaTime;
        secondWait -= Time.deltaTime;

        if (secondWait <= 0){
            GetComponent<Unit>().floor = GetComponent<Unit>().floor == 1 ? 2 : 1;
            GetComponent<NPCAnimScript>().stopped = true;
            secondWait = 6f;
        }

        if (waitingTime <= 0){
            GetComponent<NPCAnimScript>().stopped = true;
            waitingTime = 4f;
        }

        if (Mathf.CeilToInt(currentPosition.x) == Mathf.CeilToInt(transform.position.x) && Mathf.CeilToInt(currentPosition.z) == Mathf.CeilToInt(transform.position.z)) return;
            currentPosition = transform.position;
            secondWait = 6f;
            waitingTime = 4f;
    }
}
