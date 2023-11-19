using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIcon : MonoBehaviour
{
    [SerializeField] private bool tutorial = false;
    GameObject questPointObject;
    Vector3 offset = new Vector3(0, 5, 0);

    private void Start()
    {
        questPointObject = transform.parent.gameObject;
        transform.localPosition += offset;
        gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
    }

    private void OnDestroy()
    {
        if (!tutorial)
            questPointObject.GetComponent<QuestPoint>().iconIsDestroyed = true;
    }
}
