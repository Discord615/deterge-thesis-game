using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWallTransparent : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    [SerializeField] private GameObject player;

    GameObject newWall, prevWall;

    private RaycastHit hit;

    private int layerNumber = 3;
    private int layerMask;

    [SerializeField] private float timeStart = 1f;
    private float timer;

    private void Start() {
        layerMask = 1 << layerNumber;
        timer = timeStart;
    }

    void castRay(){
        Vector3 screenPos = mainCam.WorldToScreenPoint(new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z));
        Ray rayFromCam = mainCam.ScreenPointToRay(screenPos);

        float camDistanceToPlayer = Vector3.Distance(mainCam.transform.position, player.transform.position);

        if (!Physics.Raycast(rayFromCam, out hit, camDistanceToPlayer, layerMask)) {
        // Debug.DrawRay(rayFromCam.origin, rayFromCam.direction * 50, Color.green);
            if (prevWall == null) return;

            prevWall.GetComponent<MeshRenderer>().enabled = true;

            prevWall = null;

            timer = timeStart;

            return;
        }
        
        newWall = hit.collider.gameObject;

        if (newWall == prevWall) return;

        if (timer > 0){
            timer -= Time.deltaTime;
            return;
        }

        if (prevWall != null) prevWall.GetComponent<MeshRenderer>().enabled = true; // ! Fix Timer Out

        newWall.GetComponent<MeshRenderer>().enabled = false;

        prevWall = newWall;
        // Debug.DrawRay(rayFromCam.origin, rayFromCam.direction * 50, Color.blue);
    }

    void Update(){
        castRay();
    }
}
