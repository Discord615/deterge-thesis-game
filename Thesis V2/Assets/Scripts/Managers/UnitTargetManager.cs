using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetManager : MonoBehaviour
{
    private static UnitTargetManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Error: There seems to be an existing instance of Unit Target Manager");
        }
        instance = this;
    }

    public static UnitTargetManager GetInstance()
    {
        return instance;
    }

    // =====================================================================================================
    // =====================================================================================================
    [Header("FirstFloor")]
    [SerializeField] private GameObject[] FirstFloorRandomTargets;
    [SerializeField] private GameObject[] FirstFloorTeleps;
    [SerializeField] private GameObject[] gymnasiumTargets;
    [SerializeField] private GameObject[] canteenChairs;

    [Header("SecondFloor")]
    [SerializeField] private GameObject[] SecondFloorRandomTargets;
    [SerializeField] private GameObject[] SecondFloorTeleps;
    [SerializeField] private GameObject[] classroomChairs;

    [Header("Beds")]
    [SerializeField] private GameObject[] beds;

    public Vector3 getAnyGameObjectTarget(int floor, GameObject NPC)
    {
        Vector3 result = Vector3.zero;
        switch (floor)
        {
            case 1:
                result = getAnyFirstFloorTargets(NPC);
                break;

            case 2:
                result = getAnySecondFloorTargets(NPC);
                break;
        }

        return result;
    }

    private Vector3 getAnyFirstFloorTargets(GameObject npc)
    {
        Vector3 result = Vector3.zero;
        int randomSwitchCase = Random.Range(0, 4);

        switch (randomSwitchCase)
        {
            case 0:
                npc.GetComponent<Unit>().wantToTeleport = false;
                result = gymnasiumTargets[Random.Range(0, gymnasiumTargets.Length)].transform.position;
                break;

            case 1:
                npc.GetComponent<Unit>().wantToTeleport = false;
                result = canteenChairs[Random.Range(0, canteenChairs.Length)].transform.position;
                break;

            case 2:
                if (npc.GetComponent<NPCAnimScript>().isSick){
                    result = FirstFloorRandomTargets[Random.Range(0, FirstFloorRandomTargets.Length)].transform.position;
                    break;
                }
                npc.GetComponent<Unit>().wantToTeleport = true;
                result = FirstFloorTeleps[Random.Range(0, FirstFloorTeleps.Length)].transform.position;
                break;

            case 3:
                npc.GetComponent<Unit>().wantToTeleport = false;
                result = FirstFloorRandomTargets[Random.Range(0, FirstFloorRandomTargets.Length)].transform.position;
                break;
        }

        return result;
    }

    private Vector3 getAnySecondFloorTargets(GameObject npc)
    {
        Vector3 result = Vector3.zero;
        switch (Random.Range(0, 3))
        {
            case 0:
                npc.GetComponent<Unit>().wantToTeleport = false;
                result = classroomChairs[Random.Range(0, classroomChairs.Length)].transform.position;
                break;

            case 1:
                npc.GetComponent<Unit>().wantToTeleport = true;
                result = SecondFloorTeleps[Random.Range(0, SecondFloorTeleps.Length)].transform.position;
                break;

            case 2:
                npc.GetComponent<Unit>().wantToTeleport = false;
                result = SecondFloorRandomTargets[Random.Range(0, SecondFloorRandomTargets.Length)].transform.position;
                break;

        }

        return result - new Vector3(850, 0, 0);
    }

    public Vector3 getBedTarget(int floor, GameObject NPC)
    {
        Vector3 target = Vector3.zero;

        if (floor != 1)
        {
            return getAnyGameObjectTarget(floor, NPC);
        }

        foreach (GameObject bed in beds)
        {
            if (bed.GetComponent<LayDown>().occupied) continue;

            target = bed.transform.position;
            break;
        }

        if (target == null)
        {
            target = getAnyGameObjectTarget(floor, NPC);
        }

        return target;
    }

    public Vector3 getTeleportTarget(int floor){

        switch (floor)
        {
            case 1:
                return FirstFloorTeleps[Random.Range(0, FirstFloorTeleps.Length)].transform.position;

            case 2:
                return SecondFloorTeleps[Random.Range(0, SecondFloorTeleps.Length)].transform.position;
        }

        return Vector3.zero;

    }
}