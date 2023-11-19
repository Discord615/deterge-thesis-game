using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Arrow Manager exists in the current scene");
        }
        instance = this;
    }

    public Vector3 target;
    public bool isVisible = true;

    private void Update() {
        if (target == Vector3.zero) isVisible = false;
        else isVisible = true;

        GetComponent<MeshRenderer>().enabled = isVisible;

        if (!isVisible) return;

        target.y = transform.position.y;
        transform.LookAt(target);
    }
}
