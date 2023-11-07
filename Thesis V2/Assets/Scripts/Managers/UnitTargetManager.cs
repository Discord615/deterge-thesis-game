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
    [SerializeField] private GameObject[] gymnasiumTargets;
    [SerializeField] private GameObject[] canteenChairs;

    [Header("SecondFloor")]
    [SerializeField] private GameObject[] SecondFloorRandomTargets;
    [SerializeField] private GameObject[] SecondFloorTeleps;
    [SerializeField] private GameObject[] classroomChairs;

    [Header("Beds")]
    [SerializeField] private GameObject[] beds;

    [Header("TESTING")]
    [SerializeField] private bool allowTeleporting = true;


    public GameObject getAnyGameObjectTarget(int floor, GameObject NPC)
    {
        switch (floor)
        {
            case 1:
                return getAnyFirstFloorTargets();

            case 2:
                return getAnySecondFloorTargets();
        }

        return null;
    }

    private GameObject getAnyFirstFloorTargets(){
        int randomSwitchCase = Random.Range(0, 4);
        if (!allowTeleporting && randomSwitchCase == 2) randomSwitchCase++;

        switch (randomSwitchCase)
        {
            case 0:
                return gymnasiumTargets[Random.Range(0, gymnasiumTargets.Length)];

            case 1:
                return canteenChairs[Random.Range(0, canteenChairs.Length)];

            case 2:
                return FirstFloorTeleps[Random.Range(0, FirstFloorTeleps.Length)];

            case 3:
                return FirstFloorRandomTargets[Random.Range(0, FirstFloorRandomTargets.Length)];
        }

        return null;
    }

    private GameObject getAnySecondFloorTargets(){
        switch (Random.Range(0, 3))
        {
            case 0:
                return classroomChairs[Random.Range(0, classroomChairs.Length)];

            case 1:
                return SecondFloorTeleps[Random.Range(0, SecondFloorTeleps.Length)];
                
            case 2:
                return SecondFloorRandomTargets[Random.Range(0, SecondFloorRandomTargets.Length)];

        }

        return null;
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

    public void getSick(GameObject NPC)
    {
        if (!NPC.GetComponent<NPCAnimScript>().isSick && !NPC.GetComponent<NPCAnimScript>().isLayingDown)
        {
            int chanceOfGettingSick = Random.Range(0, 30);

            if (chanceOfGettingSick == 9) NPC.GetComponent<NPCAnimScript>().isSick = true;
        }
    }
}