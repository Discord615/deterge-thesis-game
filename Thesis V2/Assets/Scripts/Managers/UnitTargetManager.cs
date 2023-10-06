using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetManager : MonoBehaviour
{
    private static UnitTargetManager instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Error: There seems to be an existing instance of Unit Target Manager");
        }
        instance = this;
    }

    public static UnitTargetManager GetInstance(){
        return instance;
    }

    // =====================================================================================================
    // =====================================================================================================

    [SerializeField] private GameObject[] FirstFloorTeleps;
    [SerializeField] private GameObject[] SecondFloorTeleps;
    [SerializeField] private GameObject[] RandomTargets;
    [SerializeField] private GameObject[] canteenChairs;
    [SerializeField] private GameObject canteenFood;
    [SerializeField] private GameObject[] classroomChairs;

    [SerializeField] private GameObject[] beds;

    public GameObject getAnyGameObjectTarget(int floor){
        switch (Random.Range(0, 5)){
            case 0:
                return getTeleportTarget(floor);
            
            case 1:
                return getRandomTarget();

            // TODO: Add other targets
            // TODO: If target is key places for virus then add a randomizer for getting sick that depends on where they got it

            default:
                return null;
        }
    }

    public GameObject getTeleportTarget(int floor){
        switch (floor){
            case 1:
                return FirstFloorTeleps[Random.Range(0, FirstFloorTeleps.Length)];
            case 2:
                return SecondFloorTeleps[Random.Range(0, SecondFloorTeleps.Length)];
        }
        return null;
    }

    public GameObject getRandomTarget(){
        return RandomTargets[Random.Range(0, RandomTargets.Length)];
    }
}
