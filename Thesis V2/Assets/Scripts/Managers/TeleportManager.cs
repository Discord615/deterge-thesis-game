using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    private static TeleportManager instance;
    public bool goingToTeleport { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There are more than one instance of Teleport Manager");
        }
        instance = this;
    }

    public static TeleportManager GetInstance()
    {
        return instance;
    }

    public void TeleportNPC(GameObject gameObject, Vector3 teleportLocation)
    {
        gameObject.GetComponent<Unit>().wantToTeleport = false;
        ChangePosition(gameObject, teleportLocation);
    }

    public void TeleportPlayer(GameObject gameObject, Vector3 teleportLocation)
    {
        goingToTeleport = true;
        ChangePosition(gameObject, teleportLocation);
        goingToTeleport = false;
    }

    private void ChangePosition(GameObject gameObject, Vector3 teleportLocation)
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.transform.position = teleportLocation;
    }
}
