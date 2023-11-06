using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetManager : MonoBehaviour // TODO: TEST Script
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
    [SerializeField] private GameObject[] classroomChairs;
    [SerializeField] private GameObject[] gymnasiumTargets;

    [Header("SecondFloor")]
    [SerializeField] private GameObject[] SecondFloorRandomTargets;
    [SerializeField] private GameObject[] SecondFloorTeleps;
    [SerializeField] private GameObject[] canteenChairs;

    [Header("Beds")]
    [SerializeField] private GameObject[] beds;


    public GameObject getAnyGameObjectTarget(int floor, GameObject NPC)
    {
        GameObject target = null;

        while (true)
        {
            int randomNum = Random.Range(0, 5);
            switch (randomNum)
            {
                case 0:
                    target = getTeleportTarget(floor);
                    break;

                case 1:
                    target = getRandomTarget(floor);
                    break;

                case 2:
                    target = getClassroomChairTarget(floor, NPC);
                    break;

                case 3:
                    if (floor == 1) target = getCanteenChairTarget(floor, NPC);
                    break;

                case 4:
                    if (floor == 1) target = getGymTargets(floor, NPC);
                    break;
            }

            if (target != null) break;
        }

        return target;
    }

    public GameObject getTeleportTarget(int floor)
    {
        switch (floor)
        {
            case 1:
                return FirstFloorTeleps[Random.Range(0, FirstFloorTeleps.Length)];
            case 2:
                return SecondFloorTeleps[Random.Range(0, SecondFloorTeleps.Length)];
        }
        return null;
    }

    public GameObject getCanteenChairTarget(int floor, GameObject NPC)
    {
        GameObject target = null;

        if (floor != 1)
        {
            return getAnyGameObjectTarget(floor, NPC);
        }

        getSick(NPC);

        target = canteenChairs[Random.Range(0, canteenChairs.Length)];

        return target;
    }

    public GameObject getClassroomChairTarget(int floor, GameObject NPC)
    {
        GameObject target = null;

        if (floor != 2)
        {
            return getAnyGameObjectTarget(floor, NPC);
        }

        getSick(NPC);

        target = classroomChairs[Random.Range(0, classroomChairs.Length)];

        return target;
    }

    public GameObject getBedTarget(int floor, GameObject NPC)
    {
        GameObject target = null;

        if (floor != 1)
        {
            return getAnyGameObjectTarget(floor, NPC);
        }

        foreach (GameObject bed in beds)
        {
            if (bed.GetComponent<LayDown>().occupied) continue;

            target = bed;
            break;
        }

        if (target == null){
            target = getAnyGameObjectTarget(floor, NPC);
        }

        return target;
    }

    public GameObject getRandomTarget(int floor)
    {
        GameObject target = null;
        switch (floor)
        {
            case 1:
                target = FirstFloorRandomTargets[Random.Range(0, FirstFloorRandomTargets.Length)];
                break;

            case 2:
                target = SecondFloorRandomTargets[Random.Range(0, SecondFloorRandomTargets.Length)];
                break;
        }
        return target;
    }

    public GameObject getGymTargets(int floor, GameObject NPC)
    {
        if (floor != 1)
        {
            return getAnyGameObjectTarget(floor, NPC);
        }

        getSick(NPC);

        return gymnasiumTargets[Random.Range(0, gymnasiumTargets.Length)];
    }

    public void getSick(GameObject NPC)
    {
        if (!NPC.GetComponent<NPCAnimScript>().isSick && !NPC.GetComponent<NPCAnimScript>().isLayingDown)
        {
            int chanceOfGettingSick = Random.Range(0, 30);

            if (chanceOfGettingSick == 9) NPC.GetComponent<NPCAnimScript>().isSick = true;
        }
    }
}