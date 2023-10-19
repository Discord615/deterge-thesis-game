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
    [Header("Teleporters")]
    [SerializeField] private GameObject[] FirstFloorTeleps;
    [SerializeField] private GameObject[] SecondFloorTeleps;

    [Header("Chairs")]
    [SerializeField] private GameObject[] canteenChairs;
    [SerializeField] private GameObject[] classroomChairs;

    [Header("Beds")]
    [SerializeField] private GameObject[] beds;

    [Header("General")]
    [SerializeField] private GameObject[] FirstFloorRandomTargets;
    [SerializeField] private GameObject[] SecondFloorRandomTargets;
    [SerializeField] private GameObject canteenFood;


    public GameObject getAnyGameObjectTarget(int floor) // TODO: If target is key places for virus then add a randomizer for getting sick that depends on where they got it
    {
        GameObject target = null;
        switch (Random.Range(0, 4))
        {
            case 0:
                target = getTeleportTarget(floor);
                break;

            case 1:
                target = getRandomTarget(floor);
                break;

            case 2:
                target = getClassroomChairTarget(floor);
                break;

            case 3:
                target = getCanteenChairTarget(floor);
                break;
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

    public GameObject getCanteenChairTarget(int floor)
    {
        GameObject target = null;
        if (floor != 1) target = getAnyGameObjectTarget(floor);

        target = canteenChairs[Random.Range(0, canteenChairs.Length)];

        return target;
    }

    public GameObject getClassroomChairTarget(int floor)
    {
        GameObject target = null;

        if (floor != 2) target = getAnyGameObjectTarget(floor);

        target = classroomChairs[Random.Range(0, classroomChairs.Length)];

        return target;
    }

    public GameObject getBedTarget(int floor)
    {
        GameObject target = null;

        foreach (GameObject bed in beds)
        {
            if (bed.GetComponent<LayDown>().occupied) continue;

            target = bed;
            break;
        }

        return target; // Returns null if no bed was available
    }

    public GameObject getRandomTarget(int floor)
    {
        switch (floor)
        {
            case 1:
                return FirstFloorRandomTargets[Random.Range(0, FirstFloorRandomTargets.Length)];

            case 2:
                return SecondFloorRandomTargets[Random.Range(0, SecondFloorRandomTargets.Length)];
        }
        return null;
    }
}